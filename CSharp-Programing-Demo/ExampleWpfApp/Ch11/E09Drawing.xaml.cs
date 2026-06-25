using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ExampleWpfApp.Ch11
{
    public partial class E09Drawing : Page
    {
        public E09Drawing()
        {
            InitializeComponent();
            MediaPlayer player = null;
            MediaClock mClock = null;
            bool isRepeat = true;
            Loaded += delegate
            {
                var video = @"Resources\ContentVideo\wildlife.wmv";
                var uri = new Uri(video, UriKind.Relative);
                if (isRepeat)  //循环播放
                {
                    MediaTimeline mTimeline = new MediaTimeline(uri)
                    {
                        RepeatBehavior = RepeatBehavior.Forever
                    };
                    mClock = mTimeline.CreateClock();
                    player = new MediaPlayer
                    {
                        Clock = mClock
                    };
                    videoDrawing.Player = player;
                }
                else  //仅播放1次
                {
                    player = new MediaPlayer();
                    player.Open(uri);
                    videoDrawing.Player = player;
                    player.Play();
                }
            };
            Unloaded += delegate
            {
                if (isRepeat)
                {
                    mClock.Controller.Stop();
                }
                else
                {
                    player.Stop();
                }
            };
        }
    }
}
