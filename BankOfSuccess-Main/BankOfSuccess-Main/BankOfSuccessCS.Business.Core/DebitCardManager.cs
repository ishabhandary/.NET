﻿using BankOfSuccessCS.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankOfSuccessCS.Business.Core
{
    public class DebitCardManager : ICardManager
    {
        private ConcurrentQueue<Card> _cards = new ConcurrentQueue<Card>();
        private Dispatcher _dispatcher = new Dispatcher();
        public void AddCard(Card card)
        {
            _cards.Enqueue(card);
        }

        public void DispatchCards()
        {
            Task t = Task.Factory.StartNew(() =>
            {
                foreach (var card in _cards)
                {
                    _dispatcher.Dispatch(card);
                }
            });
        }
    }

}
