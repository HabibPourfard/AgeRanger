using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using    System.ComponentModel.DataAnnotations;

namespace AgeRanger.Model
{
    public class PersonDetail
    {
        [Required]
        public long Id { get; set; }

        [MinLength(1), Required]
        public string FirstName { get; set; }

        [MinLength(1), Required]
        public string LastName { get; set; }

        [Range(0, int.MaxValue)]
        public long? Age { get; set; }

        public string AgeGroupName { get; set; }

        public string FullName => FirstName + " " + LastName;
    }
}
