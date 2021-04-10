using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserDto : IDto
    {
        public int UserId { get; set; }
        public int ClaimId { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string ClaimName { get; set; }
        public int FindeksPoint { get; set; }
    }
}
