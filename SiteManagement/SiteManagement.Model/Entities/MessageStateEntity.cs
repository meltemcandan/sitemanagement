﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Model.Entities
{
    /// <summary>
    /// Mesaj Durumu => Okundu / Okunmadı
    /// </summary>
    public class MessageStateEntity : BaseEntity
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}
