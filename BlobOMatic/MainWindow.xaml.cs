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
        public static Blob[,] blobs;
        public static int x;
        public static int y;

        public MainWindow()
        {
            InitializeComponent();

            x = (int)mainCanvas.Width / 100;
            y = (int)mainCanvas.Height / 100;

            CreateEmptyBlobs(out blobs);
        }

        void CreateEmptyBlobs(out Blob[,] blobs)
        {
            blobs = new Blob[y, x];

            for (int row = 0; row < y; row++)
            {
                for (int column = 0; column < x; column++)
                {
                    Blob _ = new Blob();

                    blobs[row, column] = _;
                    mainCanvas.Children.Add(_.TextBlock);
                    Canvas.SetTop(_.TextBlock, row * 100);
                    Canvas.SetLeft(_.TextBlock, column * 100);

                }
            }

        }
        public static void CheckValue(Blob blob)
        {
            int currentRow = 0;
            int currentColumn = 0;

            for (int row = 0; row < y; row++)
            {
                var _ = false;
                for (int column = 0; column < x; column++)
                {
                    if (blobs[row,column] == blob)
                    {
                        currentRow = row;
                        currentColumn = column;
                        _ = true;
                        break;
                    }
                }
                if (_)
                {
                    break;
                }
            }

        }
    }

}
