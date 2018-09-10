using PhotoGalleryApp.Services;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PhotoGalleryApp.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PhotoGalleryApp
{
    public partial class App : Application
    {

        private static PhotoRepository photoRepository = null;

        public static PhotoRepository PhotoRepository
        {
            get
            {
                if (photoRepository == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PhotoDb.db");
                    return new PhotoRepository(dbPath);
                }
                return photoRepository;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
