using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PanelAdmin.Entities
{
    public class Company /*: INotifyPropertyChanged*/
    {
        //Método que notifica la actualización de la propiedad
        //public event PropertyChangedEventHandler? PropertyChanged;
        //protected void NotifyPropertyChanged(String info) if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(info));


        public int Id { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }

        private BitmapImage _bitmapImage;
        public BitmapImage BitmapImage { get
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

        //public String Name {
        //    get { return _name; }
        //    set
        //    {
        //        if (value != _name)
        //        {
        //            _name = value;
        //            NotifyPropertyChanged("Name");
        //        }
        //    }
        //}

        public Company(string name)
        {
            Name = name;
        }
    }
}
