using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class ProductList : IEntity
    {
        [Key]
        public long productListid { get; set; }
        public long carrierid { get; set; }
        public string GTIN { get; set; }
        public string lotNumber { get; set; }
        public DateTime productionDate { get; set; }
        public DateTime expirationDate { get; set; }
        public string PONumber { get; set; }

    }
}
