using System.Configuration;
using System;

namespace BankOfSuccessCS.Business.Core
{
    public static class CardManagerFactory
    {
        public static ICardManager GetCardManager()
        {
            string dataLoaderClassName = ConfigurationManager.AppSettings["CardManager"] + "," + "BankOfSucessCS.Business.Core";
            if (string.IsNullOrEmpty(dataLoaderClassName)) { return null; }
            Type theType = Type.GetType(dataLoaderClassName);
            return (ICardManager)Activator.CreateInstance(theType);
        }
    }
}