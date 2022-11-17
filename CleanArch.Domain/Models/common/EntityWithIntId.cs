using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Common
{
    /// <summary>
    /// Entity for Init
    /// </summary>
    public abstract class EntityWithIntId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        public EntityWithIntId()
        {
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime? CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public DateTime? UpdatedAt { get; set; }
        /// <summary>
        /// Gets or sets the deleted at.
        /// </summary>
        /// <value>
        /// The deleted at.
        /// </value>
        public DateTime? DeletedAt { get; set; }
        /// <summary>
        /// Gets or sets the deleted at.
        /// </summary>
        /// <value>
        /// The deleted at.
        /// </value>
        public Guid? CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the deleted at.
        /// </summary>
        /// <value>
        /// The deleted at.
        /// </value>
        public Guid? UpdatedBy { get; set; }
        public string LastCreatedByName { get; set; }
        /// <summary>
        /// Gets or sets the deleted at.
        /// </summary>
        /// <value>
        /// The deleted at.
        /// </value>
        public string LastUpdatedByName { get; set; }

    }
}
