
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
                    Description ="CSharp Fundamental Training"},
                new Course() { Title ="ASP Core MVC",
                    Description="ASP COre MVC Training for Web Application"},
                new Course() { Title ="Blazor SPA",
                    Description="SPA Web Development with Blazor"}
            };
            lvCourse.ItemsSource = lstCourse;
        }
    }
}