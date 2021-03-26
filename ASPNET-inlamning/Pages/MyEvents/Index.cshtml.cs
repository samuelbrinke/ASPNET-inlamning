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
    public class IndexModel : PageModel
    {
        private readonly ASPNET_inlamning.Data.ApplicationDbContext _context;

        public IndexModel(ASPNET_inlamning.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AttendeeEvent> AttendeeEvent { get;set; }

        public async Task OnGetAsync()
        {
            AttendeeEvent = await _context.AttendeeEvents
                .Include(a => a.Attendee)
                .Include(a => a.Event).ToListAsync();
        }
    }
}
