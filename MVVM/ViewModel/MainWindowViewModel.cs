using System.Collections.ObjectModel;
using MVVMExample.Model;
using MVVMExample.MVVM;

namespace MVVMExample.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem());
        public RelayCommand SaveCommand => new RelayCommand(execute => SaveItem(), canExecute => CanSave());
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();
           
        }

        private bool CanSave()
        {
          return Items != null;
        }

        private void SaveItem()
        {
            //code to save items to database or file
        }

        private void DeleteItem()
        {
            if (SeletectedItem != null)
            {
                Items.Remove(SeletectedItem);
            }
        }

        private void AddItem()
        {
            var item = new Item
            {
                Name = "New Name",
                Quantity = 0,
                SerialNumber = "New Serial"
            };
            Items.Add(item);
        }

        public ObservableCollection<Item> Items { get; set; }


        private Item seletectedItem;

        public Item SeletectedItem
        { 
            get 
            {
                return seletectedItem;
            }
            set
            {
                seletectedItem = value ;
                OnPropertyChanged();
            } 
        }

      
    }
}
