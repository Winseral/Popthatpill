using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popthatpill
{
    public interface ICameraImages
    {
        Stream GetWriteStream(string filename);
        Stream GetReadStream(string filename);
        bool FileExists(string filename);
    }
}
