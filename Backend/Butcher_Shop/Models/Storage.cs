using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Models
{
    public class Storage
    {
        public Storage() => this.StorageArticles = new HashSet<StorageArticle>();

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(64)]
        public string Address { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Area { get; set; }

        [Required]
        public int ButcherStoreId { get; set; }
        public virtual ButcherStore ButcherStore { get; set; }
        public virtual ICollection<StorageArticle> StorageArticles { get; set; }
    }
}
