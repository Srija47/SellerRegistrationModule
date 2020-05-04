using System;
using System.Collections.Generic;

namespace AccountService.Models
{
    public partial class Items
    {
        public int Itemid { get; set; }
        public string Itemname { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public int? Stocknumber { get; set; }
        public string Remarks { get; set; }
        public int? Sellerid { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
