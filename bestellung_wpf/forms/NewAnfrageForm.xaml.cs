﻿using bestellung_wpf.models;
using bestellung_wpf.utils;
using bestellung_wpf.views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace bestellung_wpf.forms
{
    /// <summary>
    /// Interaction logic for NewAnfrageForm.xaml
    /// </summary>
    public partial class NewAnfrageForm : Window
    {
        private NewAnfrageView _anfrageView;
        public NewAnfrageView AnfrageView { get { return _anfrageView; } set { _anfrageView = value; } }

        public BestellungItemUi BestellungItem { get { return _anfrageView.BestellungItem; } }

        public bool IsSelected { get => _isSelected; set => _isSelected = value; }

        private bool _isSelected = false;

        public NewAnfrageForm(MainWindowView view, Window owner)
        {
            _anfrageView = new NewAnfrageView(view);

            Owner = owner;

            InitializeComponent();

            WindowHelper.Initialize(this);

        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (BestellungItemValidator.IsValid(_anfrageView.BestellungItem)) {
                _isSelected = true;

                Close();
            }
            
        }

    }
}
