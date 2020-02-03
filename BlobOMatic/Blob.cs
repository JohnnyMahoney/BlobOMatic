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
        public Ellipse EllipseAktiv { get; } = new Ellipse { Width = 100, Height = 100, Stroke = Brushes.Black, Fill = Brushes.DarkGray };
        public Ellipse EllipseInaktiv { get; } = new Ellipse { Width = 100, Height = 100, Stroke = Brushes.Black, Fill = Brushes.Gray };
        public Ellipse EllipseAusgewählt { get; } = new Ellipse { Width = 100, Height = 100, Stroke = Brushes.Black, Fill = Brushes.Red };
        public int Value { get; set; }
        public bool Aktiv { get; set; }
        public TextBlock TextBlock { get; set; }

        public Blob()
        {
            Value = 0;
            Aktiv = false;

            TextBlock = new TextBlock
            {
                Text = Value.ToString(),
                FontSize = 25,
                Background = new VisualBrush { Visual = EllipseAktiv },
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
            if (!this.Aktiv)
            {
                this.Aktiv = true;
                this.TextBlock.Background = new VisualBrush(EllipseAusgewählt);
                MainWindow.CheckValue(this);
            }
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!this.Aktiv)
            {
                this.TextBlock.Background = new VisualBrush(EllipseAktiv); 
            }
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!this.Aktiv)
            {
                this.TextBlock.Background = new VisualBrush(EllipseInaktiv); 
            }
        }




    }
}
