using PhotoGalleryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoGalleryApp
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<PhotoClass> Photos = new ObservableCollection<PhotoClass>();
        public MainPage()
        {
            InitializeComponent();
            MainList.ItemsSource = Photos;
        }

        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Photos = new ObservableCollection<PhotoClass>(await App.PhotoRepository.GetAllPhoto());
            MainList.ItemsSource = Photos;
        }

        async void Handle_Refreshing(object sender, System.EventArgs e)
        {
            Loader.IsVisible = true;
            MainList.IsRefreshing = true;
            Photos = new ObservableCollection<PhotoClass>(await App.PhotoRepository.GetAllPhoto());
            MainList.ItemsSource = Photos;
            Loader.IsVisible = false;
            MainList.IsRefreshing = false;
        }

        private async void NewPhotoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPhotoPage());
        }

        private void DeletePhoto_Clicked(object sender, EventArgs e)
        {

        }
    }
}
