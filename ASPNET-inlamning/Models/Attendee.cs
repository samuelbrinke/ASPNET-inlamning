﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_inlamning.Models
{
    public class Attendee
    {
        public int AttendeeID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public List<Event> Events { get; set; }
    }
}
