using System;
using System.Collections.Generic;
using Store.Entites;
using System.Linq;
using Store.Models.DTO;
using AutoMapper;


namespace Store.BLL
{
    public class Logic : Store.Abstract.ILogic
    {
        private readonly Store.Abstract.IDALContext _dbContext;
        protected Store.Abstract.IDALContext dbContext { get { return _dbContext; } }

        public Logic(Store.Abstract.IDALContext ctx)
        {
            _dbContext = ctx;
        }

        public void CreateData()
        {
            if (!dbContext.Books.Any())
            {
                dbContext.Books.AddRange(
                    new Book
                    {
                        Author = "Эндрю Троелсен",
                        Title = "Язык программирования C# 2010 и плавтформа .NET 4. 5-е издание",
                        PlacedDate = DateTime.Now,
                        Count = 5,
                        Price = 100,
                        Type = "Paper book"
                    },
                    new Book
                    {
                        Author = "Rob Miles",
                        Title = "Programming C#/ Exam Ref 70-483. Second Edition",
                        PlacedDate = DateTime.Now,
                        Count = 3,
                        Price = 200,
                        Type = "eBook"
                    },
                    new Book
                    {
                        Author = "Джозеф Албахари, Бен Албахари",
                        Title = "LINQ. Карманный справочник",
                        PlacedDate = DateTime.Now,
                        Count = 2,
                        Price = 230,
                        Type = "eBook",
                        Sale = true
                    },
                    new Book
                    {
                        Author = "Михаил Абрамян",
                        Title = "Технология LINQ на примерах. Практикум с использованием электронного задачника Programming Taskbook for LINQ",
                        PlacedDate = DateTime.Now,
                        Count = 10,
                        Price = 145,
                        Type = "eBook"
                    }
                    );

                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Get all books in warehouse of store
        /// </summary>
        /// <returns></returns>
        public List<BookDTO> GetAllBooksInStore(BookDTO search)
        {
            var books = dbContext.Books.AsQueryable();

            if(search != null)
            {
                if (!string.IsNullOrEmpty(search.Author))
                    books = books.Where(x=>x.Author.Contains(search.Author));
                if (!string.IsNullOrEmpty(search.Title))
                    books = books.Where(x => x.Title.Contains(search.Title));
                if (search.PlacedDate > DateTime.MinValue)
                    books = books.Where(x => x.PlacedDate > search.PlacedDate);
                if(search.Sale)
                    books = books.Where(x => x.Sale == search.Sale);
                if(!string.IsNullOrEmpty(search.Type))
                    books = books.Where(x => x.Type == search.Type);
            }

            return books.Select(x=> new BookDTO
            {
                Id = x.Id,
                Author = x.Author,
                Count = x.Count,
                PlacedDate = x.PlacedDate,
                Title = x.Title,
                Price = x.Price,
                Sale = x.Sale,
                Type = x.Type
            }).ToList();
        }

        public BookDTO GetBook(int id)
        {
            var model = new BookDTO();
            var book = dbContext.Books.Find(id);
            if (book != null)
            {
                var config = new MapperConfiguration(cfg =>cfg.CreateMap<Book,BookDTO>()
                    .ForMember(dest=>dest.Orders, opt=>opt.Ignore()));
                var mapper = config.CreateMapper();

                model = mapper.Map<BookDTO>(book);
            }
            return model;
        }

        public void AddOrUpdateBook(BookDTO bookDTO)
        {
            

            if (bookDTO?.Id > 0)
            {
                var book = dbContext.Books.Find(bookDTO.Id);
                book.PlacedDate = bookDTO.PlacedDate;
                book.Price = bookDTO.Price;
                book.Sale = bookDTO.Sale;
                book.Title = bookDTO.Title;
                book.Type = bookDTO.Type;
                book.Author = bookDTO.Author;
                book.Count = bookDTO.Count;
                book.Description = bookDTO.Description;
                //dbContext.Books.Attach(book);
                dbContext.SaveChanges();
            }
            else
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, Book>()
                  .ForMember(dest => dest.Orders, opt => opt.Ignore()));
                var mapper = config.CreateMapper();

                var book = mapper.Map<Book>(bookDTO);

                dbContext.Books.Add(book);
                dbContext.SaveChanges();
            }
        }

        public void DeleteBook(int id)
        {
            var book = dbContext.Books.Find(id);
            if(book!=null)
            {
                dbContext.Books.Remove(book);
                dbContext.SaveChanges();
            }
        }

        public void AddCount(int id, int count)
        {
            var book = dbContext.Books.Find(id);
            if(book != null)
            {
                if (book.Count + count >= 0)
                {
                    book.Count = book.Count + count;
                    dbContext.SaveChanges();
                }
            }
        }

        public List<OrderDTO> GetAllOrders()
        {
            return dbContext.Orders.Select(x=> new OrderDTO {
                Id= x.Id,
                ClientName = x.ClientName,
                Count = x.Count,
                BookId = x.Book.Id,
                BookTitle = x.Book.Title
            }).ToList();
        }

        
    }
}
