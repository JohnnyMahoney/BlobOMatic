using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BlobOMatic
{
    public class Blob
    {
        public Ellipse EllipseHover { get; } = new Ellipse { Width = 100, Height = 100, Stroke = Brushes.Black, Fill = Brushes.LightGray };
        public Ellipse EllipseInaktiv { get; } = new Ellipse { Width = 100, Height = 100, Stroke = Brushes.Black, Fill = Brushes.Gray };
        public Ellipse EllipseAktiv { get; } = new Ellipse { Width = 100, Height = 100, Stroke = Brushes.Black, Fill = Brushes.Red };
        int val;
        public int Value 
        {
            get { return val; }
            set { val = value; EventChanged(); }  
        }
        public bool Aktiv { get; set; }
        public TextBlock TextBlock { get; set; }
        public delegate void BlobEventHandler(Blob blob);
        public event BlobEventHandler ValueChanged;

        private void EventChanged()
        {
            if (ValueChanged != null)
                ValueChanged(this);
        }

        public Blob()
        {
            Aktiv = false;

            TextBlock = new TextBlock
            {
                Text = "",
                FontSize = 25,
                Background = new VisualBrush { Visual = EllipseInaktiv },
                Width = 100,
                Height = 100,
                TextAlignment = System.Windows.TextAlignment.Center,
                Padding = new System.Windows.Thickness(0, 30, 0, 0)
            };


            TextBlock.MouseEnter += TextBlock_MouseEnter;
            TextBlock.MouseLeave += TextBlock_MouseLeave;
            TextBlock.MouseDown += TextBlock_MouseDown;

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!Aktiv)
            {
                Aktiv = true;
                TextBlock.Background = new VisualBrush(EllipseAktiv);
                TextBlock.Text = "1";
                MainWindow.CheckValue();
                //MainWindow.BlobCheckValue(this);
                //ValueChanged += ValueChanged;
            }
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!this.Aktiv)
            {
                this.TextBlock.Background = new VisualBrush(EllipseInaktiv); 
            }
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!this.Aktiv)
            {
                this.TextBlock.Background = new VisualBrush(EllipseHover); 
            }
        }




    }
}
