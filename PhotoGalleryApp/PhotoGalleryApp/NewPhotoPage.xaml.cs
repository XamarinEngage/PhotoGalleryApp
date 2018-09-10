using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.FilePicker;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using PhotoGalleryApp.Models;

namespace PhotoGalleryApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewPhotoPage : ContentPage
	{
		public NewPhotoPage ()
		{
			InitializeComponent ();
		}

        private async  void btnImagePicker_Clicked(object sender, EventArgs e)
        {
            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile();

                if (pickedFile == null)
                {
                    int yyu = 8;
                    yyu += 21;
                }
                    if (pickedFile != null)
                {
                    lblImage.Text = pickedFile.FilePath;
                    
                    
                    // Save all types of files
                   // var saveFile = await CrossFilePicker.Current.SaveFile(pickedFile);
                    int yuy = 99;

                    if (pickedFile.FileName.EndsWith("jpg", StringComparison.Ordinal)
                            || pickedFile.FileName.EndsWith("png", StringComparison.Ordinal))
                    {
                        //Save on Image files
                    //    var saveFile = await CrossFilePicker.Current.SaveFile(pickedFile);
                        FileImagePreview.Source = ImageSource.FromStream(() => pickedFile.GetStream());
                        FileImagePreview.IsVisible = true;

                        int yy = 0;

                        //string dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "/MyFolder");

                        //string dirPath1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


                        var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                        if (status != PermissionStatus.Granted)
                        {
                            await DisplayAlert("Need storage", "Request storage permission granted", "OK");
                            if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                            {
                                await DisplayAlert("Need storage", "Request storage permission", "OK");
                            }

                            var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
                            //Best practice to always check that the key exists
                            if (results.ContainsKey(Permission.Storage))
                                status = results[Permission.Storage];
                        }
                        if (status == PermissionStatus.Granted)
                        {
                            await DisplayAlert("Need storage", "Request storage permission granted", "OK");
                        }

                        string tes = "/MyImages/" + pickedFile.FileName;
                        //string imageFullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "/MyImages/");
                        //if (!Directory.Exists(imageFullPath))
                        //Directory.CreateDirectory(imageFullPath);
                        //string dirPath = Path.Combine(temp, pickedFile.FileName);
                        string dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), pickedFile.FileName);

                        ImageEntry.Text = dirPath;

                        lblImage.Text = dirPath;
                        PhotoNameEntry.Text = pickedFile.FileName;
                        DateTakenEntry.Text = DateTime.Now.ToString();

                        if (File.Exists(dirPath))
                            File.Delete(dirPath);

                        File.WriteAllBytes(dirPath, pickedFile.DataArray);
                        


                    }
                    else
                    {
                        FileImagePreview.IsVisible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error Message", ex.Message, "Cancel");
                //throw;
            }

        }

        private async void Handle_Clicked(object sender, EventArgs e)
        {
            var photo = new PhotoClass
            {
                PhotoName = PhotoNameEntry.Text,
                DateTaken = DateTakenEntry.Text,
                ImagePath = lblImage.Text
         
            };
            try
            {
                await App.PhotoRepository.CreatePhoto(photo);
                await DisplayAlert("Congrats", "Photo Added Successfully", "Continue");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Continue");
            }
        }
    }
}