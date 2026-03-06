using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogapi.Models.DTO
{
    public class UserIdDTO
    {
        public int UserId { get; set; }
        public string? PublisherName { get; set; }
        public string? MyProperty { get; set; }
    }
}