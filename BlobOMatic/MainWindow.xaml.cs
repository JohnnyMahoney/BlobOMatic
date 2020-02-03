using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlobOMatic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int x = (int)mainCanvas.Width / 100;
            int y = (int)mainCanvas.Height / 100;

            CreateEmptyBlobs(x, y, out Blob[,] blobs);

        }

        void CreateEmptyBlobs(int cols, int rows, out Blob[,] blobs)
        {
            blobs = new Blob[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < cols; column++)
                {
                    Blob _ = new Blob();
                    
                    blobs[row, column] = _;

                    mainCanvas.Children.Add(_.Ellipse);
                    Canvas.SetTop(_.Ellipse, row * 100);
                    Canvas.SetLeft(_.Ellipse, column * 100);
                    
                }
            }

        }
    }
}
