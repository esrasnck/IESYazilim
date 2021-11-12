using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Transfer:IEntity
    {
        [Key]
        public long id { get; set; }
        public string sourceGLN { get; set; }
        public string destinationGLN { get; set; }
        public string actionType { get; set; }
        public string shipTo { get; set; }
        public string documentNumber { get; set; }
        public DateTime? documentDate { get; set; }
        public string note { get; set; }
        public string version { get; set; }
    }
}
