using System;
using System.Collections.Generic;
using Store.Models.DTO;

namespace Store.Abstract
{
    public interface ILogic
    {
        /// <summary>
        /// Get all books in warehouse of store
        /// </summary>
        /// <returns></returns>
        List<BookDTO> GetAllBooksInStore(BookDTO search);

        BookDTO GetBook(int id);

        void AddOrUpdateBook(BookDTO bookDTO);

        void DeleteBook(int id);

        void AddCount(int id, int count);

        List<OrderDTO> GetAllOrders();

        void CreateData();
    }
}
