using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgText
{
    public static class Extension
    {
        public static void ToGrayscale(this Bitmap bitmap)
        {
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    var pixel = bitmap.GetPixel(j, i);
                    int avg = (pixel.R + pixel.G + pixel.B) / 3;
                    bitmap.SetPixel(j, i, Color.FromArgb(pixel.A, avg, avg, avg));
                }
            }
        }
    }
}
