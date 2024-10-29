namespace BlazorDiscoveryAPI.Domain.Base
{
    public class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; init; }
        public DateTime CreationDate { get; init; } = DateTime.Now;
        public DateTime? LastModificationDate { get; set; }
    }
}
