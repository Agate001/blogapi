using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogapi.Models
{
    public class BlogItemModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Publishername { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? Date { get; set; }
        public string? Category { get; set; }
        public string? Tags { get; set; }
        public bool isPublished { get; set; }
        public bool isDeleted { get; set; }
    }
}