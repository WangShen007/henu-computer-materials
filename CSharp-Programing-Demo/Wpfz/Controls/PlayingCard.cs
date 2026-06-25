using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Wpfz
{
    public class PlayingCard : ToggleButton
    {
        static PlayingCard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlayingCard),
                new FrameworkPropertyMetadata(typeof(PlayingCard)));
            FaceProperty = DependencyProperty.Register("Face",
                typeof(string), typeof(PlayingCard));
        }

        public string Face
        {
            get { return (string)GetValue(FaceProperty); }
            set { SetValue(FaceProperty, value); }
        }

        public static DependencyProperty FaceProperty;
    }
}
