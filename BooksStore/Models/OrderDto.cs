using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BooksStore.Models
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        [Required]
        [MinLength(4)]
        public string OrderNumber { get; set; }
        public ICollection<OrderItemsDto> Items { get; set; }
    }
}
