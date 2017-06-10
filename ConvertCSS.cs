using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Globalization;

namespace TextureConverter
{
    class ConvertCSS
    {
        static string logs;
        public static bool Convert(string[] files)
        {
            try {
                Logger("Started converting from .VTF to .png");
                ProcessStartInfo info = new ProcessStartInfo();
                info.CreateNoWindow = true;
                info.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;

                string VTFCmd = Path.Combine(info.WorkingDirectory, Path.Combine("vtflib", "VTFCmd.exe"));
                string outputFolder = Path.Combine(info.WorkingDirectory, "output");
                if (!Directory.Exists(outputFolder)) Directory.CreateDirectory(outputFolder);

                foreach (string file in files) {
                    Logger("Starting command cmd " + info.Arguments);
                    info.FileName = "cmd"; info.Arguments = "/C " + VTFCmd + " -file \"" + file + "\" -output \"" + outputFolder + "\" -exportformat \"png\"";
                    var process = Process.Start(info);
                    process.WaitForExit();
                    Logger("Finished command");
                }

                string[] newfiles = new string[6];
                int index = 0;

                foreach (string filePath in files) {
                    Logger("Adding " + filePath + " to newfiles[" + index + "]");
                    newfiles[index] = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(filePath)) + ".png";
                    Logger("Added " + filePath + " to newfiles[" + index + "]");
                    index++;
                }

                Logger("Started converting files");
                Bitmap outp = CombineBitmap(newfiles);
                Logger("Converted files, saving skybox.png");

                string output = Path.Combine(outputFolder, "skybox.png");

                for (int i = 0; i < 300; i++) {
                    if(!File.Exists(output)) {
                        //There are probably better ways to do this, but atleast it works ¯\_(ツ)_/¯
                        i = 400;
                    } else if (!File.Exists(Path.Combine(outputFolder, "skybox (" + i +  ").png")) && i > 1) {
                        output = Path.Combine(outputFolder, "skybox (" + i + ").png");
                        i = 400;
                    }
                }

                outp.Save(output);
                Logger("Saved skybox to " + output);
                if(Form1.alwaysLog) File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt"), logs);
                outp.Dispose();
                return true;

            } catch (Exception e) {
                Logger("Program crashed!!!" + Environment.NewLine + e + Environment.NewLine + Environment.NewLine);
                File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt"), logs);
                return false;
            }
        }

        public static void Logger(string text)
        {
            string sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentUICulture.DateTimeFormat.ShortTimePattern;
            logs += "[" + DateTime.Now.ToString(sysUIFormat) + "] " + text + Environment.NewLine;
            return;
        }

        public static Bitmap CombineBitmap(string[] files)
        {
            //read all images into memory
            List<Bitmap> images = new List<Bitmap>();
            Bitmap finalImage = null;

            try {
                int width;
                int height;

                foreach (string image in files) {
                    //create a Bitmap from the file and add it to the list
                    Bitmap bitmap = new Bitmap(image);
                    images.Add(bitmap);
                }

                //update the size of the final bitmap
                width = images[0].Width * 4;
                height = images[0].Height * 2;

                //create a bitmap to hold the combined image
                finalImage = new Bitmap(width, height);

                //get a graphics object from the image so we can draw on it
                using (Graphics g = Graphics.FromImage(finalImage)) {
                    //set background color
                    g.Clear(Color.Fuchsia);

                    //go through each image and draw it on the final image
                    images[5].RotateFlip(RotateFlipType.Rotate90FlipXY);
                    images[1].RotateFlip(RotateFlipType.Rotate270FlipX);

                    //Probably shouldn't hardcode these but whatever, I'll fix later if needed
                    g.DrawImage(images[5], new Rectangle(images[5].Width, 0, images[5].Width, images[5].Height));
                    g.DrawImage(images[1], new Rectangle(images[1].Width * 2, 0, images[1].Width, images[1].Height));
                    g.DrawImage(images[3], new Rectangle(0, images[3].Height, images[3].Width, images[3].Height));
                    g.DrawImage(images[0], new Rectangle(images[0].Width, images[0].Height, images[0].Width, images[0].Height));
                    g.DrawImage(images[4], new Rectangle(images[4].Width * 2, images[4].Height, images[4].Width, images[4].Height));
                    g.DrawImage(images[2], new Rectangle(images[2].Width * 2 + images[2].Width, images[2].Height, images[2].Width, images[2].Height));
                }

                return finalImage;
            } catch (Exception) {
                if (finalImage != null)
                    finalImage.Dispose();

                throw;
            } finally {
                //clean up memory
                foreach (Bitmap image in images) {
                    image.Dispose();
                }
                //Delete files
                foreach (string path in files) {
                    File.Delete(path);
                }
            }
        }
    }
}
