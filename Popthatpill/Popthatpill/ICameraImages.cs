﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Popthatpill
{
    public interface ICameraImages
    {
        void SavePictureToDisk(ImageSource imgSrc, string Id);

        string GetPictureFromDisk(string id);
    }
}
