using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int X;
        private int Y;
        private int Delta = 100;
        private TextBlock[,] Blobs;
        private VisualBrush inactive;
        private VisualBrush hover;
        private VisualBrush active;
        private BackgroundWorker worker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();

            X = (int)mainCanvas.Width / Delta;
            Y = (int)mainCanvas.Height / Delta;
            inactive = new VisualBrush(new Ellipse { Width = Delta, Height = Delta, Fill = Brushes.Gray, Stroke = Brushes.Black });
            hover = new VisualBrush(new Ellipse { Width = Delta, Height = Delta, Fill = Brushes.LightGray, Stroke = Brushes.Black });
            active = new VisualBrush(new Ellipse { Width = Delta, Height = Delta, Fill = Brushes.Red, Stroke = Brushes.Black });
            Blobs = new TextBlock[Y, X];
            CreateEmptyBlobs();
            worker.DoWork += Worker_DoWork;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += Worker_ProgressChanged;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var _ = (TextBlock)e.UserState;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = e.Argument as Tuple<TextBlock, TextBlock[,]>;
            var _Blobs = args.Item2;
            var _Blob = args.Item1;
        }

        void CreateEmptyBlobs()
        {
            for (int row = 0; row < Y; row++)
            {
                for (int column = 0; column < X; column++)
                {
                    var _ = new TextBlock()
                    {
                        Height = Delta,
                        Width = Delta,
                        Background = inactive,
                        Tag = false
                    };
                    _.MouseEnter += __MouseEnter;
                    _.MouseLeave += __MouseLeave;
                    _.MouseLeftButtonUp += __MouseLeftButtonUp;
                    mainCanvas.Children.Add(_);
                    Canvas.SetTop(_, row * Delta);
                    Canvas.SetLeft(_, column * Delta);
                }
            }

        }

        private void __MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var _ = sender as TextBlock;
            if (!(bool)_.Tag == true)
            {
                _.Tag = true;
                _.Background = active;
                worker.RunWorkerAsync((_, Blobs));
            }

        }

        private void __MouseLeave(object sender, MouseEventArgs e)
        {
            var _ = sender as TextBlock;
            if (!(bool)_.Tag == true)
            {
                _.Background = inactive;
            }
        }

        private void __MouseEnter(object sender, MouseEventArgs e)
        {
            var _ = sender as TextBlock;
            if (!(bool)_.Tag == true)
            {
                _.Background = hover;
            }
        }

        //    public static void CheckValue()
        //    {
        //        bool change = false;
        //        foreach (var blob in Blobs)
        //        {
        //            // checke nur aktive blobs
        //            if (!blob.Aktiv)
        //            {
        //                continue;
        //            }

        //            int currentRow = 0;
        //            int currentColumn = 0;
        //            var foundCurrentBlob = false;
        //            // get indices des aktuellen blobs
        //            for (int row = 0; row < y; row++)
        //            {
        //                for (int column = 0; column < x; column++)
        //                {
        //                    if (blobs[row, column] == blob)
        //                    {
        //                        currentRow = row;
        //                        currentColumn = column;
        //                        foundCurrentBlob = true;
        //                        break;
        //                    }
        //                }
        //                if (foundCurrentBlob)
        //                {
        //                    break;
        //                }
        //            }

        //            var tests = new List<bool>();
        //            var vals = new List<int>();

        //            int[] _row = new int[3] { currentRow - 1, currentRow, currentRow + 1 };
        //            int[] _col = new int[3] { currentColumn - 1, currentColumn, currentColumn + 1 };

        //            for (int i = 0; i < 3; i++)
        //            {
        //                for (int j = 0; j < 3; j++)
        //                {
        //                    if (i == 1 && j == 1)
        //                    {
        //                        continue;
        //                    }
        //                    try
        //                    {
        //                        var _ = blobs[_row[i], _col[j]];

        //                        if (_.Aktiv)
        //                        {
        //                            tests.Add(int.Parse(_.TextBlock.Text) >= int.Parse(blobs[_row[1], _col[1]].TextBlock.Text));
        //                            vals.Add(int.Parse(_.TextBlock.Text));
        //                        }
        //                        else
        //                        {
        //                            tests.Add(false);
        //                            vals.Add(0);
        //                        }

        //                    }
        //                    catch (Exception)
        //                    {
        //                        tests.Add(false);
        //                        vals.Add(0);
        //                    }

        //                }
        //            }

        //            if (!tests.Contains(false))
        //            {
        //                var _ = vals.Min();
        //                blob.TextBlock.Text = (_ + 1).ToString();
        //                change = true;
        //            }
        //        }

        //        if (change)
        //        {
        //            CheckValue();
        //        }
        //    }

        //    public static void BlobCheckValue(Blob blob)
        //    {
        //        int currentRow = 0;
        //        int currentColumn = 0;
        //        var foundCurrentBlob = false;
        //        // get indices des aktuellen blobs
        //        for (int row = 0; row < y; row++)
        //        {
        //            for (int column = 0; column < x; column++)
        //            {
        //                if (blobs[row, column] == blob)
        //                {
        //                    currentRow = row;
        //                    currentColumn = column;
        //                    foundCurrentBlob = true;
        //                    break;
        //                }
        //            }
        //            if (foundCurrentBlob)
        //            {
        //                break;
        //            }
        //        }
        //        var tests = new List<bool>();
        //        var vals = new List<int>();

        //        int[] _row = new int[3] { currentRow - 1, currentRow, currentRow + 1 };
        //        int[] _col = new int[3] { currentColumn - 1, currentColumn, currentColumn + 1 };

        //        for (int i = 0; i < 3; i++)
        //        {
        //            for (int j = 0; j < 3; j++)
        //            {
        //                if (i == 1 && j == 1)
        //                {
        //                    continue;
        //                }
        //                try
        //                {
        //                    var _ = blobs[_row[i], _col[j]];

        //                    if (_.Aktiv)
        //                    {
        //                        tests.Add(int.Parse(_.TextBlock.Text) >= int.Parse(blobs[_row[1], _col[1]].TextBlock.Text));
        //                        vals.Add(int.Parse(_.TextBlock.Text));
        //                    }
        //                    else
        //                    {
        //                        tests.Add(false);
        //                        vals.Add(0);
        //                    }

        //                }
        //                catch (Exception)
        //                {
        //                    tests.Add(false);
        //                    vals.Add(0);
        //                }

        //            }
        //        }

        //        if (!tests.Contains(false))
        //        {
        //            var _ = vals.Min();
        //            blob.TextBlock.Text = (_ + 1).ToString();
        //        }

        //        for (int i = 0; i < 3; i++)
        //        {
        //            for (int j = 0; j < 3; j++)
        //            {
        //                if (i == 1 && j == 1)
        //                {
        //                    continue;
        //                }
        //                try
        //                {
        //                    BlobCheckValue(blobs[_row[i], _col[j]]);
        //                }
        //                catch (Exception)
        //                {


        //                }
        //            }
        //        }
        //    }
    }

}
