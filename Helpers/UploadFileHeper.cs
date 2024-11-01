using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace IBeauty.Helpers
{
    static class UploadFileHelper
    {
        public static string Image(string pathImages = "Images", bool generateName = true)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Title = "Selecione uma imagem";
                openFile.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png";

                if (openFile.ShowDialog() == true)
                {
                    return SaveImage(openFile, pathImages, generateName);
                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string SaveImage(OpenFileDialog openFileDialog, string pathImages, bool generateName)
        {

            string nameImg = openFileDialog.SafeFileName;

            if (generateName)
            {
                string extension = nameImg.Split('.')[1];
                nameImg = generateUUID() + "." + extension;
            }

            var projectPath = Directory.GetCurrentDirectory();
            var pathFile = projectPath.Substring(0, projectPath.Length - 9) + pathImages;

            string fileNamePath = $@"{pathFile}\{nameImg}";

            if (!Directory.Exists(pathFile))
            {
                Directory.CreateDirectory(pathFile);
            }

            if (File.Exists(fileNamePath))
            {
                File.Delete(fileNamePath);
            }

            File.Copy(openFileDialog.FileName, fileNamePath);

            return nameImg;
        }

        private static string generateUUID()
        {
            Guid myuuid = Guid.NewGuid();
            return myuuid.ToString();
        }

        public static BitmapImage LoadImage(string nameImg)
        {
            string pathImages = "Images";

            var projectPath = Directory.GetCurrentDirectory();
            var pathFile = projectPath.Substring(0, projectPath.Length - 9) + pathImages;

            return new BitmapImage(new Uri($@"{pathFile}\{nameImg}"));
        }
    }
}
