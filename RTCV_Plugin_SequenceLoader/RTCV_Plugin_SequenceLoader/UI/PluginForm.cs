namespace SEQUENCELOADER.UI
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using NLog;
    using RTCV.CorruptCore;

    using RTCV.Common;
    using RTCV.UI;
    using static RTCV.CorruptCore.RtcCore;
    using RTCV.Vanguard;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Runtime.InteropServices;
    using System.Drawing.Imaging;
    using RTCV.NetCore;
    using System.Diagnostics;
    using System.Net;
    using System.Collections.Specialized;

    using System.IO.Compression;
    using System.Windows.Documents.Serialization;
    using RTCV.UI.Modular;
    using RTCV.UI.Components.Controls;

    //using System.Windows;

    public partial class PluginForm : ComponentForm, IColorize
    {
        public SEQUENCELOADER plugin;

        public volatile bool HideOnClose = true;

        Logger logger = NLog.LogManager.GetCurrentClassLogger();

        WebClient wc = new WebClient();

        //This dictionary will inflate forever but it would take quite a while to be noticeable.
        Dictionary<string, bool> encounteredIds = new Dictionary<string, bool>();


        public PluginForm(SEQUENCELOADER _plugin)
        {
            plugin = _plugin;

            this.InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.PluginForm_FormClosing);
            this.Text = "Sequence Loader";// CORRUPTCLOUD_LIVE.CamelCase(nameof(CORRUPTCLOUD_LIVE).Replace("_", " ")); //automatic window title

            this.version.Text = $"{plugin.Version.ToString()}"; //automatic window title
        }


        private void PluginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            encounteredIds.Clear();

            if (HideOnClose)
            {
                e.Cancel = true;
                this.Hide();
            }    
        }

        private bool isPixelIdentical(Bitmap frame1, Bitmap frame2, Point location)
        {
            return (frame1.GetPixel(location.X, location.Y) == frame2.GetPixel(location.X, location.Y));
        }

        private bool isImageIdentical(Bitmap frame1, Bitmap frame2)
        {
            return CompareMemCmp(frame1, frame2);
        }

        [DllImport("msvcrt.dll")]
        private static extern int memcmp(IntPtr b1, IntPtr b2, long count);

        public static bool CompareMemCmp(Bitmap b1, Bitmap b2)
        {
            if ((b1 == null) != (b2 == null)) return false;
            if (b1.Size != b2.Size) return false;

            var bd1 = b1.LockBits(new Rectangle(new Point(0, 0), b1.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var bd2 = b2.LockBits(new Rectangle(new Point(0, 0), b2.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            try
            {
                IntPtr bd1scan0 = bd1.Scan0;
                IntPtr bd2scan0 = bd2.Scan0;

                int stride = bd1.Stride;
                int len = stride * b1.Height;

                return memcmp(bd1scan0, bd2scan0, len) == 0;
            }
            finally
            {
                b1.UnlockBits(bd1);
                b2.UnlockBits(bd2);
            }
        }


        private string CleanName(string alias)
        {
            string firstpass =  alias.Trim().Replace(" ", "_").ToUpper();
            string secondpass = new string(firstpass.Where(it => new char[] { 
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 
                'H', 'I', 'J', 'K', 'L', 'M', 'N', 
                'O', 'P', 'Q', 'R', 'S', 'T', 'U', 
                'V', 'W', 'X', 'Y', 'Z', 
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '_'
            }.Contains(it)).Take(13).ToArray());

            return secondpass;
        }

        public string StashKeyToHexString()
        {
            return null;
        }

        public void LoadFile(string path)
        {
            var fi = new FileInfo(path);
            switch (fi.Extension.ToUpper())
            {
                case ".SPC":
                    {

                        //Prepare player rom with the injected SPC file
                        var loaderfile = Path.Combine(dlldir, "SEQUENCELOADER", "loader.sfc");

                        var key = RtcCore.GetRandomKey();
                        var tempPath = Path.Combine(RtcCore.workingDir, "SESSION", $"{key}.sfc");


                        if (File.Exists(tempPath))
                            File.Delete(tempPath);


                        byte[] loaderFileBytes = File.ReadAllBytes(loaderfile);
                        byte[] spcBytes = File.ReadAllBytes(fi.FullName);
                        int offset = 0xFF00;

                        for (int i = 0; i < spcBytes.Length; i++)
                            loaderFileBytes[offset + i] = spcBytes[i];

                        File.WriteAllBytes(tempPath, loaderFileBytes);


                        //Load rom and make GH savestate
                        LocalNetCoreRouter.Route(Endpoints.Vanguard, RTCV.NetCore.Commands.Remote.LoadROM, tempPath, true);
                        S.GET<SavestateManagerForm>().savestateList.NewSavestateNow();



                        //build a VMD that targets the inner SPC file in the cartrom
                        string domain = "CARTROM";
                        string vmdSpcFileName = " CARTROM : SPC FILE";

                        MemoryInterface mi = MemoryDomains.MemoryInterfaces[domain];

                        //making VMD for inner ROM SPC FILE region
                        {
                            long[] range = new long[2];

                            range[0] = offset;
                            range[1] = offset + spcBytes.Length;

                            List<long[]> ranges = new List<long[]>();
                            ranges.Add(range);

                            RTCV.CorruptCore.MemoryDomains.RemoveVMD(vmdSpcFileName);
                            RTCV.CorruptCore.MemoryDomains.AddVMD(new VmdPrototype()
                            {
                                AddRanges = ranges,
                                GenDomain = domain,
                                VmdName = vmdSpcFileName,
                                BigEndian = mi.BigEndian,
                                WordSize = mi.WordSize,
                                PointerSpacer = 1,
                            });
                        }


                        S.GET<MemoryDomainsForm>().RefreshDomains();
                        S.GET<MemoryDomainsForm>().SetMemoryDomainsSelectedDomains(new string[] { "APURAM", $"[V]{vmdSpcFileName}" });


                    }
                    break;
                case ".NSF":
                    {
                        //Load rom and make GH savestate
                        LocalNetCoreRouter.Route(Endpoints.Vanguard, RTCV.NetCore.Commands.Remote.LoadROM, fi.FullName, true);
                        S.GET<SavestateManagerForm>().savestateList.NewSavestateNow();

                        S.GET<MemoryDomainsForm>().RefreshDomains();
                        S.GET<MemoryDomainsForm>().SetMemoryDomainsSelectedDomains(new string[] { "RAM" });


                        btnNSFNextSong.Visible = true;
                    }
                    break;
            }
        }

        private void lbDragAndDropGH_DragDrop(object sender, DragEventArgs e)
        {


            var formats = e.Data.GetFormats();
            e.Effect = DragDropEffects.Move;

            string[] fd = (string[])e.Data.GetData(DataFormats.FileDrop); //file drop

            if(fd.Length > 1)
            {
                MessageBox.Show("You cannot open more than one song at once. Aborting.");
                return;
            }
            if (fd.Length < 1)
            {
                MessageBox.Show("You cannot open less than one song at once. Aborting.");
                return;
            }

            LoadFile(fd[0]);

        }

        private void lbDragAndDropGH_DragEnter(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.Move;

        }

        private void btnNSFNextSong_Click(object sender, EventArgs e)
        {

            //go to next song
            string domain = "System Bus";
            int address = 0x00CE;
            byte value = 0xFB;
            int lifetime = 1;

            BlastUnit bu = new BlastUnit()
            {
                Address = address,
                Domain = domain,

                Lifetime = lifetime,
                Loop = false,
                Value = new byte[1] { value },
                
                Source = BlastUnitSource.VALUE,
                StoreTime = StoreTime.IMMEDIATE,
                Precision = 1,
                ExecuteFrame = 0,
                IsEnabled = true
            };
            var bl = new BlastLayer(bu);

            LocalNetCoreRouter.Route(RTCV.NetCore.Endpoints.CorruptCore, RTCV.NetCore.Commands.Basic.ApplyBlastLayer, new object[] { bl, false, false }, true);


            //Make GH Savestate 
            S.GET<SavestateManagerForm>().savestateList.NewSavestateNow();

        }
    }



}
