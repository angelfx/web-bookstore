using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Store.WebApi.Models
{
    public class OrderWeb
    {
        /// <summary>
        /// Id of element
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the client
        /// </summary>
        [Required(ErrorMessage = "Enter a client full name")]
        public string ClientName { get; set; }

        /// <summary>
        /// Id of book in DB
        /// </summary>
        [Required(ErrorMessage = "Enter a id of book")]
        public int BookId { get; set; }

        /// <summary>
        /// Title of book
        /// </summary>
        [Required(ErrorMessage = "Enter a title of book")]
        public string BookTitle { get; set; }

        /// <summary>
        /// Count of books to order
        /// </summary>
        [Required(ErrorMessage = "Enter a count to order")]
        public int Count { get; set; }
    }
}
