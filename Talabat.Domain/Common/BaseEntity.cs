namespace Talabat.Domain.Common
{
    public abstract class BaseEntity <Tkey> where Tkey: IEquatable<Tkey>
    {
        public  required Tkey Id { get; set; }
    }
}
