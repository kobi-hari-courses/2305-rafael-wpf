using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace FunWithTasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CancellationTokenSource? tokenSource = null;
        TaskCompletionSource<(int from, int to)>? taskCompletionSource = null;


        public MainWindow()
        {
            InitializeComponent();
        }

        async private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("A");
            await Go();
            Debug.WriteLine("B");
        }

        async public Task<int> Go()
        {
            Stopwatch? start = null;
            tokenSource = new CancellationTokenSource();
            progressBar.Value = 0;

            try
            {
                Debug.WriteLine("1");
                btnStart.IsEnabled = false;
                txtStatus.Text = "Please Wait...";
                //progressBar.IsIndeterminate = true;

                var progressCallback = new Progress<double>(val => progressBar.Value = val);

                var range = await GetRangeFromTheUser(tokenSource?.Token ?? CancellationToken.None);

                start = Stopwatch.StartNew();
                var task = Task.Factory.StartNew(() => PrimesCalculator
                    .GetAllPrimesParallel(range.from, range.to, tokenSource?.Token ?? CancellationToken.None, progressCallback)
                    .ToList()); ;
                Debug.WriteLine("2");


                var res = await task;
                Debug.WriteLine("3");

                listBox.ItemsSource = res;
                txtStatus.Text = $"Completed with {res.Count} results in {start.Elapsed} time";
                Debug.WriteLine("4");
            }
            catch (OperationCanceledException)
            {
                txtStatus.Text = "Operation Cancelled";
            }
            catch (Exception) 
            {
                txtStatus.Text = "An Error has Occured";
            }
            finally
            {
                start?.Stop();
                btnStart.IsEnabled = true;
                tokenSource = null;
            }


            return 42;

        }

        public Task<double> PotentialLongProcess()
        {
            return Task.FromResult(3.14);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            tokenSource?.Cancel();
        }

        public Task<(int from, int to)> GetRange()
        {
            return Task.FromResult((2, 300000));
        }

        public async Task<(int from, int to)> GetRangeSlow(CancellationToken token)
        {
            await Task.Delay(5000, token);
            return (500, 250000);
        }

        public Task<(int from, int to)> GetRangeFromTheUser(CancellationToken token)
        {
            stkRange.Visibility = Visibility.Visible;
            taskCompletionSource = new TaskCompletionSource<(int from, int to)>();

            token.Register(() =>
            {
                taskCompletionSource?.SetCanceled();
                taskCompletionSource = null;
                stkRange.Visibility = Visibility.Collapsed;
            });

            return taskCompletionSource.Task;
        }

        private void btnSetRange_Click(object sender, RoutedEventArgs e)
        {
            var res = (int.Parse(txtFrom.Text), int.Parse(txtTo.Text));
            taskCompletionSource?.SetResult(res);
            taskCompletionSource = null;
            stkRange.Visibility = Visibility.Collapsed;

        }

        private async void btnFun_Click(object sender, RoutedEventArgs e)
        {
            var t1 = GetNumber(3000, 42);
            var t2 = GetNumber(5000, 10);
            var t3 = GetNumber(8000, 100);

            var tx = Task.WhenAny(t1, t2, t3).Unwrap();
            var res = await tx;

        }

        async private Task<int> GetNumber(int delay, int result)
        {
            await Task.Delay(delay);
            return result;
        }


        //private void Button_Click_old(object sender, RoutedEventArgs e)
        //{
        //    btnStart.IsEnabled = false;
        //    txtStatus.Text = "Please Wait...";
        //    progressBar.IsIndeterminate = true;

        //    var start = Stopwatch.StartNew();

        //    var task = Task.Factory.StartNew(() => PrimesCalculator
        //        .GetAllPrimes(2, 300000)
        //        .ToList());

        //    var t2 = task.ContinueWith(t =>
        //    {
        //        start.Stop();

        //        var res = t.Result;
        //        listBox.ItemsSource = res;
        //        btnStart.IsEnabled = true;
        //        txtStatus.Text = $"Completed with {res.Count} results in {start.Elapsed} time";
        //        progressBar.IsIndeterminate = false;
        //    }, TaskScheduler.FromCurrentSynchronizationContext());

        //}
    }
}
