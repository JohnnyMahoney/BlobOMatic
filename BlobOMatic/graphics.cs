using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlobOMatic
{
    static class graphics
    {
        public static void DrawCircles(Panel panel)
        {
            var sx = panel.Width;
            var sy = panel.Height;

            var deltax = 20;
            var deltay = 20;

            for (int i = 0; i < sx; i += deltax)
            {
                for (int j = 0; j < sy; j += deltay)
                {
                    System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                    System.Drawing.Graphics formGraphics;
                    formGraphics = panel.CreateGraphics();
                    formGraphics.DrawEllipse(new Pen(myBrush), i, j, deltax, deltay);
                    myBrush.Dispose();
                    formGraphics.Dispose();
                }
            }


        }
    }
}
