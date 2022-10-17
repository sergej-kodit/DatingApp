using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string PhotoUrl { get; set; } = default!;
        public int Age { get; set; }
        public string KnownAs { get; set; } = default!;

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public string Gender { get; set; } = default!;
        public string Introduction { get; set; } = default!;
        public string LookingFor { get; set; } = default!;
        public string Interests { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public ICollection<PhotoDto> Photos { get; set; }
    }
}