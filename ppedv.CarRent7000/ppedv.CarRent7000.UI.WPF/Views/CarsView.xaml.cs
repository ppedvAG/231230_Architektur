using Microsoft.Extensions.DependencyInjection;
using ppedv.CarRent7000.UI.WPF.ViewModel;
using System.Windows.Controls;

namespace ppedv.CarRent7000.UI.WPF.Views
{
    /// <summary>
    /// Interaction logic for CarsView.xaml
    /// </summary>
    public partial class CarsView : UserControl
    {
        public CarsView()
        {
            DataContext = App.Current.Services.GetService<CarsViewModel>();

            InitializeComponent();
        }
    }
}
