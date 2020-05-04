using AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Repositories
{
   public interface IAccountRepository
    {
        public void SellerRegister(Seller seller);
        public Seller ValidateSeller(string uname, string pwd);
    }
}
