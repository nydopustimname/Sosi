﻿using System.Drawing;

namespace ii_dinahyi_
{
    public class ObjToAnother
    {
        public static Bitmap GetBitmapFromArr(double[,] array, int lvl)
        {
            Bitmap bitmap = new Bitmap(array.GetLength(1), array.GetLength(0));
            Color c;
            for (int x = 0; x < array.GetLength(1); x++)
            {
                for (int y = 0; y < array.GetLength(0); y++)
                {
                    c = array[y, x] < lvl ? Color.Black : Color.White;
                    bitmap.SetPixel(x, y, c);
                }
            }
            return bitmap;
        }

        public static double[,] GetArrFromBMP(Bitmap im)
        {
            double[,] arr = new double[im.Width, im.Height];
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    int color = (im.GetPixel(i, j).R + im.GetPixel(i, j).G + im.GetPixel(i, j).B) / 3;
                    arr[i, j] = color > 0 ? 1 : 0;
                }
            }
            return arr;
        }
    }
}
