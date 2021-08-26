using BookApp.Data;

namespace BookApp.Foundation.Entities
{
    public class Permission : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPermitted { get; set; }
    }
}
