using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class Contacts
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Number { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }
        public int ContactTypeId { get; set; }
    }
}
