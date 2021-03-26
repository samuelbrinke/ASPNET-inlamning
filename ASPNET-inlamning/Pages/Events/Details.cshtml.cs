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

        [BindProperty]
        public bool AttendeeIsAttending { get; set; } = false;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Event = await _context.Events
                .Include(e => e.Organizer)
                .FirstOrDefaultAsync(m => m.EventID == id);

            AttendeeEvent attendeeEvent = await _context.AttendeeEvents
                .Where(a => a.Attendee.AttendeeID == 1 && a.EventID == id)
                .FirstOrDefaultAsync();

            if (attendeeEvent != null)
            {
                AttendeeIsAttending = true;
            }

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

            AttendeeEvent joinEvent = new AttendeeEvent()
            {
                Attendee = await _context.Attendees.Where(a => a.Name == "Samme").FirstOrDefaultAsync(),
                Event = await _context.Events.Where(e => e.EventID == id).FirstOrDefaultAsync()
            };

             _context.AttendeeEvents.Add(joinEvent);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = id });
        }
    }
}
