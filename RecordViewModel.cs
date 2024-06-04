using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class RecordViewModel : INotifyPropertyChanged
    {

        private readonly ObservableCollection<Record> _records = new ObservableCollection<Record>();
        public ObservableCollection<Record> Records => _records;

        public event PropertyChangedEventHandler PropertyChanged;

        public RecordViewModel()
        {
            LoadUsers();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LoadUsers()
        {
            _records.Clear();
            foreach (var user in DbConnector.LoadAll())
                {
                    
                    _records.Add(user);
                }
        }

    }
}
