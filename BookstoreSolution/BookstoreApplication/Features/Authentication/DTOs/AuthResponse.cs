using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApplication.Features.Authentication.DTOs
{
    public class AuthResponse
    {
        public bool IsSuccessful { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }

        public string Message { get; set; }
        public List<string> Errors { get; set; }    
    }
}
