using Foundation;
using Popthatpill.iOS;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(CameraImages_iOS))]
namespace Popthatpill.iOS
{
    public class CameraImages_iOS : ICameraImages
    {
        public string GetPictureFromDisk(string id)
        {
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string jpgFilename = Path.Combine(documentsDirectory, id.ToString() + ".jpg");
            return jpgFilename;
        }

        public async void SavePictureToDisk(ImageSource imgSrc, string Id)
        {
            var renderer = new StreamImagesourceHandler();
            var photo = await renderer.LoadImageAsync(imgSrc);
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string jpgFilename = Path.Combine(documentsDirectory, Id.ToString() + ".jpg");

            NSData imgData = photo.AsJPEG();

            NSError err = null;
            if (imgData.Save(jpgFilename, false, out err))
            {
                Console.WriteLine("saved as " + jpgFilename);
            }
            else
            {
                Console.WriteLine("NOT saved as " + jpgFilename + " because" + err.LocalizedDescription);
            }
        }
    }
}