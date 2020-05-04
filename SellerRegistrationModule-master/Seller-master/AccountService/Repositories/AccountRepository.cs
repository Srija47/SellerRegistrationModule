using AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using AccountService.Models;

namespace AccountService.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SellerDBContext _context;
        public AccountRepository(SellerDBContext context)
        {
            _context = context;
        }

        public void SellerRegister(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller ValidateSeller(string uname, string pwd)
        {

            Seller b = _context.Seller.SingleOrDefault(e => e.Username == uname && e.Password == pwd);
            if(b.Username==uname&&b.Password==pwd)
            {
                return b;
            }
            else
            {
                Console.WriteLine("Not Valid User");
                return b;
            }
           
        }
    }
}
