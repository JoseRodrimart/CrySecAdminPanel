using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanelAdmin.Entities
{
    public class Company : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private String _name;
        public String Name {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public Company(string name)
        {
            Name = name;
        }

        //Método que notifica la actualización de la propiedad
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
