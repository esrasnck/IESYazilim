using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class SerialNumber:IEntity
    {
        [Key]
        public long serialNumberid { get; set; }
        public long productListid { get; set; }
        public string serialNumber { get; set; }
        public int hataKodu { get; set; }

    }
}
