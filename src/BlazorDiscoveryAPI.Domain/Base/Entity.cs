namespace BlazorDiscoveryAPI.Domain.Base
{
    public class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; } = DateTime.Now;
        public DateTime? LastModificationDate { get; set; }
    }
}
