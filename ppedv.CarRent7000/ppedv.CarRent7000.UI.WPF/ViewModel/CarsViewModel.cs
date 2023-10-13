using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ppedv.CarRent7000.Model.Contracts;
using ppedv.CarRent7000.Model.DomainModel;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace ppedv.CarRent7000.UI.WPF.ViewModel
{
    public class CarsViewModel : ObservableObject
    {
        private readonly IRepository repo;
        private Car selectedCar;


        public ObservableCollection<Car> Cars { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand NewCarCommand { get; set; }

        public Car SelectedCar
        {
            get => selectedCar;
            set
            {
                selectedCar = value;
                OnPropertyChanged(nameof(SelectedCar));
                OnPropertyChanged(nameof(PS));
            }
        }

        public string PS
        {
            get
            {
                if (SelectedCar == null)
                    return "-";
                return (SelectedCar.KW * 1.35962).ToString("n2") + " PS";
            }
        }

        public CarsViewModel(IRepository repo)
        {
            this.repo = repo;
            Cars = new ObservableCollection<Car>(repo.GetAll<Car>());
            SaveCommand = new SaveCommand(repo);

            NewCarCommand = new RelayCommand(() =>
            {
                var car = new Car() { Model = "NEU" };
                repo.Add(car);
                Cars.Add(car);
                SelectedCar = car;
            });
        }

    }


    public class SaveCommand : ICommand
    {
        public IRepository Repo { get; }

        public event EventHandler? CanExecuteChanged;

        public SaveCommand(IRepository repo)
        {
            Repo = repo;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Repo.SaveAll();
        }
    }
}
