using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace PhotoGalleryApp.Models
{   
        public class PhotoClass : INotifyPropertyChanged
        {
            private string photoName;
            private string dateTaken;
            private string imagePath;

            

            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }

            public PhotoClass()
            {
            }
            public string PhotoName
            {
                get => photoName;
                set
                {
                    photoName = value;
                    OnPropertyChanged("PhotoName");
                }
            }


            public string DateTaken
            {
                get => dateTaken;
                set
                {
                    dateTaken = value;
                    OnPropertyChanged("DateTaken");
                }
            }
                        
            public string ImagePath
            {
                get => imagePath;
                set
                {
                    imagePath = value;
                    OnPropertyChanged("ImagePath");
                }
            }


            //[Ignore]
            //public string Info
            //{
            //    get
            //    {
            //        return $"{Name}, {Phone}, {Email}";
            //    }
            //}


            [Ignore]
            public object getImageSource
            {
                get
                {
                    return ImageSource.FromFile(ImagePath);
                }
            }

        //public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
