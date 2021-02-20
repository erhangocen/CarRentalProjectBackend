using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Dtos
{
    public class CustomerDto : IDto
    {
        public string FullName { get; set; }
        public string Company { get; set; }
    }
}
