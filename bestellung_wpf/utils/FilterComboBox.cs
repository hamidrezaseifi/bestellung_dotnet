using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace bestellung_wpf.utils
{
    public class FilterComboBox: ComboBox
    {
        private bool _isFiltered = false;

        public FilterComboBox() {
            KeyUp += FilterComboBox_KeyUp;
        }

        public bool IsFiltered { get => _isFiltered; set => _isFiltered = value; }

        private void FilterComboBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (_isFiltered) {
                CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(this.ItemsSource);

                itemsViewOriginal.Filter = ((o) =>
                {
                    if (String.IsNullOrEmpty(this.Text)) return true;
                    else
                    {
                        if (((string)o).ToUpper().Contains(this.Text.ToUpper())) return true;
                        else return false;
                    }
                });

                itemsViewOriginal.Refresh();
            }
        }
    }
}
