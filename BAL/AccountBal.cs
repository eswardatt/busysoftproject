using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Busysoft.DAL;
using Busysoft.Entities;

namespace Busysoft.BAL
{
    public class AccountBal
    {
        BankingRepo bankingRepo = new BankingRepo();
        public List<AccountDetails> GetAccountDetails(int formno)
        {
            List<AccountDetails> accountDetails = (from ll in bankingRepo.GetAccountDetails()
                                                  where ll.FormNo == formno
                                                  select ll).ToList();
            return accountDetails;
        }

    }
}