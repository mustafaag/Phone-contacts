using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ContactType
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
