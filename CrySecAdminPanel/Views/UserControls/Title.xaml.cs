using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrySecAdminPanel.Views.UserControls
{
    /// <summary>
    /// Lógica de interacción para Title.xaml
    /// </summary>
    public partial class Title : UserControl
    {
        public string Text { get; set; } = "Title";

        public Title() 
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
