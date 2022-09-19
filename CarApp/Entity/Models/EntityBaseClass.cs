using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public abstract class EntityBaseClass
    {
        [Key]
        public virtual long Id { get; set; }
    }
}
