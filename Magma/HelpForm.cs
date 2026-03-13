using MagmaRokOn.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MagmaRokOn
{
    public partial class HelpForm : Form
    {
        private readonly string form_title;
        private readonly MainForm mMainForm;

        public HelpForm(MainForm form, string title, string help_message)
        {
            InitializeComponent();
            mMainForm = form;

            if (File.Exists(Application.StartupPath + "\\readme.txt"))
            {
                btnReadMe.Visible = true;
            }

            switch (mMainForm.ActiveSkin)
            {
                case "custom":
                    SkinDefaults();
                    SkinButtonStyles(mMainForm.SkinButtonStyle);
                    SkinButtonText(mMainForm.SkinButtonTextColor);
                    btnClose.BackColor = mMainForm.SkinButtonBackgroundColor;
                    btnReadMe.BackColor = mMainForm.SkinButtonBackgroundColor;
                    break;
            }

            form_title = title;
            txtHelp.Text = help_message;
        }
        
        private void SkinDefaults()
        {
            BackgroundImage = mMainForm.SkinBackgroundImage;
            BackColor = mMainForm.SkinFormBackgroundColor;

            btnClose.BackgroundImage = null;
            btnReadMe.BackgroundImage = null;

            txtHelp.BackColor = mMainForm.SkinTextBoxBackgroundColor;
            txtHelp.ForeColor = mMainForm.SkinTextBoxTextColor;
        }

        private void SkinButtonStyles(FlatStyle style)
        {
            btnClose.FlatStyle = style;
            btnReadMe.FlatStyle = style;
        }

        private void SkinButtonText(Color color)
        {
            btnClose.ForeColor = color;
            btnReadMe.ForeColor = color;
        }

        private void HelpForm_Shown(object sender, EventArgs e)
        {
            Text = form_title;
        }

        private void txtHelp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Close();
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                txtHelp.SelectAll();
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                Clipboard.SetText(txtHelp.Text);
            }
        }

        private void HelpForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Close();
            }
        }

        private void txtHelp_DoubleClick(object sender, EventArgs e)
        {
            txtHelp.SelectAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReadMe_Click(object sender, EventArgs e)
        {

            Process.Start(Application.StartupPath + "\\readme.txt");
        }
    }
}
