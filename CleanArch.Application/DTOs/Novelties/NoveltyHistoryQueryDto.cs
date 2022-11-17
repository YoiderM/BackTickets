using Application.DTOs.Mekano;
using Application.DTOs.Resources;
using Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Novelties
{
    public class NoveltyHistoryQueryDto
    {
        public Guid Id { get; set; }
        public DateTime date { get; set; }
        public string InitialState { get; set; }

        public string EndState { get; set; }

        public string Observation { get; set; }

        public Guid MadeByUserId { get; set; }
        public UserDto User { get; set; }

        public Guid NoveltyEntryId { get; set; }

    }
}
