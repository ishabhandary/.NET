using BankOfSuccessCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccessCS.Business.Core
{
    internal class Dispatcher
    {
        public void Dispatch(Card card)
        {
            card.Account.Notify("Your Card Is Dispatched," + card.Account.Email);
        }
    }
}
