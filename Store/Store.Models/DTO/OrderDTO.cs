using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Models.DTO
{
    public class OrderDTO
    {
        /// <summary>
        /// Id of element
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the client
        /// </summary>
        public string ClientName { get; set; }
        
        public int BookId { get; set; }

        public string BookTitle { get; set; }

        /// <summary>
        /// Book to order
        /// </summary>
        public virtual BookDTO Book { get; set; }

        /// <summary>
        /// Count of books to order
        /// </summary>
        public int Count { get; set; }
    }
}
