using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyVault.Data;
using MyVault.Models;

namespace MyVault.Pages.Admin
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<VaultUser> VaultUser { get; set; }

        public async Task OnGet()
        {
            VaultUser = await _db.VaultUser.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(string id)
        {
            var user = await _db.VaultUser.FindAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            _db.VaultUser.Remove(user);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
