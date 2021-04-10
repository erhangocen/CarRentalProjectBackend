using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace Entities.Dtos
{
    public class RentalDto : IDto
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string CarName { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
