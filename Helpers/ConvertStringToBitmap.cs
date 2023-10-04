using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_XuatKhauGao.Helpers
{
    public class ConvertStringToBitmap
    {
        string image;
        public ConvertStringToBitmap()
        {
        }
        public ConvertStringToBitmap(string image)
        {
            this.image = image;
        }
        public static Bitmap convertToBitmap(string image)
        {
            byte[] imageBytes = Convert.FromBase64String(image);
            MemoryStream ms1 = new MemoryStream(imageBytes, 0,
              imageBytes.Length);
            // Convert byte[] to Image
            ms1.Write(imageBytes, 0, imageBytes.Length);
            Bitmap output1 = new Bitmap(ms1, false);
            ms1.Dispose();

            return output1;
        }
    }
}
