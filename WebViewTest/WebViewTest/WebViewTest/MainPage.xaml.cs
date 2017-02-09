using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

    }

    public class ChkEmailBehavior : Behavior<Entry>
    {
        private readonly Regex _regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        public bool IsValid { get; private set; }

        protected override void OnAttachedTo(Entry bindable)
        {
            //ハンドラの追加
            bindable.TextChanged += CheckEmail;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            //ハンドラの削除
            bindable.TextChanged -= CheckEmail;
        }

        private void CheckEmail(object sender, TextChangedEventArgs e)
        {
            //文字列がEmailとして正しいかどうかのチェック
            var m = _regex.Match(e.NewTextValue);
            //正かどうかによってテキストの色を変化させる
            ((Entry)sender).TextColor = m.Success ? Color.Default : Color.Red;
            IsValid = m.Success;
        }

    }
}
