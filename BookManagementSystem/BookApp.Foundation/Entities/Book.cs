using BookApp.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Foundation.Entities
{
    public class Book : IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        public string ShortDescription { get; set; }
        public bool IsArchived { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
