using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WebViewTest
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnTop(object sender, System.EventArgs e)
        {
            this.wv1.Source = "http://www.p-world.co.jp/sp";
        }

        private void Handle_Clicked(object sender, System.EventArgs e)
        {

            this.wv1.Source = "http://www.p-world.co.jp/sp";
        }


        private void OnMapApp(object sender, System.EventArgs e)
        {
            if (Device.OS == TargetPlatform.iOS)
            {
                Device.OpenUri(new Uri("http://maps.apple.com/?q=Tokyo"));
            }
            else if (Device.OS == TargetPlatform.Android)
            {
                Device.OpenUri(new Uri("geo:0,0?q=gunma"));
            }
        }

        private void Handle_PinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            this.labelStatus.Text = $"{e.Status}: {e.Scale}: ({e.ScaleOrigin.X}, {e.ScaleOrigin.Y})";
        }

        private async void Handle_Appearing(object sender, EventArgs e)
        {
            await this.wv1.RotateYTo(450,1000);
            await this.labelStatus.TranslateTo(100, 100);
            await Task.WhenAll<bool>(
            this.labelStatus.RotateTo(1000, 1000),
            this.labelStatus.RotateXTo(800, 1000),
            this.labelStatus.RotateYTo(500, 1000));
            await this.labelStatus.RotateTo(0, 1000);
            await this.labelStatus.RotateXTo(0, 1000);
            await this.labelStatus.RotateYTo(0, 1000);


            await this.labelStatus.TranslateTo(0, 0,5000, Easing.BounceOut);
            await this.wv1.RotateYTo(0, 10000, Easing.SpringOut);

        }

    }
}
