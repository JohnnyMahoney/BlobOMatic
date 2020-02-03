using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BlobOMatic
{
    class Blob
    {
        public Ellipse Ellipse { get; set; }
        public int Value { get; set; }
        public bool Aktiv { get; set; }


        public Blob()
        {
            Value = 0;
            Aktiv = false;
            Ellipse = new Ellipse
            {
                Width = 100,
                Height = 100,
                Stroke = Brushes.Black,
                Fill = Brushes.LightGray
            };
        }

        
    }
}
