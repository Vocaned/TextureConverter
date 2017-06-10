using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace TextureConverter
{
    public partial class Form1 : Form
    {
        public static bool alwaysLog = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            bk.Text = openFileDialog1.FileName;
        }

        private void monoFlat_Button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void monoFlat_Button3_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void monoFlat_Button4_Click(object sender, EventArgs e)
        {
            openFileDialog3.ShowDialog();
        }

        private void monoFlat_Button5_Click(object sender, EventArgs e)
        {
            openFileDialog4.ShowDialog();
        }

        private void monoFlat_Button6_Click(object sender, EventArgs e)
        {
            openFileDialog5.ShowDialog();
        }

        private void monoFlat_Button7_Click(object sender, EventArgs e)
        {
            openFileDialog6.ShowDialog();

        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            dn.Text = openFileDialog2.FileName;
        }

        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {
            ft.Text = openFileDialog3.FileName;
        }

        private void openFileDialog4_FileOk(object sender, CancelEventArgs e)
        {
            lf.Text = openFileDialog4.FileName;
        }

        private void openFileDialog5_FileOk(object sender, CancelEventArgs e)
        {
            rt.Text = openFileDialog5.FileName;
        }

        private void openFileDialog6_FileOk(object sender, CancelEventArgs e)
        {
            up.Text = openFileDialog6.FileName;
        }

        private void monoFlat_Button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void monoFlat_Button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is still work in progress");
        }

        private void monoFlat_SocialButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Fam0r/TextureConverter/");
        }

        private void monoFlat_HeaderLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Fam0r/TextureConverter/");
        }

        private void monoFlat_SocialButton2_Click(object sender, EventArgs e)
        {
            Options opt = new Options();
            opt.Show();
        }

        private void monoFlat_HeaderLabel1_Click(object sender, EventArgs e)
        {
            Options opt = new Options();
            opt.Show();
        }

        private void monoFlat_Button8_Click(object sender, EventArgs e)
        {
            try {
                if (!File.Exists(bk.Text)) throw new FileNotFoundException("Back texture doesnt exist!");
                if (!File.Exists(dn.Text)) throw new FileNotFoundException("Down texture doesnt exist!");
                if (!File.Exists(lf.Text)) throw new FileNotFoundException("Left texture doesnt exist!");
                if (!File.Exists(rt.Text)) throw new FileNotFoundException("Right texture doesnt exist!");
                if (!File.Exists(up.Text)) throw new FileNotFoundException("Up texture doesnt exist!");
                if (!File.Exists(ft.Text)) throw new FileNotFoundException("Forward texture doesnt exist!");
            } catch (Exception ee) {
                notify("error", ee.Message);
                return;
            }
            notify("notice", "Converting...");
            string[] files = {
                bk.Text,
                dn.Text,
                ft.Text,
                lf.Text,
                rt.Text,
                up.Text
            };
            if (ConvertCSS.Convert(files)) notify("success", "Skybox successfully converted to " + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output"));
            else notify("error", "Something went wrong while converting skybox! A log file has been written to " + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt"));
        }

        public void notify(string type, string text)
        {
            if (type == "clear") { monoFlat_NotificationBox1.Visible = false; return; }
            else if (type == "notice") { monoFlat_NotificationBox1.Text = text; monoFlat_NotificationBox1.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Notice; }
            else if (type == "success") { monoFlat_NotificationBox1.Text = text; monoFlat_NotificationBox1.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Success; }
            else if (type == "warning") { monoFlat_NotificationBox1.Text = text; monoFlat_NotificationBox1.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Warning; }
            else if (type == "error") { monoFlat_NotificationBox1.Text = text; monoFlat_NotificationBox1.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Error; }

            monoFlat_NotificationBox1.Visible = true;
            return;
        }
    }
}
