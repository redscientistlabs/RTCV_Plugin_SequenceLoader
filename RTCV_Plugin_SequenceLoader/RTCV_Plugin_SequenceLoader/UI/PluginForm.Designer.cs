using System;
using System.IO;
using System.Windows.Forms;

namespace SEQUENCELOADER.UI
{

    partial class PluginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginForm));
            this.btnSendSelectedStockpile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDragAndDropGH = new System.Windows.Forms.Label();
            this.btnNSFNextSong = new System.Windows.Forms.Button();
            this.version = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSendSelectedStockpile
            // 
            this.btnSendSelectedStockpile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendSelectedStockpile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnSendSelectedStockpile.FlatAppearance.BorderSize = 0;
            this.btnSendSelectedStockpile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendSelectedStockpile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSendSelectedStockpile.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnSendSelectedStockpile.Location = new System.Drawing.Point(10, 215);
            this.btnSendSelectedStockpile.Name = "btnSendSelectedStockpile";
            this.btnSendSelectedStockpile.Size = new System.Drawing.Size(426, 27);
            this.btnSendSelectedStockpile.TabIndex = 4;
            this.btnSendSelectedStockpile.Tag = "color:dark2";
            this.btnSendSelectedStockpile.Text = "Load Sequenced song from File";
            this.btnSendSelectedStockpile.UseVisualStyleBackColor = false;
            this.btnSendSelectedStockpile.Click += new System.EventHandler(this.btnSendSelectedStockpile_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 60);
            this.label5.MinimumSize = new System.Drawing.Size(0, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 89);
            this.label5.TabIndex = 12;
            this.label5.Text = "This plugin can load various sequenced music format and prepare the Glitch Harves" +
    "ter for corrupting. \n\nFormats supported: SPC, NSF";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "Sequence Loader";
            // 
            // lbDragAndDropGH
            // 
            this.lbDragAndDropGH.AllowDrop = true;
            this.lbDragAndDropGH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDragAndDropGH.BackColor = System.Drawing.Color.Transparent;
            this.lbDragAndDropGH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDragAndDropGH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbDragAndDropGH.ForeColor = System.Drawing.Color.White;
            this.lbDragAndDropGH.Location = new System.Drawing.Point(264, 20);
            this.lbDragAndDropGH.Name = "lbDragAndDropGH";
            this.lbDragAndDropGH.Size = new System.Drawing.Size(172, 91);
            this.lbDragAndDropGH.TabIndex = 39;
            this.lbDragAndDropGH.Tag = "color:light3";
            this.lbDragAndDropGH.Text = "Drag and drop file to Load in the emulator and make a glitch harvester savestate";
            this.lbDragAndDropGH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDragAndDropGH.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbDragAndDropGH_DragDrop);
            this.lbDragAndDropGH.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbDragAndDropGH_DragEnter);
            // 
            // btnNSFNextSong
            // 
            this.btnNSFNextSong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNSFNextSong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnNSFNextSong.FlatAppearance.BorderSize = 0;
            this.btnNSFNextSong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNSFNextSong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNSFNextSong.ForeColor = System.Drawing.Color.White;
            this.btnNSFNextSong.Location = new System.Drawing.Point(264, 122);
            this.btnNSFNextSong.Name = "btnNSFNextSong";
            this.btnNSFNextSong.Size = new System.Drawing.Size(174, 27);
            this.btnNSFNextSong.TabIndex = 40;
            this.btnNSFNextSong.Tag = "color:dark2";
            this.btnNSFNextSong.Text = "NSF : Load Next Song";
            this.btnNSFNextSong.UseVisualStyleBackColor = false;
            this.btnNSFNextSong.Visible = false;
            this.btnNSFNextSong.Click += new System.EventHandler(this.btnNSFNextSong_Click);
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version.ForeColor = System.Drawing.Color.White;
            this.version.Location = new System.Drawing.Point(190, 35);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(14, 13);
            this.version.TabIndex = 41;
            this.version.Text = "v";
            // 
            // PluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(450, 250);
            this.Controls.Add(this.version);
            this.Controls.Add(this.btnNSFNextSong);
            this.Controls.Add(this.lbDragAndDropGH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSendSelectedStockpile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(390, 250);
            this.Name = "PluginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "color:dark1";
            this.Text = "Plugin Form";
            this.Load += new System.EventHandler(this.PluginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PluginForm_Load(object sender, EventArgs e)
        {
            setDllDir();
        }

        public string setDllDir()
        {
            //get the full location of the assembly with DaoTests in it
            string fullPath = System.Reflection.Assembly.GetAssembly(typeof(SEQUENCELOADER)).Location;

            //get the folder that's in
            dlldir = Path.GetDirectoryName(fullPath);
            return dlldir;

        }

        private void btnSendSelectedStockpile_Click(object sender, EventArgs e)
        {
            string path;

            OpenFileDialog OpenFileDialog1;
            OpenFileDialog1 = new OpenFileDialog();

            OpenFileDialog1.DefaultExt = "*";
            OpenFileDialog1.Title = "Open a File";
            OpenFileDialog1.Filter = "Any File|*.*";
            OpenFileDialog1.RestoreDirectory = true;
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = OpenFileDialog1.FileName;
            }
            else
                return;



            LoadFile(path);

        }

        #endregion
        private System.Windows.Forms.Button btnSendSelectedStockpile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbDragAndDropGH;
        private string dlldir;
        private Button btnNSFNextSong;
        private Label version;
    }
}
