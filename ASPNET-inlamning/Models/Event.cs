using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_inlamning.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Title { get; set; }
        public int OrganizerID { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int SpotsAvalible { get; set; }

        public List<Attendee> Attendees { get; set; }
    }
}
