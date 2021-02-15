using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RentalDto
    {
        public string Car { get; set; }
        public string CustomerName { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
