using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WebViewTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnTop(object sender, System.EventArgs e)
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
                Device.OpenUri(new Uri("geo:0,0?q=Tokyo"));
            }
        }

    }
}
