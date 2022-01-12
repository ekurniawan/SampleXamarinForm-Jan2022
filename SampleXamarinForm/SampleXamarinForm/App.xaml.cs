using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleXamarinForm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            /*halaman yang pertama kali ditampilkan
             * ddddd
             * ddddd
             */
            MainPage = new NavigationPage(new MyTabbedPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
