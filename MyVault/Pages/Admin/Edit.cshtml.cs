using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyVault.Data;
using MyVault.Models;
using MyVault.Utilities;

namespace MyVault.Pages.Admin
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public VaultUser VaultUser { get; set; }

        public async Task OnGet(string id)
        {
            VaultUser = await _db.VaultUser.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var UserFromDb = await _db.VaultUser.FindAsync(VaultUser.Id);
                UserFromDb.Name = VaultUser.Name;
                UserFromDb.Address = VaultUser.Address;
                UserFromDb.City = VaultUser.City;
                UserFromDb.PostalCode = VaultUser.PostalCode;
                UserFromDb.PhoneNumber = VaultUser.PhoneNumber;
                UserFromDb.Email = VaultUser.Email;

                _db.VaultUser.Update(UserFromDb);
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
