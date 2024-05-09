using bestellung_wpf.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace bestellung_wpf
{
    public class GlobalValues : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private User _currentUser = null;

        private List<User> _userList = new List<User>();

        public List<User> UserList
        {
            get { return _userList; }
            set
            {
                _userList = value;
            }
        }

        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush CurrentUserBrush
        {
            get { return _currentUser.Brush; }
          
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
