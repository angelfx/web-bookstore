using System;
using System.Collections.Generic;

namespace Store.Entites
{
    /// <summary>
    /// Book of store
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Unique Id of element
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of book
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Author of book. Just full name.
        /// At the production app we must create new entity "Author" with attributes and place reference into this class
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Date when this book was placed in warehouse of store
        /// </summary>
        public DateTime PlacedDate { get; set; }

        /// <summary>
        /// Count of books in the warehouse of store
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Price of the book
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Type of book (eBook, Paper book)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Apply fixed discount for book
        /// </summary>
        public bool Sale { get; set; }

        /// <summary>
        /// Description of the book
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Orders where the book is placed
        /// </summary>
        public virtual List<Order> Orders { get; set; }
    }
}
