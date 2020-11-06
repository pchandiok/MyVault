using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyVault.Data;
using MyVault.Models;
using MyVault.Models.ViewModel;
using MyVault.Utilities;

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

        public UsersListViewModel UsersListVM;


        public async Task<IActionResult> OnGet(int UserPage=1)
        {
            UsersListVM = new UsersListViewModel()
            {
                VaultUser = await _db.VaultUser.ToListAsync()
            };

            StringBuilder param = new StringBuilder();
            param.Append("/Admin?UserPage=:");

            var count = UsersListVM.VaultUser.Count;

            UsersListVM.PagingInfo = new PagingInfo()
            {
                CurrentPage = UserPage,
                ItemsPerPage = SD.PaginationUsersPageSize,
                TotalItems = count,
                UrlParam = param.ToString()
            };

            UsersListVM.VaultUser = UsersListVM.VaultUser.OrderBy(p => p.Email)
                .Skip((UserPage - 1) * SD.PaginationUsersPageSize)
                .Take(SD.PaginationUsersPageSize).ToList();

            return Page();
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
