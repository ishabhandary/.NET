using BankOfSuccessCS.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccessCS.Business.Core
{
    public interface ICardManager
    {
        void AddCard(Card card);
        void DispatchCards();
    }
}
