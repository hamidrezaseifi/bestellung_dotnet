using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf.views
{
    public class TestFormView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _testSourceValue = "sss";
        private string _testTargetValue = "tttt";

        public string TestSourcetValue { get => _testSourceValue; set { _testSourceValue = value; NotifyPropertyChanged(); } }

        public string TestTargetValue { get => _testTargetValue; set => _testTargetValue = value; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (propertyName.Equals("TestSourcetValue")) {
                TestTargetValue = _testSourceValue + " is changed!";
                _testSourceValue = _testSourceValue;

                NotifyPropertyChanged("TestTargetValue");
            }
            
        }

    }
}
