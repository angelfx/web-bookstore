using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Entites
{
    public class Order
    {
        /// <summary>
        /// Id of element
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Book to order
        /// </summary>
        public virtual Book Book { get; set; }

        /// <summary>
        /// Count of books to order
        /// </summary>
        public int Count { get; set; }
    }
}
