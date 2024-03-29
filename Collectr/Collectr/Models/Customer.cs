﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Collectr.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public DayOfWeek WeeklyPickupDay { get; set; }
        public int Balance { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ExtraPickupDay { get; set; } = null;
        [Column(TypeName = "date")]
        public DateTime? NoPickupStart { get; set; } = null;
        [Column(TypeName = "date")]
        public DateTime? NoPickupEnd { get; set; } = null;
        public DateTime? LastPickedUp { get; set; }
        public DateTime? NextPickup { get; set; }
        public bool LatestPickedUp { get; set; } = false;
    }
}