namespace VSA.Api.Common
{
    public class EntityBase<Tkey>
    {
        public Tkey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
