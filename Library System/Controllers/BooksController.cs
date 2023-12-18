using Library_System.Data;
using Library_System.Models.DomainModels;
using Library_System.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LmDbContext dbContext;

        public BooksController(LmDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //creating an action method
        [HttpGet] // Get: url/contoller
        public IActionResult GetAllBooks()
        {
            // get Data from Database - Domain Models
            var books = dbContext.Books.ToList();

            // Map Domain Models to DTOs
            var booksDto = new List<BooksDto>();
            foreach (var book in books)
            {
                booksDto.Add(new BooksDto()
                {
                    Id = book.Id,
                    ISBN = book.ISBN,
                    Title = book.Title,
                    Description = book.Description,
                    Publication = book.Publication,
                    PublicationDate = book.PublicationDate,
                    Author = book.Author,
                    Category = book.Category,
                    Edition = book.Edition,
                    RFID = book.RFID,
                    Status = book.Status,
                    Count = book.Count,
                });
            }
            //Return DTOs

            return Ok(booksDto);
        }

        //Get book by ID
        [HttpGet] //http url /api/books/{id}
        [Route("{id}")] //adding route 
        public IActionResult GetBookById([FromRoute] string id)
        {
            var book = dbContext.Books.Find(id); //only be used for id
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                // Map Domain Models to DTOs
                var booksDto = new List<BooksDto>();
                booksDto.Add(new BooksDto()
                    {
                        Id = book.Id,
                        ISBN = book.ISBN,
                        Title = book.Title,
                        Description = book.Description,
                        Publication = book.Publication,
                        PublicationDate = book.PublicationDate,
                        Author = book.Author,
                        Category = book.Category,
                        Edition = book.Edition,
                        RFID = book.RFID,
                        Status = book.Status,
                        Count = book.Count,
                    });
                //Return DTOs
                return Ok(booksDto);
            }
        }

        //Get Book by ISBN 
        [HttpGet] //http url /api/books/{isbn}
        [Route("{isbn}")] //adding route 
        public IActionResult GetBookByISBN([FromRoute] string isbn) 
        {
            //var book = dbContext.Books.Find(id); only be used for id
            var books = dbContext.Books.FirstOrDefault(x => x.ISBN == isbn);
            if (books == null)
            {
                return NotFound();
            }
            else
            {
                
                return Ok(books);
            }
        }

        //Post to Create New Book
        [HttpPost]
        public IActionResult AddBook([FromBody] AddBookRequestDto addBookRequestDto)
        {
            //Map or convert the DTO to Domain Model
            var bookDomainModel = new Books
            {
                ISBN = addBookRequestDto.ISBN,
                Title = addBookRequestDto.Title,
                Description = addBookRequestDto.Description,
                Publication = addBookRequestDto.Publication,
                PublicationDate = addBookRequestDto.PublicationDate,
                Author = addBookRequestDto.Author,
                Category = addBookRequestDto.Category,
                Edition = addBookRequestDto.Edition,
                RFID = addBookRequestDto.RFID,
                Status = true,
                Count = 1,
            };

            //Use Domain Model to add the book to Database
            dbContext.Books.Add(bookDomainModel);
            dbContext.SaveChanges();

            var bookDto = new BooksDto
            {
                Id = bookDomainModel.Id,
                ISBN = bookDomainModel.ISBN,
                Title = bookDomainModel.Title,
                Description = bookDomainModel.Description,
                Category = bookDomainModel.Category,
                Publication = bookDomainModel.Publication,
                PublicationDate = bookDomainModel.PublicationDate,
                Author = bookDomainModel.Author,
                Edition = bookDomainModel.Edition,
                RFID = bookDomainModel.RFID,
                Status = bookDomainModel.Status
            };

            //return CreatedAtAction(nameof(GetById), new { id = bookDomainModel.id});
            return CreatedAtAction(nameof(GetBookById), new { id = bookDto.Id}, bookDto);
        }
    }
}
