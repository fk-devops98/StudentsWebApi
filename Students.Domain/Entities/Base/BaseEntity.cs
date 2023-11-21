namespace Students.Domain.Entities.Base
{
    public class BaseEntity<T> : DomainEntity, IBaseEntity<T>
    {
        public virtual T Id { get; set; } = default!;
    }
}