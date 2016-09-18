using Popthatpill.Droid;
using Xamarin.Forms;
using System.IO;
using System;
using Xamarin.Forms.Platform.Android;
using Foundation;
using Android.Content;

[assembly: Dependency(typeof(CameraImages_Android))]
namespace Popthatpill.Droid
{
    class CameraImages_Android : ICameraImages
    {
        public Context Context { get; private set; }

        public async void SavePictureToDisk(ImageSource imgSrc, string Id)
        {
           /* var _filename = Id;
            if (_filename.ToLower().Contains(".jpg") || _filename.ToLower().Contains(".png"))
            {

                var renderer = new StreamImagesourceHandler();
                var photo = await renderer.LoadImageAsync(imgSrc, this.Context);
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

            }*/


        }

        public string GetPictureFromDisk(string id)
        {
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string jpgFilename = Path.Combine(documentsDirectory, id.ToString() + ".jpg");
            return jpgFilename;
        }

    }
}