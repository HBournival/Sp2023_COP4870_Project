using MAUI.lms.ViewModels;

namespace MAUI.lms
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainVM();
        }

        private void StudentClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Student");
        }

        private void InstructorClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Instructor");
        }
    }
}