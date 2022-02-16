using System;
using System.Windows.Media.Imaging;

namespace PanelAdmin.Entities
{
    public class CryUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Image { get; set; }

        private BitmapImage _bitmapImage;
        public BitmapImage BitmapImage
        {
            get
            {
                if (_bitmapImage == null)
                {
                    if (Image == null)
                    {
                        _bitmapImage = new BitmapImage(new Uri(@"C:\Users\Fernando\Source\Repos\CrySecAdminPanel\CrySecAdminPanel\Resources\Images\placeholder.jpg", UriKind.Absolute));
                    }
                    else
                    {
                        _bitmapImage = new BitmapImage(new Uri(Image, UriKind.Absolute));
                    }
                }
                return _bitmapImage;
            }
        }
        //public Company company;
        public CryUser(int id, string name, string mail, string image)
        {
            this.Id = id;
            this.Name = name;
            this.Mail = mail;
            this.Image = image;
        }

        public string ToString()
        {
            return "CryUser:{id: " + Id + " name: " + Name + " mail: " + Mail + " image: " + Image + "}";
        }
    }
}