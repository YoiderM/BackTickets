using Core.Models.Common;
using Core.Models.configuration;
using System;

namespace Domain.Models.ConfigurationDates
{
    /// <summary>
    /// List of all Holydays of the year
    /// </summary>
    public class Holiday : EntityWithIntId
    {
        public DateTime? Day { get; set; }
        public Guid? TypeId { get; set; }
        public Configuration Type { get; set; }
    }
} 
