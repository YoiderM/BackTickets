using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Configurations
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool Status { get; set; } = true;

        public string Description { get; set; }

        public bool CanChanged { get; set; } = true;
    }
}
