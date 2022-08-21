using System.ComponentModel.DataAnnotations;

namespace VillaProject.Domain.Common
{
    public abstract class DbObjectBase<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
