using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Dithering
{
    public partial class MainPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPageLoaded;
        }

        void MainPageLoaded(object sender, RoutedEventArgs e)
        {
            CirclesImage.Source = LoadCircles();
            RainbowImage.Source = LoadRainbow();
            FaceImage.Source = LoadFace();
        }

        private void OriginalButton_Click(object sender, RoutedEventArgs e)
        {
            switch(Pivot.SelectedIndex)
            {
                case 0:
                    CirclesImage.Source = LoadCircles();
                    break;
                case 1:
                    RainbowImage.Source = LoadRainbow();
                    break;
                case 2:
                    FaceImage.Source = LoadFace();
                    break;
            }
        }

        private void SierraLiteButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img;
            WriteableBitmap dithered;
            switch (Pivot.SelectedIndex)
            {
                case 0:
                    img = LoadCircles();
                    dithered = new WriteableBitmap(img);
                    Dither.Sierra24A(dithered);
                    CirclesImage.Source = dithered;
                    break;
                case 1:
                    img = LoadRainbow();
                    dithered = new WriteableBitmap(img);
                    Dither.Sierra24A(dithered);
                    RainbowImage.Source = dithered;
                    break;
                case 2:
                    img = LoadFace();
                    dithered = new WriteableBitmap(img);
                    Dither.Sierra24A(dithered);
                    FaceImage.Source = dithered;
                    break;
            }
        }

        private void SierraButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img;
            WriteableBitmap dithered;
            switch (Pivot.SelectedIndex)
            {
                case 0:
                    img = LoadCircles();
                    dithered = new WriteableBitmap(img);
                    Dither.Sierra2(dithered);
                    CirclesImage.Source = dithered;
                    break;
                case 1:
                    img = LoadRainbow();
                    dithered = new WriteableBitmap(img);
                    Dither.Sierra2(dithered);
                    RainbowImage.Source = dithered;
                    break;
                case 2:
                    img = LoadFace();
                    dithered = new WriteableBitmap(img);
                    Dither.Sierra2(dithered);
                    FaceImage.Source = dithered;
                    break;
            }
        }

        private void FloydButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img;
            WriteableBitmap dithered;
            switch (Pivot.SelectedIndex)
            {
                case 0:
                    img = LoadCircles();
                    dithered = new WriteableBitmap(img);
                    Dither.FloydSteinberg(dithered);
                    CirclesImage.Source = dithered;
                    break;
                case 1:
                    img = LoadRainbow();
                    dithered = new WriteableBitmap(img);
                    Dither.FloydSteinberg(dithered);
                    RainbowImage.Source = dithered;
                    break;
                case 2:
                    img = LoadFace();
                    dithered = new WriteableBitmap(img);
                    Dither.FloydSteinberg(dithered);
                    FaceImage.Source = dithered;
                    break;
            }
        }

        private void StuckiButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img;
            WriteableBitmap dithered;
            switch (Pivot.SelectedIndex)
            {
                case 0:
                    img = LoadCircles();
                    dithered = new WriteableBitmap(img);
                    Dither.Stucki(dithered);
                    CirclesImage.Source = dithered;
                    break;
                case 1:
                    img = LoadRainbow();
                    dithered = new WriteableBitmap(img);
                    Dither.Stucki(dithered);
                    RainbowImage.Source = dithered;
                    break;
                case 2:
                    img = LoadFace();
                    dithered = new WriteableBitmap(img);
                    Dither.Stucki(dithered);
                    FaceImage.Source = dithered;
                    break;
            }
        }

        private BitmapImage LoadCircles()
        {
            var orig = new BitmapImage();
            using (var stream = Application.GetResourceStream(new Uri("/Dithering;component/circles.png", UriKind.Relative)).Stream)
            {
                orig.SetSource(stream);
            }
            return orig;
        }

        private BitmapImage LoadRainbow()
        {
            var orig = new BitmapImage();
            using (var stream = Application.GetResourceStream(new Uri("/Dithering;component/rainbow.png", UriKind.Relative)).Stream)
            {
                orig.SetSource(stream);
            }
            return orig;
        }

        private BitmapImage LoadFace()
        {
            var orig = new BitmapImage();
            using (var stream = Application.GetResourceStream(new Uri("/Dithering;component/face.png", UriKind.Relative)).Stream)
            {
                orig.SetSource(stream);
            }
            return orig;
        }
    }
}