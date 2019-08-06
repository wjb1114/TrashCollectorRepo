using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Collectr.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int ZipCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}