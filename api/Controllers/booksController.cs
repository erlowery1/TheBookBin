using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Models.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        // GET: api/books
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Book> Get()
        {
            IGetAllBooks readObject = new ReadBookData();
            return readObject.GetAllBooks();
        }
        //need to make a route so this pulls from transactions database
        //GET: api/books
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Book> Get()
        {
            IGetAllBooks readObject = new ReadBookData();
            return readObject.GetAllBooks();
        }

        // GET: api/books/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Book Get(int id)
        {
            IGetBook readObject = new ReadBookData();
            return readObject.GetBook(id);
        }

        // POST: api/books
        [EnableCors("AnotherPolicy")] //security 
        [HttpPost]
        public void Post([FromBody] Book value)
        {  
             IInsertBook insertObject= new SaveBook();
            insertObject.InsertBook(value);
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")] //security
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteBook deleteObject = new DeleteBook();
            deleteObject.RemoveBook(id);
        }
    }
}
