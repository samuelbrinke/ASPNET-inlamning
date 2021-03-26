using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPNET_inlamning.Data;
using ASPNET_inlamning.Models;

namespace ASPNET_inlamning.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly ASPNET_inlamning.Data.ApplicationDbContext _context;

        public DetailsModel(ASPNET_inlamning.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Event Event { get; set; }
        //public bool IsListedInThisEvent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events
                .Include(e => e.Organizer)
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var Event = await _context.Events.Include(o => o.Attendees).FirstOrDefaultAsync(m => m.EventID == id);
            //var attendeeModel = await _context.Attendees.FirstOrDefaultAsync(m => m.Name == "Samme");


            /*            var attendeeModel2 = _context.Attendees.Where(a => a.AttendeeID == 1).FirstOrDefault();
                        var Event2 = _context.Events.Where(e => e.EventID == id).FirstOrDefault()*/

            //Event.Attendees.Add(attendeeModel);

            AttendeeEvent joinEvent = new AttendeeEvent()
            {
                Attendee = await _context.Attendees.Where(a => a.Name == "Samme").FirstOrDefaultAsync(),
                Event = await _context.Events.Where(e => e.EventID == id).FirstOrDefaultAsync()
            };

             _context.AttendeeEvents.Add(joinEvent);

            await _context.SaveChangesAsync();

            return RedirectToPage("./index");
        }
    }
}
