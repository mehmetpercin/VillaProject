namespace VillaProject.Domain.Common
{
    public abstract class DbObjectBase<T>
    {
        public T Id { get; set; }
    }
}
