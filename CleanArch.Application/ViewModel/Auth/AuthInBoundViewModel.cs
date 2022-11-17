using Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModel.Auth
{
    public class AuthInBoundViewModel
    {
        public string token { get; set; }
        public UserDto user { get; set; }
        public string message { get; set; }
        public List<string> campaings { get; set; }
        public string code { get; set; }
        public bool status { get; set; }
    }
}
