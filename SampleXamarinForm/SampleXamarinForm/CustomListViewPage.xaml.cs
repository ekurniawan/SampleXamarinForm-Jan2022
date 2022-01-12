using SampleXamarinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleXamarinForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomListViewPage : ContentPage
    {
        public CustomListViewPage()
        {
            InitializeComponent();

            List<Course> lstCourse = new List<Course>()
            {
                new Course() { Title ="CSharp Fundamental",
                    Description ="CSharp Fundamental Training" ,
                    CoverPic="https://i0.wp.com/blog.mzikmund.com/wp-content/uploads/2019/02/microsoft-xamirin-1.jpg",
                    Price=2000000},
                new Course() { Title ="ASP Core MVC",
                    Description="ASP COre MVC Training for Web Application",
                    CoverPic="https://i0.wp.com/blog.mzikmund.com/wp-content/uploads/2019/02/microsoft-xamirin-1.jpg",
                    Price=3000000},
                new Course() { Title ="Blazor SPA",
                    Description="SPA Web Development with Blazor",
                    CoverPic="https://i0.wp.com/blog.mzikmund.com/wp-content/uploads/2019/02/microsoft-xamirin-1.jpg",
                    Price=4000000}
            };
            lvCourse.ItemsSource = lstCourse;
        }

        private void lvCourse_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var data = (Course)e.Item;
            DisplayAlert("Selected", $"Title: {data.Title} \n Price: Rp.{data.Price} \n {data.Description}","OK");
        }

        private void btnShowUsername_Clicked(object sender, EventArgs e)
        {
            string username = Global.Instance.username;
            DisplayAlert("Username", $"Username : {username}", "OK");
        }
    }
}