using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace bestellung_wpf.utils
{
    public class CustomeTextBox: TextBox
    {
        private bool _isNumber = false;
        private bool _selectOnFocus = false;

        public CustomeTextBox() {

            this.PreviewTextInput += CustomeTextBox_PreviewTextInput;
            this.GotFocus += CustomeTextBox_GotFocus;
        }

        public bool IsNumber { get => _isNumber; set => _isNumber = value; }
        public bool SelectOnFocus { get => _selectOnFocus; set => _selectOnFocus = value; }

        private void CustomeTextBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_selectOnFocus)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void CustomeTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (_isNumber)
            {
                GeneralUtils.isNumberOrDecimal(sender, e);
            }
        }
    }
}
