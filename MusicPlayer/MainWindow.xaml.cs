using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TagLib;

namespace MusicPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MediaPlayer media = new MediaPlayer();

        string[] files;

        ObservableCollection<MyTrack> playlist = new ObservableCollection<MyTrack>();
        ObservableCollection<MyTrack> mp3 = new ObservableCollection<MyTrack>();

        MyTrack f;

        int count = 0;

        public ObservableCollection<Track> Tracks { get; set; }
        public ObservableCollection<Album> Albums { get; set; }
        public ObservableCollection<PlayList> PlayLists { get; set; }

        public MainWindow()
        {

            InitializeComponent();
            this.DataContext = mp3;

        }

        private void extButton_Click(object sender, RoutedEventArgs e)
        {
            // close window
            this.Close();
        }

        private void DragMoveRect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // move window
            this.DragMove();

            try
            {
                ContentControl i = (ContentControl)this.Template.FindName("mainContent", this);
                ListView c = (ListView)i.Template.FindName("TrackList", i);
                ItemsControl b = (ItemsControl)this.Template.FindName("LeftMenu", this);

                //Albums = new ObservableCollection<Album>
                //{
                //    new Album { name="The Inception", Image = @"D:\Загрузки браузера\5ad7d5db0808d9150c546625bb79a94c1.jpg", Artist="Cult To Follow"},
                //    new Album { name="The Inception", Image = @"D:\Загрузки браузера\5ad7d5db0808d9150c546625bb79a94c1.jpg", Artist="Cult To Follow"},
                //    new Album { name="The Inception", Image = @"D:\Загрузки браузера\5ad7d5db0808d9150c546625bb79a94c1.jpg", Artist="Cult To Follow"},
                //    new Album { name="The Inception", Image = @"D:\Загрузки браузера\5ad7d5db0808d9150c546625bb79a94c1.jpg", Artist="Cult To Follow"},
                //    new Album { name="The Inception", Image = @"D:\Загрузки браузера\5ad7d5db0808d9150c546625bb79a94c1.jpg", Artist="Cult To Follow"},
                //    new Album { name="123", Image = @"D:\Загрузки браузера\5ad7d5db0808d9150c546625bb79a94c1.jpg", Artist="Cult To Follow"}
                //};

                PlayLists = new ObservableCollection<PlayList>
                {
                    new PlayList { PlayListName="The Inception"},
                    new PlayList { PlayListName="The Inception"},
                    new PlayList { PlayListName="The Inception"},
                    new PlayList { PlayListName="The Inception"},
                    new PlayList { PlayListName="The Inception"},
                    new PlayList { PlayListName="123"}
                };

                Tracks = new ObservableCollection<Track>
                {
                new Track { Title="The Calling", Artist="TheFatRat", Album="The Calling", Duration = TimeSpan.FromMinutes(3.54).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14) },
                new Track { Title="Bitter End", Artist="The Veer Union", Album="Divide The Blackened Sky", Duration = TimeSpan.FromMinutes(3.41).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14) },
                new Track { Title="Ignite", Artist="Alan Walker", Album="Ignite", Duration = TimeSpan.FromMinutes(3.30).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14) },
                new Track { Title="Don't Wake Me", Artist="Aranda", Album="Not The Same", Duration = TimeSpan.FromMinutes(3.28).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14) },
                new Track { Title="Stars", Artist="Silent Season", Album="Stars" , Duration = TimeSpan.FromMinutes(3.40).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14) },
                new Track { Title="Losing You", Artist="Dead by April", Album="Dead by April(Bonus Version)", Duration = TimeSpan.FromMinutes(3.58).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14)  },
                new Track { Title="10 Seconds From Panik", Artist="Cult To Follow", Album="The Inceprion", Duration = TimeSpan.FromMinutes(3.34).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14)  },
                new Track { Title="Through With You", Artist="Cult To Follow", Album="The Inceprion", Duration = TimeSpan.FromMinutes(3.11).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14)  },
                new Track { Title="My Own Nightmare", Artist="Downplay", Album="Radiocalypse", Duration = TimeSpan.FromMinutes(2.58).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14)  },
                new Track { Title="Bangarang (feat. Sirah)", Artist="Skrillex", Album="Bangarang EP", Duration = TimeSpan.FromMinutes(3.35).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14)  },
                new Track { Title="Lifeline", Artist="Thousand Foot Krutch", Album="Exhale", Duration = TimeSpan.FromMinutes(3.11).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14)  },
                new Track { Title="War of Changes", Artist="Thousand Foot Krutch", Album="The End Is Where We Begin", Duration = TimeSpan.FromMinutes(3.11).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14)  },
                new Track { Title="Courtesy Call", Artist="Thousand Foot Krutch", Album="The End Is Where We Begin", Duration = TimeSpan.FromMinutes(3.57).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14) },
                new Track { Title="Untraveled Road", Artist="Thousand Foot Krutch", Album="OXYGEN:INHALE", Duration = TimeSpan.FromMinutes(3.56).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14) },
                new Track { Title="Let The Sparks Fly", Artist="Thousand Foot Krutch", Album="The End Is Where We Begin", Duration = TimeSpan.FromMinutes(4.07).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14) },
                new Track { Title="Hot Pursoit", Artist="Tut Tut Child", Album="Ask Your Friends First EP", Duration = TimeSpan.FromMinutes(4.58).ToString(@"mm\:ss"), Added = new DateTime(2019, 04, 14) }
                };

                c.ItemsSource = Tracks;

                for (int j = 0; j < PlayLists.Count; j++)
                {
                    RadioButton a = new RadioButton();
                    a.FontFamily = new FontFamily("Circular std bold");
                    a.FontSize = 15;
                    a.Margin = new Thickness(0, 5, 0, 0);
                    a.Style = (Style)this.FindResource("mainButton");
                    a.Width = Double.NaN;
                    TextBlock t = new TextBlock();
                    t.TextTrimming = TextTrimming.CharacterEllipsis;
                    t.Text = PlayLists[j].PlayListName;
                    t.Margin = new Thickness(0, 0, 0, 0);
                    a.Content = t;
                    b.Items.Add(a);
                }

            }
            catch
            {

            }
        }

        private void volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Volume button style change
            if (volume.Value > 2)
                VolumeButton.Style = (Style)VolumeButton.FindResource("volumeButtonLessThen70");
            if (volume.Value > 7)
                VolumeButton.Style = (Style)VolumeButton.FindResource("volumeButtonMoreThen70");
            if (volume.Value < 2)
                VolumeButton.Style = (Style)VolumeButton.FindResource("volumeButtonLessThen20");
            if (volume.Value < 1)
                VolumeButton.Style = (Style)VolumeButton.FindResource("volumeButtonOff");

        }

        bool flag = false;

        private void scroll1_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            try
            {
                ContentControl g = (ContentControl)this.Template.FindName("mainContent", this);
                TextBlock f = (TextBlock)g.Template.FindName("sectionName", g);
                Button f1 = (Button)g.Template.FindName("PlayButton", g);

                Canvas i = (Canvas)this.Template.FindName("rect", this);
                Rectangle b = (Rectangle)this.Template.FindName("rect1", this);
                Rectangle b1 = (Rectangle)this.Template.FindName("rect3", this);
                Rectangle b2 = (Rectangle)this.Template.FindName("DragMoveRect", this);
                GradientStop stop = (GradientStop)b.FindName("brush");

                if (stop.Offset > 0.1 && e.VerticalChange > 0)
                {
                    if (stop.Offset - e.VerticalChange * 0.005 < 0.1)
                        stop.Offset = 0.1;
                    else
                        stop.Offset -= e.VerticalChange * 0.005;
                }
                else if (e.VerticalOffset < 40 && e.VerticalChange < 0 && stop.Offset < 0.25)
                {
                    if (stop.Offset - e.VerticalChange * 0.005 > 0.25)
                        stop.Offset = 0.25;
                    else
                        stop.Offset -= e.VerticalChange * 0.005;
                }
                i.Opacity += e.VerticalChange * 0.013;
                //b2.Opacity += e.VerticalChange * 0.01;
                //f.Opacity -= e.VerticalChange * 0.03;
                if (f1 != null)
                    //f1.Opacity -= e.VerticalChange * 0.03;
                b1.Opacity += e.VerticalChange * 0.013;

                if (i.Height > 120)
                {
                    if (i.Height - e.VerticalChange < 120)
                    {
                        i.Height = 119.9;
                        b1.Height = 119.9;
                    }
                    else
                    {
                        i.Height -= e.VerticalChange;
                        b1.Height -= e.VerticalChange;
                    }
                }
                else if (e.VerticalOffset < 100 && e.VerticalChange < 0 && i.Height < 200)
                {
                    i.Height -= e.VerticalChange;
                    b1.Height -= e.VerticalChange;
                }

                if (i.Height < 120 && !flag)
                {
                    i.Opacity = 1;
                    //i.Background = b1.Fill;
                    flag = true;
                    DoubleAnimationUsingKeyFrames anim = new DoubleAnimationUsingKeyFrames();
                    LinearDoubleKeyFrame frame = new LinearDoubleKeyFrame(73, TimeSpan.FromSeconds(0.1));
                    LinearDoubleKeyFrame frame1 = new LinearDoubleKeyFrame(63, TimeSpan.FromSeconds(0.2));

                    anim.KeyFrames.Add(frame);
                    anim.KeyFrames.Add(frame1);


                    DoubleAnimationUsingKeyFrames anim1 = new DoubleAnimationUsingKeyFrames();
                    LinearDoubleKeyFrame frame11 = new LinearDoubleKeyFrame(1, TimeSpan.FromSeconds(0.2));

                    anim1.KeyFrames.Add(frame11);

                    DoubleAnimationUsingKeyFrames anim2 = new DoubleAnimationUsingKeyFrames();
                    LinearDoubleKeyFrame frame12 = new LinearDoubleKeyFrame(0, TimeSpan.FromSeconds(0.2));

                    anim2.KeyFrames.Add(frame12);

                    TextBlock l = (TextBlock)this.Template.FindName("rectL1", this);
                    Button bc = (Button)this.Template.FindName("rectB1", this);

                    bc.BeginAnimation(Canvas.TopProperty, anim);
                    l.BeginAnimation(Canvas.TopProperty, anim);

                    bc.BeginAnimation(OpacityProperty, anim1);
                    l.BeginAnimation(OpacityProperty, anim1);

                    f.BeginAnimation(OpacityProperty, anim2);
                    f1.BeginAnimation(OpacityProperty, anim2);

                    i.Background = b1.Fill;
                    
                    Border line = (Border)this.Template.FindName("Line", this);
                    line.Opacity = 1;
                }
                else if (i.Height > 120 && flag)
                {
                    i.Background = null;
                    flag = false;
                    DoubleAnimationUsingKeyFrames anim = new DoubleAnimationUsingKeyFrames();
                    LinearDoubleKeyFrame frame = new LinearDoubleKeyFrame(92, TimeSpan.FromSeconds(0.1));
                    LinearDoubleKeyFrame frame1 = new LinearDoubleKeyFrame(102, TimeSpan.FromSeconds(0.2));
                    
                    anim.KeyFrames.Add(frame);
                    anim.KeyFrames.Add(frame1);


                    DoubleAnimationUsingKeyFrames anim1 = new DoubleAnimationUsingKeyFrames();
                    LinearDoubleKeyFrame frame11 = new LinearDoubleKeyFrame(0, TimeSpan.FromSeconds(0.2));

                    anim1.KeyFrames.Add(frame11);

                    DoubleAnimationUsingKeyFrames anim2 = new DoubleAnimationUsingKeyFrames();
                    LinearDoubleKeyFrame frame12 = new LinearDoubleKeyFrame(1, TimeSpan.FromSeconds(0.2));

                    anim2.KeyFrames.Add(frame12);

                    TextBlock l = (TextBlock)this.Template.FindName("rectL1", this);
                    Button bc = (Button)this.Template.FindName("rectB1", this);

                    bc.BeginAnimation(Canvas.TopProperty, anim);
                    l.BeginAnimation(Canvas.TopProperty, anim);

                    bc.BeginAnimation(OpacityProperty, anim1);
                    l.BeginAnimation(OpacityProperty, anim1);

                    f.BeginAnimation(OpacityProperty, anim2);
                    f1.BeginAnimation(OpacityProperty, anim2);
                    
                    Border line = (Border)this.Template.FindName("Line", this);
                    line.Opacity = 0;
                }
            }
            catch
            {

            }
        }

        public class Track
        {
            public string Title { get; set; }
            public string Artist { get; set; }
            public string Album { get; set; }
            public string Duration { get; set; }
            public DateTime Added { get; set; }
        }

        public class Album
        {
            public List<Track> tracks = new List<Track>();
            public string name { get; set; }
            string description;
           // public List<Artist> artists;
            public string Image { get; set; }
            public string Artist { get; set; }
        }

        bool mouseDown = false;
        Point StartPoint;
        ColumnDefinition column;
        MathConvert converter;
        private void LeftPanelResize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(sender as Rectangle);
            column = (ColumnDefinition)this.Template.FindName("leftPanelColumn", this);
            converter = (MathConvert)this.FindResource("myConverter");
            converter.MouseDown = true;
            StartPoint = e.GetPosition(this);
            mouseDown = true;
        }

        private void LeftPanelResize_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point CurrPos = e.GetPosition(this);
                if (CurrPos.X > StartPoint.X)
                {
                    GridLength length = column.Width;
                    if (length.Value + (CurrPos.X - StartPoint.X) < column.MaxWidth)
                    {
                        GridLength newLength = new GridLength(length.Value + (CurrPos.X - StartPoint.X));
                        column.Width = newLength;
                        StartPoint = CurrPos;
                    }
                    else
                    {
                        GridLength newLength = new GridLength(column.MaxWidth - 1);
                        column.Width = newLength;
                        StartPoint = CurrPos;
                    }
                }
                else if (CurrPos.X < StartPoint.X)
                {
                    GridLength length = column.Width;
                    if (length.Value - (StartPoint.X - CurrPos.X) > column.MinWidth)
                    {
                        GridLength newLength = new GridLength(length.Value - (StartPoint.X - CurrPos.X));
                        column.Width = newLength;
                        StartPoint = CurrPos;
                    }
                    else
                    {
                        GridLength newLength = new GridLength(column.MinWidth - 1);
                        column.Width = newLength;
                        StartPoint = CurrPos;
                    }
                }
            }
        }

        private void LeftPanelResize_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            mouseDown = false;
            converter.MouseDown = false;
            column = null;
        }

        private void MaxImgButton_Click(object sender, RoutedEventArgs e)
        {
            if (converter == null)
                converter = (MathConvert)this.FindResource("myConverter");
            converter.ImgUp = true;
        }

        private void MaxImgButtonBig_Click(object sender, RoutedEventArgs e)
        {
            if (converter == null)
                converter = (MathConvert)this.FindResource("myConverter");
            converter.ImgUp = false;
        }

        private void scroll1_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            e.Handled = true;
        }

        private void favorites_Click(object sender, RoutedEventArgs e)
        {
            ContentControl i = (ContentControl)this.Template.FindName("mainContent", this);
            i.Style = (Style)i.FindResource("favoriteSongs");
        }

        private void Albums_Click(object sender, RoutedEventArgs e)
        {
            ContentControl i = (ContentControl)this.Template.FindName("mainContent", this);
            i.Style = (Style)i.FindResource("albums");
        }

        private void Artist_Click(object sender, RoutedEventArgs e)
        {
            ContentControl i = (ContentControl)this.Template.FindName("mainContent", this);
            i.Style = (Style)i.FindResource("artists");
        }

        private void RecentlyPlayed_Click(object sender, RoutedEventArgs e)
        {
            ContentControl i = (ContentControl)this.Template.FindName("mainContent", this);
            i.Style = (Style)i.FindResource("recentlyPlayed");
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            ContentControl i = (ContentControl)this.Template.FindName("mainContent", this);
            ListView b = (ListView)i.Template.FindName("TrackList", i);
            ItemsPresenter p = (ItemsPresenter)b.Template.FindName("pres", b);
            Thickness n = p.Margin;
            if(((Button)sender).Tag as string == "Forward")
                n.Left -= 240;
            else
                n.Left += 240;
            ThicknessAnimationUsingKeyFrames anim = new ThicknessAnimationUsingKeyFrames();
            SplineThicknessKeyFrame frame = new SplineThicknessKeyFrame(n, TimeSpan.FromSeconds(0.15));
            if (((Button)sender).Tag as string == "Forward")
                n.Left -= 20;
            else
                n.Left += 20;
            SplineThicknessKeyFrame frame1 = new SplineThicknessKeyFrame(n, TimeSpan.FromSeconds(0.28));
            anim.KeyFrames.Add(frame);
            anim.KeyFrames.Add(frame1);
            p.BeginAnimation(MarginProperty, anim);
        }

        private void MadeForYou_Click(object sender, RoutedEventArgs e)
        {
            ContentControl i = (ContentControl)this.Template.FindName("mainContent", this);
            i.Style = (Style)i.FindResource("madeForYou");
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            ContentControl i = (ContentControl)this.Template.FindName("mainContent", this);
            i.Style = (Style)i.FindResource("home");
        }

        private void Rec_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Border)sender).Opacity = 1;
        }

        private void Rec_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Border)sender).Opacity = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "File (*.mp3)|*.mp3";
            op.Multiselect = true;

            if (op.ShowDialog() == false)
                return;

            files = op.FileNames;

            foreach (string file in files)
            {

                media.Open(new Uri(file));

                Thread.Sleep(1000);

                playList.SelectedItem = file;

                AddMus(f = new MyTrack(System.IO.Path.GetFileNameWithoutExtension(file), "00:00", new Uri(file)));

                playList.SelectedIndex = count;


                count++;

            }
        }
        private void AddMus(MyTrack w)
        {
            playlist.Add(w);
            mp3.Add(w);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            media.Stop();

            var nextrack = playList.SelectedIndex + 1;
            if (nextrack >= playList.Items.Count)
            {
                nextrack = 0;
                playList.SelectedIndex = 0;

            }
            playList.SelectedIndex = nextrack;

            f = playlist[nextrack];

            media.Open(f.track);

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            media.Stop();

            var prevtrack = playList.SelectedIndex - 1;

            if (prevtrack < 0)
            {
                prevtrack = playList.Items.Count - 1;
                playList.SelectedIndex = playList.Items.Count - 1;
            }

            playList.SelectedIndex = prevtrack;

            f = playlist[prevtrack];

            media.Open(f.track);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();

            for (int i = mp3.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                var temp = mp3[j];
                mp3[j] = mp3[i];
                mp3[i] = temp;
            }
        }

        private void playList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            f = playlist[playList.SelectedIndex];
            media.Open(f.track);
            media.Play();
        }
    }

    public class PlayList
    {
        public string PlayListName { get; set; }
    }

    public class DateConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime Added = (DateTime)value;
            DateTime now = DateTime.Now;
            TimeSpan res = now - Added;
            
            return String.Format("{0} days ago", res.Days);
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // Благодаря этому классу работает resize левого меню    НЕ ТРОГАТЬ!!!
    public class MathConvert : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (MouseDown && ImgUp)
            {
                if (targetType == typeof(Thickness))
                {
                    Thickness thic = new Thickness(0, 0, 0, System.Convert.ToDouble(value[1]));
                    if (value.Length > 2)
                    {
                        thic.Top -= System.Convert.ToDouble(parameter);
                        return thic;
                    }
                    else
                    {
                        thic.Top -= System.Convert.ToDouble(parameter);
                        return thic;
                    }
                }
                else
                {
                    if (value.Length > 1)
                        return (System.Convert.ToDouble(value[0]) - System.Convert.ToDouble(value[1])) - System.Convert.ToDouble(parameter);
                    else
                        return (System.Convert.ToDouble(value[0]) - System.Convert.ToDouble(parameter));
                }
            }
            if (value.Length > 2 && !ImgUp)
                return value[value.Length - 1];
            else if (value.Length > 1)
            {
                if (targetType == typeof(Thickness))
                {
                    Thickness thic = new Thickness(0, 0, 0, System.Convert.ToDouble(value[1]));
                    thic.Bottom -= System.Convert.ToDouble(parameter);
                    return thic;
                }
                else
                    return (System.Convert.ToDouble(value[0]) - System.Convert.ToDouble(value[1])) - System.Convert.ToDouble(parameter);
            }
            else
                return (System.Convert.ToDouble(value[0]) - System.Convert.ToDouble(parameter));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public bool MouseDown { get; set; }
        public bool ImgUp { get; set; }
    }

    public class MyTrack
    {
        public Uri track;
        string time;
        string song;


        public MyTrack (string song, string time, Uri track)
        {
            this.song = song;
            this.track = track;       
            this.time = time;
        }

        public string Song
        {
            get { return song; }
            set { song = value; }
        }
        
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}


