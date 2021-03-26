using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPNET_inlamning.Data;
using ASPNET_inlamning.Models;

namespace ASPNET_inlamning.Pages.MyEvents
{
    public class DeleteModel : PageModel
    {
        private readonly ASPNET_inlamning.Data.ApplicationDbContext _context;

        public DeleteModel(ASPNET_inlamning.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AttendeeEvent AttendeeEvent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AttendeeEvent = await _context.AttendeeEvents
                .Include(a => a.Attendee)
                .Include(a => a.Event).FirstOrDefaultAsync(m => m.AttendeeEventID == id);

            if (AttendeeEvent == null)
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

            AttendeeEvent = await _context.AttendeeEvents.FindAsync(id);

            if (AttendeeEvent != null)
            {
                _context.AttendeeEvents.Remove(AttendeeEvent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
