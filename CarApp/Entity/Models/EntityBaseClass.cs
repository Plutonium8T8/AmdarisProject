using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
    public abstract class EntityBaseClass
    {
        [Key]
        [Required]
        public virtual long Id { get; set; }
    }
}
