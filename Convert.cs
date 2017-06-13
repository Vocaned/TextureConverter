using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace TextureConverter
{
    class Convert
    {
        public static bool conv(string[] files)
        {
            try {

                string outputFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");
                if (!Directory.Exists(outputFolder)) Directory.CreateDirectory(outputFolder);
                ConvertCSS.Logger("Started converting files");

                string[] newfiles = new string[6];
                int index = 0;

                string[] fil = Directory.GetFiles(outputFolder, "tmp*", SearchOption.TopDirectoryOnly);
                if (files.Length > 0) {
                    foreach (string file in fil) {
                        File.Delete(file);
                    }
                }

                foreach (string filePath in files) {
                    ConvertCSS.Logger("Adding " + filePath + " to newfiles[" + index + "]");
                    File.Copy(filePath, Path.Combine(outputFolder, "tmp" + index + Path.GetExtension(filePath)));

                    newfiles[index] = Path.Combine(outputFolder, "tmp" + index + Path.GetExtension(filePath));
                    index++;
                }
                ConvertCSS.Logger(newfiles[0]);
                Bitmap outp = ConvertCSS.CombineBitmap(newfiles, Form1.rotmodetop, Form1.rotmodebottom);
                ConvertCSS.Logger("Converted files, saving skybox.png");

                string output = Path.Combine(outputFolder, "skybox.png");

                for (int i = 0; i < 300; i++) {
                    if (!File.Exists(output)) {
                        //There are probably better ways to do this, but atleast it works ¯\_(ツ)_/¯
                        i = 400;
                    } else if (!File.Exists(Path.Combine(outputFolder, "skybox (" + i + ").png")) && i > 1) {
                        output = Path.Combine(outputFolder, "skybox (" + i + ").png");
                        i = 400;
                    }
                }

                outp.Save(output);
                ConvertCSS.Logger("Saved skybox to " + output);
                if (Form1.alwaysLog) File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt"), ConvertCSS.logs);
                outp.Dispose();
                return true;
            } catch (Exception e) {
                ConvertCSS.Logger("Program crashed!!!" + Environment.NewLine + e + Environment.NewLine + "Files:" + files[0] + " " + files[1] + " " + files[2] + " " + files[3] + " " + files[4] + " " + files[5] + Environment.NewLine);
                File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt"), ConvertCSS.logs);
                return false;
            }
        }
    }
}
