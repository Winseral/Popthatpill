using Popthatpill.Droid;
using Xamarin.Forms;
using System.IO;
using System;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using Android.App;

[assembly: Dependency(typeof(CameraImages_Android))]
namespace Popthatpill.Droid
{
    class CameraImages_Android : ICameraImages
    {
        public Context Context { get; private set; }
       

        public async void SavePictureToDisk(ImageSource imgSrc, string Id)
        {
            var _filename = Id;
            if (_filename.ToLower().Contains(".jpg"))
            {

                var renderer = new StreamImagesourceHandler();
                var photo = await renderer.LoadImageAsync(imgSrc, Context);
                var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string jpgFilename = System.IO.Path.Combine(documentsDirectory, Id.ToString() + ".jpg");

                try
                {
                    using (var os = new FileStream(jpgFilename, FileMode.Create))
                    {
                        photo.Compress(Bitmap.CompressFormat.Jpeg, 100, os);
                    }
                }
                catch (Exception ex)
                {
                    Toast.MakeText(Context, "Error in save file Error Message - " + ex, ToastLength.Short).Show();
                }
            }
        }

        public string GetPictureFromDisk(string id)
        {
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string jpgFilename = System.IO.Path.Combine(documentsDirectory, id.ToString() + ".jpg");
            return jpgFilename;
        }

    }
}