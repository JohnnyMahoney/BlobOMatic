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
                    //_.ValueChanged += __ValueChanged;
                    blobs[row, column] = _;
                    mainCanvas.Children.Add(_.TextBlock);
                    Canvas.SetTop(_.TextBlock, row * 100);
                    Canvas.SetLeft(_.TextBlock, column * 100);

                }
            }

        }

        public static void CheckValue()
        {
            bool change = false;
            foreach (var blob in blobs)
            {
                // checke nur aktive blobs
                if (!blob.Aktiv)
                {
                    continue;
                }

                int currentRow = 0;
                int currentColumn = 0;
                var foundCurrentBlob = false;
                // get indices des aktuellen blobs
                for (int row = 0; row < y; row++)
                {
                    for (int column = 0; column < x; column++)
                    {
                        if (blobs[row, column] == blob)
                        {
                            currentRow = row;
                            currentColumn = column;
                            foundCurrentBlob = true;
                            break;
                        }
                    }
                    if (foundCurrentBlob)
                    {
                        break;
                    }
                }

                var tests = new List<bool>();
                var vals = new List<int>();

                int[] _row = new int[3] { currentRow - 1, currentRow, currentRow + 1 };
                int[] _col = new int[3] { currentColumn - 1, currentColumn, currentColumn + 1 };

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i == 1 && j == 1)
                        {
                            continue;
                        }
                        try
                        {
                            var _ = blobs[_row[i], _col[j]];

                            if (_.Aktiv)
                            {
                                tests.Add(int.Parse(_.TextBlock.Text) >= int.Parse(blobs[_row[1], _col[1]].TextBlock.Text));
                                vals.Add(int.Parse(_.TextBlock.Text));
                            }
                            else
                            {
                                tests.Add(false);
                                vals.Add(0);
                            }

                        }
                        catch (Exception)
                        {
                            tests.Add(false);
                            vals.Add(0);
                        }

                    }
                }

                if (!tests.Contains(false))
                {
                    var _ = vals.Min();
                    blob.TextBlock.Text = (_ + 1).ToString();
                    change = true;
                }
            }
            if (change)
            {
                CheckValue();
            }
        }

        public static void BlobCheckValue(Blob blob)
        {
            int currentRow = 0;
            int currentColumn = 0;
            var foundCurrentBlob = false;
            // get indices des aktuellen blobs
            for (int row = 0; row < y; row++)
            {
                for (int column = 0; column < x; column++)
                {
                    if (blobs[row, column] == blob)
                    {
                        currentRow = row;
                        currentColumn = column;
                        foundCurrentBlob = true;
                        break;
                    }
                }
                if (foundCurrentBlob)
                {
                    break;
                }
            }
            var tests = new List<bool>();
            var vals = new List<int>();

            int[] _row = new int[3] { currentRow - 1, currentRow, currentRow + 1 };
            int[] _col = new int[3] { currentColumn - 1, currentColumn, currentColumn + 1 };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 1 && j == 1)
                    {
                        continue;
                    }
                    try
                    {
                        var _ = blobs[_row[i], _col[j]];

                        if (_.Aktiv)
                        {
                            tests.Add(int.Parse(_.TextBlock.Text) >= int.Parse(blobs[_row[1], _col[1]].TextBlock.Text));
                            vals.Add(int.Parse(_.TextBlock.Text));
                        }
                        else
                        {
                            tests.Add(false);
                            vals.Add(0);
                        }

                    }
                    catch (Exception)
                    {
                        tests.Add(false);
                        vals.Add(0);
                    }

                }
            }

            if (!tests.Contains(false))
            {
                var _ = vals.Min();
                blob.TextBlock.Text = (_ + 1).ToString();
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 1 && j == 1)
                    {
                        continue;
                    }
                    try
                    {
                        BlobCheckValue(blobs[_row[i], _col[j]]);
                    }
                    catch (Exception)
                    {

                        
                    }
                }
            }
        }
    }

}
