﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf.models
{
    public class BestellungItemCollection
    {
        public ObservableCollection<BestellungItemUi> List { get; set; } = new ObservableCollection<BestellungItemUi>();
    }
}
