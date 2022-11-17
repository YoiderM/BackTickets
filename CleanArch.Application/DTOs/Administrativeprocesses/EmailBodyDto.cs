using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Administrativeprocesses
{
    public class EmailBodyDto
    {
        public string NameAplicant { get; set; }
        public string NameAuthorizing { get; set; }
        public string NameAproving { get; set; }
        public string NameUser { get; set; }
        public DateTime? StatusDate { get; set; }
        public string Email { get; set; }
        public string EmailCopy { get; set; }
        public string Fault { get; set; }
        public string DescriptionOfTheFault { get; set; }
        public string DescriptionOfTheHealing { get; set; }
        public string DescriptionResponseLegal { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string BodyTwo { get; set; }
        public string url { get; set; }
        public List<Domain.Models.User.User> UserRol { get; set; }

    }
}
