using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
namespace ImgText
{
    class Program
    {
        private const double WIDTH_OFFSET = 1.5;
        private const int MAXWIDTH = 250;

        [STAThread]
        static void Main(string[] args)
        {
            char[] _asciiTable = { '.', ',', ':', '+', '*', '?', '%', 'S', '#', '@' };
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images|*.bmp; *.png; *.jpg; *.JPEG"
            };
            Console.WriteLine(" Press enter to start");
            while (true)
            {
                Console.ReadLine();
               if(openFileDialog.ShowDialog()!=DialogResult.OK)
                
                    continue;
                Console.Clear();
                var bitmap = new Bitmap(openFileDialog.FileName);
                bitmap = ResizeBitmap(bitmap);
                bitmap.ToGrayscale();
                var converter = new BitmapToAsciConverter(bitmap);
                var rows = converter.Convert();
                foreach ( var item in rows)
                {
                    Console.WriteLine(item);
                    File.WriteAllLines("image.txt", rows.Select(r => new string(r)));
                }
                Console.SetCursorPosition(0, 0);
            }
        }
        private static Bitmap ResizeBitmap (Bitmap bitmap)
        {
            
            var maxHeight = bitmap.Height / WIDTH_OFFSET * MAXWIDTH / bitmap.Width;
            if (bitmap.Width> MAXWIDTH||bitmap.Height > maxHeight)
            {
                bitmap = new Bitmap(bitmap, new Size(MAXWIDTH, (int)maxHeight));
            }
            return bitmap;
        }
    }
}
