using System.Transactions;
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
using Transaction = api.Models.Transaction;

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
            IGetAll readObject = new ReadData();
            return readObject.GetAllBooks();
        }
        // //need to make a route so this pulls from transactions database
        // //GET: api/books/sales

        [EnableCors("AnotherPolicy")]
        [Route("sales")]
        [HttpGet]
        public List<Transaction> Sales()
        {
            Console.WriteLine(1);
            IGetAll readObject = new ReadData();
            return readObject.GetAllTransactions();
        }

        // POST: api/books/sales
        [EnableCors("AnotherPolicy")] //security 
        [Route("sales")] 
        [HttpPost]
        public void PostSale([FromBody] Transaction value)
        {  
            Console.WriteLine("made it to post sale controller");
            IInsert insertObject= new SaveInfo();
            insertObject.InsertTransaction(value);
            IDelete deleteObject = new DeleteInfo();
            deleteObject.RemoveBook(value.Id);
        }

        // GET: api/books/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Book Get(int id)
        {
            IGet readObject = new ReadData();
            return readObject.GetBook(id);
        }

        // POST: api/books
        [EnableCors("AnotherPolicy")] //security 
        [HttpPost]
        public void Post([FromBody] Book value)
        {  
            IInsert insertObject= new SaveInfo();
            insertObject.InsertBook(value);
        }

        // PUT: api/books/5
        [EnableCors("AnotherPolicy")] //security 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            IUpdate editObject = new Update(); //Not working here?
            editObject.UpdateBook(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")] //security
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDelete deleteObject = new DeleteInfo();
            deleteObject.RemoveBook(id);
        }
    }
}
