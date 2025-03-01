using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMVC.Core.Models
{
    public class Feature : BaseEntity
    {
        [Required]
        public string Icon { get; set; }
        [StringLength(50)]
        public string Title { get; set; } = null!;
        public string Description { get; set; }     

    }
}
