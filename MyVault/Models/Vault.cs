using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyVault.Models
{
    public class Vault
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlUsername { get; set; }
        public string UrlPassword { get; set; }
        public string Notes { get; set; }
        public int VaultUserId { get; set; }

        [ForeignKey("VaultUserId")]
        public VaultUser VaultUser { get; set; }
    }
}
