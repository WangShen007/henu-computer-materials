using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
namespace ExampleWpfApp.Ch08
{
    public partial class E09MediaElement : Page
    {
        public E09MediaElement()
        {
            InitializeComponent();
            InitEvents();
        }
        DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(100)
        };
        private void InitEvents()
        {
            timer.Tick += delegate
            {
                slideProgress.Value = myMediaElement.Position.TotalMilliseconds;
            };
            myMediaElement.MediaOpened += delegate
            {
                TimeSpan d = myMediaElement.NaturalDuration.TimeSpan;
                slideProgress.Minimum = 0;
                slideProgress.Maximum = d.TotalMilliseconds;
                if (d.Hours == 0)
                {
                    textBlock1.Text = string.Format("文件：{0}, 长度：{1}分{2}秒",
                        myMediaElement.Source.OriginalString, d.Minutes, d.Seconds);
                }
                else
                {
                    textBlock1.Text = string.Format("文件：{0}, 长度：{1}小时{2}分{3}秒",
                        myMediaElement.Source.OriginalString, d.Hours, d.Minutes, d.Seconds);
                }
            };
            myMediaElement.MediaEnded += delegate { SetStatus(false); };
            btnStart.Click += delegate
            {
                slideProgress.Value = 0;
                myMediaElement.Play();
                SetStatus(true);
            };
            btnPause.Click += delegate
            {
                myMediaElement.Pause();
                SetStatus(false);
            };
            btnResume.Click += delegate
            {
                myMediaElement.Play();
                SetStatus(true);
            };
            btnStop.Click += delegate
            {
                myMediaElement.Stop();
                slideProgress.Value = 0;
                SetStatus(false);
            };
        }
        private void SetStatus(bool isPlaying)
        {
            btnStart.IsEnabled = btnResume.IsEnabled = !isPlaying;
            btnPause.IsEnabled = btnStop.IsEnabled = timer.IsEnabled = isPlaying;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton r = sender as RadioButton;
            if (myMediaElement != null)
            {
                myMediaElement.Stop();
                //注意：播放的媒体文件属性都是【内容】、【如果较新则复制】
                myMediaElement.Source = new Uri(r.Tag.ToString(), UriKind.Relative);
                myMediaElement.Play();
                SetStatus(true);
            }
        }
    }
    public class TimeSpanToMillisecondsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((TimeSpan)value).TotalMilliseconds;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TimeSpan.FromMilliseconds((double)value);
        }
    }
}
