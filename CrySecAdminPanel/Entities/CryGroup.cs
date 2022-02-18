using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace PanelAdmin.Entities
{
    public class CryGroup
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public String Image { get; set; }

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

        public Boolean IsExpanded { get; set; } = false;
        public List<CryUser> regularUsers { get; set; }
        
        public List<CryUser> adminUsers { get; set; }

        public CryGroup(int id, String name, String type)
        {
            this.id = id;
            this.Name = name;
            this.Type = type;
        }

        public String ToString()
        {
            return "ID: " + id + "Name: " + Name+ " Type: " + Type+ "Image: " + Image + "";
        }
    }
}