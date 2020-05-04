using AccountService.Models;
using AccountService.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using static AccountService.DataManager.SellerDataManager;

namespace AccountService.DataManager
{
    public class SellerDataManager : IDataRepository<Seller, SellerDto>
    {
        private readonly SellerDBContext _context;
        
        public SellerDataManager(SellerDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Seller> GetAll()
        {
            return _context.Seller
                .Include(seller => seller.Items)
                .ToList();
        }
        public SellerDto GetDto(string uname,string pwd)
        {
           // _context.ChangeTracker.LazyLoadingEnabled = true;
            Seller seller = _context.Seller
                       .SingleOrDefault(e => e.Username == uname && e.Password == pwd);
                return SellerDtoMapper.MapToDto(seller);
        }

        public class SellerDto
        {
            public SellerDto()
            {
            }

            public int Sellerid { get; set; }

            public string Username { get; set; }
            public string Password { get; set; }
            public string Companyname { get; set; }
            public string Briefaboutcompany { get; set; }
            public string Postaladdress { get; set; }
            public string Website { get; set; }
            public string Emailid { get; set; }
            public string Contactnumber { get; set; }

            public SellerDto Seller { get; set; }
        }

        public static class SellerDtoMapper
        {
            public static SellerDto MapToDto(Seller seller)
            {
                return new SellerDto()
                {
                    Sellerid = seller.Sellerid,
                    Username = seller.Username,
                    Password = seller.Password,
                };

            }
        }

        public void Add(Seller seller)
        {
            _context.Seller.Add(seller);
            _context.SaveChanges();
        }
    }
}
