using Popthatpill.Droid;
using Xamarin.Forms;
using System.IO;
using System;

[assembly: Dependency(typeof(CameraImages_Android))]
namespace Popthatpill.Droid
{
    class CameraImages_Android : ICameraImages
    {
        public bool FileExists(string filename)
        {
            var filePath = GetFilePath(filename);
            return File.Exists(filePath);
        }

        public Stream GetReadStream(string filename)
        {
            var filePath = GetFilePath(filename);
            return File.OpenRead(filePath);
        }

        public Stream GetWriteStream(string filename)
        {
            var filePath = GetFilePath(filename);
            var stream = File.OpenWrite(filePath);
            return stream;
        }

        public string GetFilePath(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, filename);
        }
    }
}