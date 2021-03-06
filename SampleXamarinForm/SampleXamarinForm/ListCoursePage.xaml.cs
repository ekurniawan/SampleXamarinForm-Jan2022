
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
    public partial class ListCoursePage : ContentPage
    {
        public ListCoursePage()
        {
            InitializeComponent();

            List<Course> lstCourse = new List<Course>()
            {
                new Course() { Title ="CSharp Fundamental",
                    Description ="CSharp Fundamental Training" ,
                    CoverPic="https://i0.wp.com/blog.mzikmund.com/wp-content/uploads/2019/02/microsoft-xamirin-1.jpg"},
                new Course() { Title ="ASP Core MVC",
                    Description="ASP COre MVC Training for Web Application",
                    CoverPic="https://i0.wp.com/blog.mzikmund.com/wp-content/uploads/2019/02/microsoft-xamirin-1.jpg"},
                new Course() { Title ="Blazor SPA",
                    Description="SPA Web Development with Blazor",
                    CoverPic="https://i0.wp.com/blog.mzikmund.com/wp-content/uploads/2019/02/microsoft-xamirin-1.jpg"}
            };
            lvCourse.ItemsSource = lstCourse;
        }

        private void lvCourse_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var data = (Course)e.Item;
            DisplayAlert("Keterangan", $"{data.Title} {data.Description}", "OK");
        }
    }
}