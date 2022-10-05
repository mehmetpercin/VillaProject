namespace VillaProject.Domain.Common
{
    public abstract class DbObject : DbObjectBase<int>
    {
        public DateTimeOffset CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public string? Modifier { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
