using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace TextureConverter
{
    public partial class Options : Form
    {
        
        public Options()
        {
            InitializeComponent();
            if (Form1.alwaysLog) monoFlat_Toggle1.Toggled = true;
        }

        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.alwaysLog = monoFlat_Toggle1.Toggled;
        }
    }
}
