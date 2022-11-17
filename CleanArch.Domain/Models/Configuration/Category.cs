using Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Models.configuration
{
	public class Category : Entity
	{
		public string Name { get; set; }

        public bool Status { get; set; } = true;

        public string Description { get; set; }

        public bool CanChanged { get; set; } = true; 

    }
}