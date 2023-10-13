using ppedv.CarRent7000.Model.Contracts;
using ppedv.CarRent7000.Model.DomainModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;


namespace ppedv.CarRent7000.UI.WPF.ViewModel
{
    public class CarsViewModel : INotifyPropertyChanged
    {
        private readonly IRepository repo;
        private Car selectedCar;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Car> Cars { get; set; }

        public ICommand SaveCommand{ get; set; }
        public Car SelectedCar
        {
            get => selectedCar; 
            set
            {
                selectedCar = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(SelectedCar)));
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(PS)));
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
        }

        //hack pfusch!!!
        public CarsViewModel() : this(new ppedv.CarRent7000.Data.EfCore.CarRentRepository())
        { }
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
