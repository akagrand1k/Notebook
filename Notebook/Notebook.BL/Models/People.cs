using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Notebook.BL.Models
{
    [Serializable]
    public class People
    {
        public string Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int DateBirthday { get; set; }
        public string PhoneNumber { get; set; }
    }
}
