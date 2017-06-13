using System;
using System.Windows.Forms;

namespace TextureConverter
{
    public partial class Options : Form
    {
        
        public Options()
        {
            InitializeComponent();
            if (Form1.alwaysLog) monoFlat_Toggle1.Toggled = true;
            if (Form1.advanced) monoFlat_Toggle2.Toggled = true;
        }

        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.alwaysLog = monoFlat_Toggle1.Toggled;
        }

        private void monoFlat_Toggle2_ToggledChanged()
        {
            Form1.advanced = monoFlat_Toggle2.Toggled;
        }
    }
}
