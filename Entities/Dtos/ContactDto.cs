using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class ContactDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string ImagePath { get; set; }
        public string ContInfo { get; set; }
        public string Message { get; set; }
    }
}
