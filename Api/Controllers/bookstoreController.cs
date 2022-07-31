using APIBookstore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookstoreController : ControllerBase
    {
        private readonly TodoContext _context;

        public bookstoreController(TodoContext context)
        {
            _context = context;

            if (_context.TodoProducts.Count() == 0)
            {
                _context.TodoProducts.Add(new Product { Id = "1", Name = "Duna", Author = "Frank Herbert", Price = 24, Quantity = 14, Category = "Ficção Científica", Img = "img1" });
                _context.TodoProducts.Add(new Product { Id = "2", Name = "O Mundo de Sofia", Author = "Jostein Gaarder", Price = 50, Quantity = 1, Category = "Romance", Img = "img2" });
                _context.TodoProducts.Add(new Product { Id = "3", Name = "Lupin", Author = "Maurice Leblanc", Price = 20, Quantity = 2, Category = "Supense", Img = "img3" });
                _context.TodoProducts.Add(new Product { Id = "4", Name = "Jogos Vorazes", Author = "Suzanne Collins", Price = 9, Quantity = 10, Category = "Ficção Científica", Img = "img4" });
                _context.TodoProducts.Add(new Product { Id = "5", Name = "Admirável Mundo Novo", Author = "Huxley, Aldous Leonard", Price = 15, Quantity = 5, Category = "Ficção Científica", Img = "img5" });
                _context.TodoProducts.Add(new Product { Id = "6", Name = "As Crônicas de Nárnia", Author = "C.S. Lewis", Price = 25, Quantity = 6, Category = "Fantasia", Img = "img6" });
                _context.TodoProducts.Add(new Product { Id = "7", Name = "O Código da Vinci", Author = "Dan Brown", Price = 30, Quantity = 5, Category = "Suspense", Img = "img7" });
                _context.TodoProducts.Add(new Product { Id = "8", Name = "Fahrenheit 451", Author = "Ray Bradbury", Price = 12, Quantity = 8, Category = "Ficção Científica", Img = "img8" });
                _context.TodoProducts.Add(new Product { Id = "9", Name = "Sherlock Holmes", Author = "Arthur Conan Doyle", Price = 15, Quantity = 5, Category = "Mistério", Img = "img9" });
                _context.TodoProducts.Add(new Product { Id = "10", Name = "A Guerra dos Tronos", Author = "George R.R. Martin", Price = 40, Quantity = 5, Category = "Fantasia", Img = "img10" });
            }
            _context.SaveChanges();

        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.TodoProducts.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdut), new { id = product.Id }, product);
        }

        // GET: api/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetTodoItems()
        {
            return await _context.TodoProducts.ToListAsync(); 



        }

        // GET: api/bookstore/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProdut(int id)
        {
            var todoItem = await _context.TodoProducts.FindAsync(id.ToString());

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

    }
}
