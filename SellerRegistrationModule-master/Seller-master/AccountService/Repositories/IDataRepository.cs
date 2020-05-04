using System.Collections.Generic;

namespace AccountService.Repositories
{
    public interface IDataRepository<Seller, SellerDto>
    {
        IEnumerable<Seller> GetAll();
        //Seller Get(string uname,string pwd);
        SellerDto GetDto(string uname,string pwd);
        void Add(Seller seller);
    }
}
