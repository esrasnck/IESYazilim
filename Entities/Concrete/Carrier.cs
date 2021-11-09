using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Carrier:IEntity
    {
        [Key]
        public long carrierid { get; set; }
        public long transferid { get; set; }
        public string carrierLabel { get; set; }
        public string containerType { get; set; }
        public long altcarrierid { get; set; }

    }
}
