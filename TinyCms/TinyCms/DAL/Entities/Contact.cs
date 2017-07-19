﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TinyCms.DAL.Entities
{
    [Table("Contact")]
    public class Contact : EntityBase
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        [Required]
        [MaxLength(500)]
        public string Message { get; set; }
    }
}
