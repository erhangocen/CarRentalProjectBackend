using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ContInfo { get; set; }
        public string Message { get; set; }

    }
}
