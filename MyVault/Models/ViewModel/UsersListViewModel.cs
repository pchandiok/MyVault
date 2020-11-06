using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVault.Models.ViewModel
{
    public class UsersListViewModel
    {
        public IList<VaultUser> VaultUser { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
