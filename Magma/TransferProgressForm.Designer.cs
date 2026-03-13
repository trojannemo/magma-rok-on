using System.ComponentModel;
using System.Windows.Forms;

namespace MagmaRokOn
{
    partial class TransferProgressForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components;
        private ProgressBar progressBar1;
        private Label LabelTitle;
        private Button transferCancelButton;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferProgressForm));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.transferCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 32);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(387, 13);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.ForeColor = System.Drawing.Color.Black;
            this.LabelTitle.Location = new System.Drawing.Point(12, 9);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(64, 13);
            this.LabelTitle.TabIndex = 1;
            this.LabelTitle.Text = "Searching...";
            // 
            // transferCancelButton
            // 
            this.transferCancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.transferCancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.transferCancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transferCancelButton.FlatAppearance.BorderSize = 0;
            this.transferCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transferCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transferCancelButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.transferCancelButton.Location = new System.Drawing.Point(324, 57);
            this.transferCancelButton.Name = "transferCancelButton";
            this.transferCancelButton.Size = new System.Drawing.Size(75, 23);
            this.transferCancelButton.TabIndex = 2;
            this.transferCancelButton.Text = "CANCEL";
            this.transferCancelButton.UseVisualStyleBackColor = false;
            this.transferCancelButton.Click += new System.EventHandler(this.transferCancelButton_Click);
            // 
            // TransferProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(411, 92);
            this.Controls.Add(this.transferCancelButton);
            this.Controls.Add(this.LabelTitle);
            this.Controls.Add(this.progressBar1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransferProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Searching for Xboxes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransferProgressForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}