using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.API.Dtos
{
    public class BookParam
    {
        public Guid BookId { get; set; }
        public string UserId { get; set; }
    }
}
