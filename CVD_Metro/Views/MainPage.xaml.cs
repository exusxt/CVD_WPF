using MahApps.Metro.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Notification.Wpf;
using Notification.Wpf.Classes;
using System.Windows.Media;
using YoutubeDLSharp;

namespace CVD.Views;

public partial class MainPage : Page, INotifyPropertyChanged
{
    private bool isNotDownloading = true;
    private IProgress<DownloadProgress> progress;
    private IProgress<string> output;

    public MainPage()
    {
        InitializeComponent();
        DataContext = this;
        //Application.Current.MainWindow.WindowState = WindowState.Maximized;
        Loaded += MainPage_Loaded;
        progress = new Progress<DownloadProgress>((p) => showProgress(p));

    }



    public YoutubeDL YoutubeDL { get; }

    

    private void showProgress(DownloadProgress p)
    {
        progressBar1.Value = p.Progress;
    }

    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        listBox1.Items.Clear();
        if (!File.Exists("ffmpeg.exe") && !File.Exists("yt-dlp.exe"))
        {
            var Result = MessageBox.Show("Would you like me to download ffmpeg and yt-dlp?", "Missing Files", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                await YoutubeDLSharp.Utils.DownloadYtDlp();
                await YoutubeDLSharp.Utils.DownloadFFmpeg();
                MessageBox.Show("The Files were downloaded!");
            }
            else if (Result == MessageBoxResult.No)
            {
                MessageBox.Show("Without ffmpeg and yt-dlp, this program don't work!");
            }
        }
        else if (!File.Exists("ffmpeg.exe"))
        {
            var Result = MessageBox.Show("Would you like me to download ffmpeg?", "Missing File", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                await YoutubeDLSharp.Utils.DownloadFFmpeg();
                MessageBox.Show("The File were downloaded!");
            }
            else if (Result == MessageBoxResult.No)
            {
                MessageBox.Show("Without ffmpeg, this program don't work!");
            }
        }
        else if (!File.Exists("yt-dlp.exe"))
        {
            var Result = MessageBox.Show("Would you like me to download yt-dlp?", "Missing File", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                await YoutubeDLSharp.Utils.DownloadYtDlp();
                MessageBox.Show("The File were downloaded!");
            }
            else if (Result == MessageBoxResult.No)
            {
                MessageBox.Show("Without yt-dlp, this program don't work!");
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
    {
        if (Equals(storage, value))
        {
            return;
        }

        storage = value;
        OnPropertyChanged(propertyName);
    }

    private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private void buttonadd_Click(object sender, RoutedEventArgs e)
    {
        listBox1.Items.Add(textBox1.Text);
        textBox1.Clear();
    }

    private void buttonClear_Click(object sender, RoutedEventArgs e)
    {
        if (listBox1.Items.Count > 1)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the link to delete first!");
            }
            else
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            
        } 
        else
        {
            listBox1.Items.Clear();
        }
    }
    private CancellationTokenSource cts = new CancellationTokenSource();
    private NotificationManager _notificationManager = new NotificationManager();
    public async Task DownloadVideos() 
    {
        cts.Dispose(); // Clean up old token source....
        cts = new CancellationTokenSource(); // "Reset" the cancellation token source...
        
        var ytdl = new YoutubeDL();
        foreach (var listBoxItem in listBox1.Items)
        {

            _notificationManager.Show("Start", listBoxItem.ToString() + " download started!", NotificationType.Information, "WindowArea");
            var progress = new Progress<DownloadProgress>(p => progressBar1.Value = p.Progress);
            // a cancellation token source used for cancelling the download
            // use `cts.Cancel();` to perform cancellation
            RunResult<string> result;
            isNotDownloading = false;
            result = await ytdl.RunVideoDownload(listBoxItem.ToString(),
                            progress: progress, ct: cts.Token);
            if (result.Success)
            {
                _notificationManager.Show("Success", listBoxItem.ToString() + " was downloaded!", NotificationType.Success, "WindowArea");
            }
            else
            {
                _notificationManager.Show("Error", listBoxItem.ToString() + " wasn't downloaded!", NotificationType.Error, "WindowArea");
            }
            isNotDownloading = true;
        }
    }

    private void buttonClearList_Click(object sender, RoutedEventArgs e)
    {
        listBox1.Items.Clear();
    }

    private async void buttonDownload_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            await DownloadVideos();
        }
        catch (Exception ex) 
        {
            _notificationManager.Show("Canceled", ex.Message, NotificationType.Information, "WindowArea");
        }
    }

    private void buttonCancel_Click(object sender, RoutedEventArgs e)
    {
        cts.Cancel();
    }
}
