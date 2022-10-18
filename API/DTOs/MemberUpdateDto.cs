using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MemberUpdateDto
    {
        public string Introduction { get; set; } = default!;
        public string LookingFor { get; set; } = default!;
        public string Interests { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;

    }
}