using bestellung_wpf.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf
{
    public class GlobalValues : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private User _currentUser = null;

        public User CurrentUser {
            get { return _currentUser; }
            set {
                _currentUser = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
