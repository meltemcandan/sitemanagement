﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.DTO.Message
{
    public class MessageDto
    {
        public int SendedPersonId { get; set; }

        public string Subject { get; set; }

        public string Text { get; set; }

        public int? LinkedMessageId { get; set; }
    }
}
