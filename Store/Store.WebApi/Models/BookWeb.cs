using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Store.WebApi.Models
{
    public class BookWeb
    {
        /// <summary>
        /// Unique Id of element
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of book
        /// </summary>
        [Required(ErrorMessage = "Enter a title of book")]
        public string Title { get; set; }

        /// <summary>
        /// Author of book. Just full name.
        /// At the production app we must create new entity "Author" with attributes and place reference into this class
        /// </summary>
        [Required(ErrorMessage = "Enter a author of book")]
        public string Author { get; set; }

        /// <summary>
        /// Date when this book was placed in warehouse of store
        /// </summary>
        [Required(ErrorMessage = "Enter a date when book placed in warehouse")]
        public DateTime PlacedDate { get; set; }

        /// <summary>
        /// Count of books in the warehouse of store
        /// </summary>
        [Required(ErrorMessage = "Enter a count of book")]
        public int Count { get; set; }

        /// <summary>
        /// Price of the book
        /// </summary>
        [Required(ErrorMessage = "Enter a price of book")]
        public int Price { get; set; }

        /// <summary>
        /// Type of book (eBook, Paper book)
        /// </summary>
        [Required(ErrorMessage = "Enter a type of book")]
        public string Type { get; set; }

        /// <summary>
        /// Description of the book
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Apply fixed discount for book
        /// </summary>
        public bool Sale { get; set; }
    }
}
