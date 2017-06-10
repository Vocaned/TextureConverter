using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace TextureConverter
{
    class ConvertCSS
    {
        public static void Convert(string[] files)
        {
            Debug.WriteLine("Converting " + files[0]);
            ProcessStartInfo info = new ProcessStartInfo();
            info.CreateNoWindow = false;
            info.UseShellExecute = true;
            info.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string VTFCmd = Path.Combine(info.WorkingDirectory, Path.Combine("vtflib", "VTFCmd.exe"));
            string output = Path.Combine(info.WorkingDirectory, "temp");

            info.FileName = "cmd"; info.Arguments = "/C " + VTFCmd + " -file \"" + files[0] + "\" -output \"" + output + "\" -exportformat \"png\"";
            var process = Process.Start(info);
            process.WaitForExit();

            info.FileName = "cmd"; info.Arguments = "/C " + VTFCmd + " -file \"" + files[1] + "\" -output \"" + output + "\" -exportformat \"png\"";
            process = Process.Start(info);
            process.WaitForExit();

            info.FileName = "cmd"; info.Arguments = "/C " + VTFCmd + " -file \"" + files[2] + "\" -output \"" + output + "\" -exportformat \"png\"";
            process = Process.Start(info);
            process.WaitForExit();

            info.FileName = "cmd"; info.Arguments = "/C " + VTFCmd + " -file \"" + files[3] + "\" -output \"" + output + "\" -exportformat \"png\"";
            process = Process.Start(info);
            process.WaitForExit();

            info.FileName = "cmd"; info.Arguments = "/C " + VTFCmd + " -file \"" + files[4] + "\" -output \"" + output + "\" -exportformat \"png\"";
            process = Process.Start(info);
            process.WaitForExit();

            info.FileName = "cmd"; info.Arguments = "/C " + VTFCmd + " -file \"" + files[5] + "\" -output \"" + output + "\" -exportformat \"png\"";
            process = Process.Start(info);
            process.WaitForExit();
            

            /*Bitmap bk = new Bitmap(Path.Combine(output, Path.ChangeExtension(files[0], null)));
            Bitmap dn = new Bitmap(Path.Combine(output, Path.GetFileNameWithoutExtension(files[1])));
            Bitmap ft = new Bitmap(Path.Combine(output, Path.GetFileNameWithoutExtension(files[2])));
            Bitmap lf = new Bitmap(Path.Combine(output, Path.GetFileNameWithoutExtension(files[3])));
            Bitmap rt = new Bitmap(Path.Combine(output, Path.GetFileNameWithoutExtension(files[4])));
            Bitmap up = new Bitmap(Path.Combine(output, Path.GetFileNameWithoutExtension(files[5])));*/


            string[] newfiles = {
                Path.Combine(output, Path.GetFileNameWithoutExtension(files[0])) + ".png",
                Path.Combine(output, Path.GetFileNameWithoutExtension(files[1])) + ".png",
                Path.Combine(output, Path.GetFileNameWithoutExtension(files[2])) + ".png",
                Path.Combine(output, Path.GetFileNameWithoutExtension(files[3])) + ".png",
                Path.Combine(output, Path.GetFileNameWithoutExtension(files[4])) + ".png",
                Path.Combine(output, Path.GetFileNameWithoutExtension(files[5])) + ".png"
            };
            Debug.WriteLine(newfiles[0]);
            Bitmap outp = CombineBitmap(newfiles);
            outp.Save(Path.Combine(output, "output.png"));
            outp.Dispose();
        }


        public static Bitmap CombineBitmap(string[] files)
        {


            //read all images into memory
            List<Bitmap> images = new List<Bitmap>();
            Bitmap finalImage = null;

            try {
                int width = 0;
                int height = 0;

                foreach (string image in files) {
                    //create a Bitmap from the file and add it to the list
                    Bitmap bitmap = new Bitmap(image);

                    //update the size of the final bitmap
                    width = bitmap.Width * 4;
                    height = bitmap.Height * 2;

                    images.Add(bitmap);
                }



                //create a bitmap to hold the combined image
                finalImage = new Bitmap(width, height);

                //get a graphics object from the image so we can draw on it
                using (Graphics g = Graphics.FromImage(finalImage)) {
                    //set background color
                    g.Clear(Color.Fuchsia);

                    //go through each image and draw it on the final image
                    images[5].RotateFlip(RotateFlipType.Rotate90FlipXY);
                    images[1].RotateFlip(RotateFlipType.Rotate270FlipX);
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
                //Delete files here
                foreach (string path in files) {
                    File.Delete(path);
                }
            }
        }
    }
}
