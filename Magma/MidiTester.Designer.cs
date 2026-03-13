namespace MagmaRokOn
{
    partial class MidiTester
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MidiTester));
            this.btnClose = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnClipboard = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnCleaner = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.AutoSize = true;
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(511, 356);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtLog
            // 
            this.txtLog.AllowDrop = true;
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.SystemColors.Control;
            this.txtLog.Location = new System.Drawing.Point(12, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(556, 335);
            this.txtLog.TabIndex = 4;
            this.txtLog.Text = resources.GetString("txtLog.Text");
            this.txtLog.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtLog_DragDrop);
            this.txtLog.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtLog_DragEnter);
            // 
            // btnClipboard
            // 
            this.btnClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClipboard.AutoSize = true;
            this.btnClipboard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClipboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnClipboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClipboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClipboard.FlatAppearance.BorderSize = 0;
            this.btnClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClipboard.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClipboard.Location = new System.Drawing.Point(356, 356);
            this.btnClipboard.Name = "btnClipboard";
            this.btnClipboard.Size = new System.Drawing.Size(142, 23);
            this.btnClipboard.TabIndex = 5;
            this.btnClipboard.Text = "COPY TO CLIPBOARD";
            this.btnClipboard.UseVisualStyleBackColor = false;
            this.btnClipboard.Click += new System.EventHandler(this.btnClipboard_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.AutoSize = true;
            this.btnOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnOpen.Location = new System.Drawing.Point(12, 356);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(81, 23);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "OPEN MIDI";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCleaner
            // 
            this.btnCleaner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCleaner.AutoSize = true;
            this.btnCleaner.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCleaner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCleaner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCleaner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCleaner.FlatAppearance.BorderSize = 0;
            this.btnCleaner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCleaner.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCleaner.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCleaner.Location = new System.Drawing.Point(105, 356);
            this.btnCleaner.Name = "btnCleaner";
            this.btnCleaner.Size = new System.Drawing.Size(159, 23);
            this.btnCleaner.TabIndex = 7;
            this.btnCleaner.Text = "SEND TO MIDI CLEANER";
            this.btnCleaner.UseVisualStyleBackColor = false;
            this.btnCleaner.Visible = false;
            this.btnCleaner.Click += new System.EventHandler(this.btnCleaner_Click);
            // 
            // MidiTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(580, 388);
            this.Controls.Add(this.btnCleaner);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnClipboard);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtLog);
            this.ForeColor = System.Drawing.Color.LightGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MidiTester";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MIDI Tester 1.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MidiTester_FormClosing);
            this.Shown += new System.EventHandler(this.MidiTester_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnClipboard;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnCleaner;
    }
}