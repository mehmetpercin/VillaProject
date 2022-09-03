using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VillaProject.Domain.Common
{
    public abstract class DbObject : DbObjectBase<int>
    {
        public DateTimeOffset CreatedDate { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Creator { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string? Modifier { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
