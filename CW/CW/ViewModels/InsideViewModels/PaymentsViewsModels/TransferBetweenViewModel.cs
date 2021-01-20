﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using CW.Services;
using Xamarin.Forms;
using CW.Views.InsideViews.Operations;
using System.Collections.ObjectModel;
using CW.Models;
using CW.Converters;
using CW.ViewModels.InsideViewModels.OperationsViewModels;
using CW.Commands;
using Xamarin.Forms.Internals;

namespace CW.ViewModels.InsideViewModels.PaymentsViewsModels
{
    public class TransferBetweenViewModel : BaseViewModel
    {
        public INavigation Navigation { get; private set; }
        public ICommand TransferCommand { get; private set; }
        public ObservableCollection<BankCard> BankCards { get; private set; }
        public ObservableCollection<BankAccount> BankAccounts { get; private set; }
        public TransferBetweenViewModel(INavigation navigation, ObservableCollection<BankCard> cards, ObservableCollection<BankAccount> accounts)
        {
            Navigation = navigation;
            BankCards = new ObservableCollection<BankCard>();
            cards.Where(x => x.IsWorked == true).ForEach(x => BankCards.Add(x));
            BankAccounts = accounts;
            TransferCommand = new TapCardCommand(Transfer);
        }
        private void Transfer(object item)
        {
            var selectedItem = item as BankCard;
            Navigation.PushAsync(new TopUpCardView(new TopUpCardViewModel(Navigation, BankCards, BankAccounts, selectedItem)));
        }
    }
}