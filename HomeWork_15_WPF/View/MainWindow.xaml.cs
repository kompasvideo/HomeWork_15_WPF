﻿using HomeWork_15_WPF.Model;
using HomeWork_15_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

namespace HomeWork_15_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Выполняется при загрузке ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            MainViewModel.Source = (ListCollectionView)CollectionViewSource.GetDefaultView(LVClients.ItemsSource);
            MainViewModel.Source.Filter = new Predicate<object>(MainViewModel.MyFilter);
        }

        /// <summary>
        /// Подписывается на сообщение ReturnAddClient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<Client>(MainViewModel.ReturnAddClient);
            Messenger.Default.Register<Dictionary<Client, uint>>(MainViewModel.ReturnMoveMoney);
            Messenger.Default.Register<Deposit>(MainViewModel.ReturnAddDepositNoCapitalize);
            Messenger.Default.Register<DepositPlusCapitalize>(MainViewModel.ReturnAddDepositCapitalize);
            Messenger.Default.Register<BankDepartment>(AddDepositCapitalizeViewModel.SetBankDepartment);
            Messenger.Default.Register<Dictionary<BankDepartment, uint>>(AddDepositNoCapitalizeViewModel.SetBankDepartment);
            Messenger.Default.Register<Dictionary<Client, short>>(RateViewModel.SetClient);
        }

        /// <summary>
        /// Отписывается от сообщение ReturnAddClient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister<Client>(MainViewModel.ReturnAddClient);
            Messenger.Default.Unregister<Dictionary<Client, uint>>(MainViewModel.ReturnMoveMoney);
            Messenger.Default.Unregister<Deposit>(MainViewModel.ReturnAddDepositNoCapitalize);
            Messenger.Default.Unregister<DepositPlusCapitalize>(MainViewModel.ReturnAddDepositCapitalize);
            Messenger.Default.Unregister<BankDepartment>(AddDepositCapitalizeViewModel.SetBankDepartment);
            Messenger.Default.Unregister<Dictionary<BankDepartment, uint>>(AddDepositNoCapitalizeViewModel.SetBankDepartment);
            Messenger.Default.Unregister<Dictionary<Client, short>>(RateViewModel.SetClient);
        }
    }
}
