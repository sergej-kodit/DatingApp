using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class LikeDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = default!;

        public int Age { get; set; }
        public string KnownAs { get; set; } = default!;
        public string PhotoUrl { get; set; } = default!;
        public string City { get; set; } = default!;

    }
}