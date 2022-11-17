using Core.Models.configuration;
using Core.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Core.Models.configuration
{
	public class Configuration : Entity
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public int OrderId { get; set; } = 0;


		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
	
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>

		public bool Status { get; set; } = true;

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public Guid? GuidId { get; set; }
		public Guid? GuidId2 { get; set; }
		public Guid? GuidId3 { get; set; }


		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		
		public bool? BoolId1 { get; set; }
		public bool? BoolId2 { get; set; }
		public bool? BoolId3 { get; set; }


		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public int? IntId { get; set; }
		public int? IntId1 { get; set; }
		public int? IntId2 { get; set; }
		

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public Category Category { get; set; }
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public Guid CategoryId { get; set; }


	}
}