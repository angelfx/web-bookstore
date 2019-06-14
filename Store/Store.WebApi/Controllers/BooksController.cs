using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Store.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private Store.Abstract.ILogic _Logic;

        public BooksController(Store.Abstract.ILogic Logic)
        {
            _Logic = Logic;
        }

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Models.BookWeb> Get(string title = "", string author = "", bool sale = false, string type = "")
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Store.Models.DTO.BookDTO, Models.BookWeb>();
            });
            var mapper = config.CreateMapper();

            Store.Models.DTO.BookDTO search = new Store.Models.DTO.BookDTO
            {
                Title = title,
                Author = author,
                Sale = sale,
                Type = type
            };

            var booksDTO = _Logic.GetAllBooksInStore(search);

            return mapper.Map<IEnumerable<Models.BookWeb>>(booksDTO);
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public Models.BookWeb Get(int id)
        {
            var bookDTO = _Logic.GetBook(id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Store.Models.DTO.BookDTO, Models.BookWeb>());
            var mapper = config.CreateMapper();

            return mapper.Map<Models.BookWeb>(bookDTO);
        }

        // POST: api/Books
        [HttpPost]
        public string Post([FromBody] Models.BookWeb book)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.BookWeb, Store.Models.DTO.BookDTO>());
                var mapper = config.CreateMapper();

                var bookDTO = mapper.Map<Store.Models.DTO.BookDTO>(book);

                _Logic.AddOrUpdateBook(bookDTO);
            }
            else
            {
                return "400";
            }
            return "200";
        }

        //[Route("addcount")]
        [HttpPost("{id}")]
        public string AddCount(int id, [FromForm] int count)
        {
            if (id <= 0)
                return "400";

            try
            {
                _Logic.AddCount(id, count);
            }
            catch
            {
                return "400";
            }

            return "200";
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _Logic.DeleteBook(id);
        }
    }
}
