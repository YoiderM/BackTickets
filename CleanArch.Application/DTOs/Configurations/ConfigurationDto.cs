using System;

namespace Application.DTOs.Configurations
{
    public class ConfigurationDto
    {
		
		public Guid Id { get; set; }
		public string Name { get; set; }		
		public int OrderId { get; set; } = 0;
		public string Description { get; set; }		
		public bool Status { get; set; }	
		public Guid CategoryId { get; set; }	
		public Guid? GuidId { get; set; }	
		public int? IntId { get; set; }
	}
}
