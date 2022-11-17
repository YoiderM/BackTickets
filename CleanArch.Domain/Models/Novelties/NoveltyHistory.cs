using Core.Models.Common;
using Domain.Models.Mekano;
using Domain.Models.User;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Novelties
{
    public class NoveltyHistory : Entity
    {
        public DateTime date { get; set; }
        public string InitialState { get; set; }
        public string EndState { get; set; }
        public string Observation { get; set; }

        public Guid MadeByUserId { get; set; }
        [ForeignKey("MadeByUserId")]
        public User.User User { get; set; }

        public Guid NoveltyEntryId { get; set; }
        [ForeignKey("NoveltyEntryId")]
        public NoveltyEntry NoveltyEntry { get; set; }
    }
}
