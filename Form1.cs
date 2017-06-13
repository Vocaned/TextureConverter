using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace TextureConverter
{
    public partial class Form1 : Form
    {
        public static bool alwaysLog = false;
        public static bool advanced = false;
        string mode = "none";
        int i = 0;
        Bitmap bk;
        Bitmap dn;
        Bitmap ft;
        Bitmap lf;
        Bitmap rt;
        Bitmap up;
        public static RotateFlipType rotmodetop = RotateFlipType.RotateNoneFlipNone;
        public static RotateFlipType rotmodebottom = RotateFlipType.RotateNoneFlipNone;

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
            css_bk.Text = openFileDialog1.FileName;
        }

        private void monoFlat_Button2_Click(object sender, EventArgs e)
        {
            if (mode == "css") {
                openFileDialog1.ShowDialog();
            } else {
                i = 2;
                openFileDialog7.ShowDialog();
            }
        }

        private void monoFlat_Button3_Click(object sender, EventArgs e)
        {
            if (mode == "css") {
                openFileDialog2.ShowDialog();
            } else {
                i = 3;
                openFileDialog7.ShowDialog();
            }
        }

        private void monoFlat_Button4_Click(object sender, EventArgs e)
        {
            if (mode == "css") {
                openFileDialog3.ShowDialog();
            } else {
                i = 4;
                openFileDialog7.ShowDialog();
            }
        }

        private void monoFlat_Button5_Click(object sender, EventArgs e)
        {
            if (mode == "css") {
                openFileDialog4.ShowDialog();
            } else {
                i = 5;
                openFileDialog7.ShowDialog();
            }
        }

        private void monoFlat_Button6_Click(object sender, EventArgs e)
        {
            if (mode == "css") {
                openFileDialog5.ShowDialog();
            } else {
                i = 6;
                openFileDialog7.ShowDialog();
            }
        }

        private void monoFlat_Button7_Click(object sender, EventArgs e)
        {
            if (mode == "css") {
                openFileDialog6.ShowDialog();
            } else {
                i = 7;
                openFileDialog7.ShowDialog();
            }

        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            css_dn.Text = openFileDialog2.FileName;
        }

        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {
            css_ft.Text = openFileDialog3.FileName;
        }

        private void openFileDialog4_FileOk(object sender, CancelEventArgs e)
        {
            css_lf.Text = openFileDialog4.FileName;
        }

        private void openFileDialog5_FileOk(object sender, CancelEventArgs e)
        {
            css_rt.Text = openFileDialog5.FileName;
        }

        private void openFileDialog6_FileOk(object sender, CancelEventArgs e)
        {
            css_up.Text = openFileDialog6.FileName;
        }

        private void openFileDialog7_FileOk(object sender, CancelEventArgs e)
        {
            Bitmap file7;
            if (Path.GetExtension(openFileDialog7.FileName) == ".tga") {
                file7 = new Bitmap(Paloma.TargaImage.LoadTargaImage(openFileDialog7.FileName));
            } else {
                file7 = new Bitmap(openFileDialog7.FileName);
            }

            if(file7 == null) {
                notify("error", "Could not open " + openFileDialog7.FileName);
            } else if (file7.Width != file7.Height) {
                notify("error", "Invalid skybox part! (Image must be a square)");
                file7.Dispose();
            } else {
                if (i == 2) {
                    css_bk.Text = openFileDialog7.FileName;
                    bk = new Bitmap(file7);
                    panel2.BackgroundImage = bk;
                } else if (i == 3) {
                    css_dn.Text = openFileDialog7.FileName;
                    dn = new Bitmap(file7);
                    panel6.BackgroundImage = dn;
                } else if (i == 4) {
                    css_ft.Text = openFileDialog7.FileName;
                    ft = new Bitmap(file7);
                    panel4.BackgroundImage = ft;
                } else if (i == 5) {
                    css_lf.Text = openFileDialog7.FileName;
                    lf = new Bitmap(file7);
                    panel1.BackgroundImage = lf;
                } else if (i == 6) {
                    css_rt.Text = openFileDialog7.FileName;
                    rt = new Bitmap(file7);
                    panel3.BackgroundImage = rt;
                } else if (i == 7) {
                    css_up.Text = openFileDialog7.FileName;
                    up = new Bitmap(file7);
                    panel5.BackgroundImage = up;
                } else {
                    notify("error", "Invalid index, please try again.");
                }

                file7.Dispose();
            }
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

        private void monoFlat_Button11_Click(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region index spam
            if (comboBox2.SelectedIndex == 0) rotmodetop = RotateFlipType.RotateNoneFlipNone;
            else if (comboBox2.SelectedIndex == 1) rotmodetop = RotateFlipType.Rotate180FlipNone;
            else if (comboBox2.SelectedIndex == 2) rotmodetop = RotateFlipType.Rotate180FlipX;
            else if (comboBox2.SelectedIndex == 3) rotmodetop = RotateFlipType.Rotate180FlipXY;
            else if (comboBox2.SelectedIndex == 4) rotmodetop = RotateFlipType.Rotate180FlipY;
            else if (comboBox2.SelectedIndex == 5) rotmodetop = RotateFlipType.Rotate270FlipNone;
            else if (comboBox2.SelectedIndex == 6) rotmodetop = RotateFlipType.Rotate270FlipX;
            else if (comboBox2.SelectedIndex == 7) rotmodetop = RotateFlipType.Rotate270FlipXY;
            else if (comboBox2.SelectedIndex == 8) rotmodetop = RotateFlipType.Rotate270FlipY;
            else if (comboBox2.SelectedIndex == 9) rotmodetop = RotateFlipType.Rotate90FlipNone;
            else if (comboBox2.SelectedIndex == 10) rotmodetop = RotateFlipType.Rotate90FlipX;
            else if (comboBox2.SelectedIndex == 11) rotmodetop = RotateFlipType.Rotate90FlipXY;
            else if (comboBox2.SelectedIndex == 12) rotmodetop = RotateFlipType.Rotate90FlipY;
            else if (comboBox2.SelectedIndex == 13) rotmodetop = RotateFlipType.RotateNoneFlipX;
            else if (comboBox2.SelectedIndex == 14) rotmodetop = RotateFlipType.RotateNoneFlipXY;
            else if (comboBox2.SelectedIndex == 15) rotmodetop = RotateFlipType.RotateNoneFlipY;
            #endregion
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region index spam
            if (comboBox3.SelectedIndex == 0) rotmodebottom = RotateFlipType.RotateNoneFlipNone;
            else if (comboBox3.SelectedIndex == 1) rotmodebottom = RotateFlipType.Rotate180FlipNone;
            else if (comboBox3.SelectedIndex == 2) rotmodebottom = RotateFlipType.Rotate180FlipX;
            else if (comboBox3.SelectedIndex == 3) rotmodebottom = RotateFlipType.Rotate180FlipXY;
            else if (comboBox3.SelectedIndex == 4) rotmodebottom = RotateFlipType.Rotate180FlipY;
            else if (comboBox3.SelectedIndex == 5) rotmodebottom = RotateFlipType.Rotate270FlipNone;
            else if (comboBox3.SelectedIndex == 6) rotmodebottom = RotateFlipType.Rotate270FlipX;
            else if (comboBox3.SelectedIndex == 7) rotmodebottom = RotateFlipType.Rotate270FlipXY;
            else if (comboBox3.SelectedIndex == 8) rotmodebottom = RotateFlipType.Rotate270FlipY;
            else if (comboBox3.SelectedIndex == 9) rotmodebottom = RotateFlipType.Rotate90FlipNone;
            else if (comboBox3.SelectedIndex == 10) rotmodebottom = RotateFlipType.Rotate90FlipX;
            else if (comboBox3.SelectedIndex == 11) rotmodebottom = RotateFlipType.Rotate90FlipXY;
            else if (comboBox3.SelectedIndex == 12) rotmodebottom = RotateFlipType.Rotate90FlipY;
            else if (comboBox3.SelectedIndex == 13) rotmodebottom = RotateFlipType.RotateNoneFlipX;
            else if (comboBox3.SelectedIndex == 14) rotmodebottom = RotateFlipType.RotateNoneFlipXY;
            else if (comboBox3.SelectedIndex == 15) rotmodebottom = RotateFlipType.RotateNoneFlipY;
            #endregion
        }

        private void monoFlat_Button8_Click(object sender, EventArgs e)
        {
            #region Strings
            string bk2;
            string dn2;
            string lf2;
            string rt2;
            string up2;
            string ft2;
            #endregion

            if (mode == "css") {
                bk2 = css_bk.Text;
                dn2 = css_dn.Text;
                lf2 = css_lf.Text;
                rt2 = css_rt.Text;
                up2 = css_up.Text;
                ft2 = css_ft.Text;
            } else if (mode == "3x2") {
                //3x2
                return;
            } else if (mode == "custom") {
                if (File.Exists(monoFlat_TextBox1.Text)) {
                    //3x2
                    return;
                } else {
                    bk2 = css_bk.Text;
                    dn2 = css_dn.Text;
                    lf2 = css_lf.Text;
                    rt2 = css_rt.Text;
                    up2 = css_up.Text;
                    ft2 = css_ft.Text;
            }} else {
                notify("error", "Please select a valid preset");
                return;
            }

            try {
                if (!File.Exists(bk2)) throw new FileNotFoundException("Back texture doesnt exist!");
                if (!File.Exists(dn2)) throw new FileNotFoundException("Down texture doesnt exist!");
                if (!File.Exists(lf2)) throw new FileNotFoundException("Left texture doesnt exist!");
                if (!File.Exists(rt2)) throw new FileNotFoundException("Right texture doesnt exist!");
                if (!File.Exists(up2)) throw new FileNotFoundException("Up texture doesnt exist!");
                if (!File.Exists(ft2)) throw new FileNotFoundException("Front texture doesnt exist!");
            } catch (Exception ee) {
                notify("error", ee.Message);
                return;
            }
            notify("notice", "Converting...");
            string[] files = {
                bk2,
                dn2,
                ft2,
                lf2,
                rt2,
                up2
            };
            if (mode == "css") {
                if (ConvertCSS.Convert(files)) notify("success", "Skybox successfully converted to " + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output"));
                else notify("error", "Something went wrong while converting skybox! A log file has been written to " + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt"));
            } else {
                if (Convert.conv(files)) notify("success", "Skybox successfully converted to " + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output"));
                else notify("error", "Something went wrong while converting skybox! A log file has been written to " + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt"));
            }
        }

        public void notify(string type, string text)
        {
            if (type == "clear") { monoFlat_NotificationBox1.Visible = false; return; }
            else if (type == "notice") { monoFlat_NotificationBox1.Text = text; monoFlat_NotificationBox1.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Notice; }
            else if (type == "success") { monoFlat_NotificationBox1.Text = text; monoFlat_NotificationBox1.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Success; }
            else if (type == "warning") { monoFlat_NotificationBox1.Text = text; monoFlat_NotificationBox1.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Warning; }
            else if (type == "error") { monoFlat_NotificationBox1.Text = text; monoFlat_NotificationBox1.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Error; }

            ConvertCSS.Logger("Notify - " + type + " " + text);
            monoFlat_NotificationBox1.Visible = true;
            return;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1) {
                mode = "css";
                #region visible
                //right
                monoFlat_HeaderLabel3.Visible = true;
                monoFlat_Label2.Visible = true;
                monoFlat_Label3.Visible = true;
                monoFlat_Label4.Visible = true;
                monoFlat_Label5.Visible = true;
                monoFlat_Label6.Visible = true;
                monoFlat_Label7.Visible = true;
                css_bk.Visible = true;
                css_dn.Visible = true;
                css_lf.Visible = true;
                css_rt.Visible = true;
                css_up.Visible = true;
                css_ft.Visible = true;
                monoFlat_Button2.Visible = true;
                monoFlat_Button3.Visible = true;
                monoFlat_Button4.Visible = true;
                monoFlat_Button5.Visible = true;
                monoFlat_Button6.Visible = true;
                monoFlat_Button7.Visible = true;
                //or
                monoFlat_HeaderLabel4.Visible = false;
                //left
                monoFlat_TextBox1.Visible = false;
                monoFlat_Label8.Visible = false;
                monoFlat_Button11.Visible = false;
                //other
                comboBox2.SelectedIndex = 11;
                comboBox3.SelectedIndex = 6;
                //panels
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                #endregion
            } /*else if (comboBox1.SelectedIndex == 2) {
                mode = "3x2";
                #region visible
                //right
                monoFlat_HeaderLabel3.Visible = false;
                monoFlat_Label2.Visible = false;
                monoFlat_Label3.Visible = false;
                monoFlat_Label4.Visible = false;
                monoFlat_Label5.Visible = false;
                monoFlat_Label6.Visible = false;
                monoFlat_Label7.Visible = false;
                css_bk.Visible = false;
                css_dn.Visible = false;
                css_lf.Visible = false;
                css_rt.Visible = false;
                css_up.Visible = false;
                css_ft.Visible = false;
                monoFlat_Button2.Visible = false;
                monoFlat_Button3.Visible = false;
                monoFlat_Button4.Visible = false;
                monoFlat_Button5.Visible = false;
                monoFlat_Button6.Visible = false;
                monoFlat_Button7.Visible = false;
                //or
                monoFlat_HeaderLabel4.Visible = false;
                //left
                monoFlat_TextBox1.Visible = true;
                monoFlat_Label8.Visible = true;
                monoFlat_Button11.Visible = true;
                #endregion
            }*/ else if (comboBox1.SelectedIndex == 2) {
                mode = "custom";
                #region visible
                //right
                monoFlat_HeaderLabel3.Visible = false;
                monoFlat_Label2.Visible = true;
                monoFlat_Label3.Visible = true;
                monoFlat_Label4.Visible = true;
                monoFlat_Label5.Visible = true;
                monoFlat_Label6.Visible = true;
                monoFlat_Label7.Visible = true;
                css_bk.Visible = true;
                css_dn.Visible = true;
                css_lf.Visible = true;
                css_rt.Visible = true;
                css_up.Visible = true;
                css_ft.Visible = true;
                monoFlat_Button2.Visible = true;
                monoFlat_Button3.Visible = true;
                monoFlat_Button4.Visible = true;
                monoFlat_Button5.Visible = true;
                monoFlat_Button6.Visible = true;
                monoFlat_Button7.Visible = true;
                //or
                monoFlat_HeaderLabel4.Visible = true;
                //left
                monoFlat_TextBox1.Visible = true;
                monoFlat_Label8.Visible = true; ;
                monoFlat_Button11.Visible = true;
                //other
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                //panels
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                #endregion
            } else {
                mode = "none";
                #region visible
                //right
                monoFlat_HeaderLabel3.Visible = false;
                monoFlat_Label2.Visible = false;
                monoFlat_Label3.Visible = false;
                monoFlat_Label4.Visible = false;
                monoFlat_Label5.Visible = false;
                monoFlat_Label6.Visible = false;
                monoFlat_Label7.Visible = false;
                css_bk.Visible = false;
                css_dn.Visible = false;
                css_lf.Visible = false;
                css_rt.Visible = false;
                css_up.Visible = false;
                css_ft.Visible = false;
                monoFlat_Button2.Visible = false;
                monoFlat_Button3.Visible = false;
                monoFlat_Button4.Visible = false;
                monoFlat_Button5.Visible = false;
                monoFlat_Button6.Visible = false;
                monoFlat_Button7.Visible = false;
                //or
                monoFlat_HeaderLabel4.Visible = false;
                //left
                monoFlat_TextBox1.Visible = false;
                monoFlat_Label8.Visible = false;
                monoFlat_Button11.Visible = false;
                //panels
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                #endregion
            }

            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bk != null) bk.Dispose();
            if (dn != null) dn.Dispose();
            if (ft != null) ft.Dispose();
            if (lf != null) lf.Dispose();
            if (rt != null) rt.Dispose();
            if (up != null) up.Dispose();
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            if (advanced) {
                monoFlat_Label9.Visible = true;
                monoFlat_Label10.Visible = true;
                monoFlat_Label11.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
            } else {
                monoFlat_Label9.Visible = false;
                monoFlat_Label10.Visible = false;
                monoFlat_Label11.Visible = false;
                comboBox2.Visible = false;
                comboBox3.Visible = false;
            }
        }
    }
}
