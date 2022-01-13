using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAspNetCoreBRGAAP.Models;

namespace WebApiAspNetCoreBRGAAP.Repositories
{
    public class CategoryRepositories : Interface
    {

        public readonly CategoryContext _context;
        public CategoryRepositories(CategoryContext context)
        {
            _context = context;

        }

        public async Task<Category> Create(Category book)

        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task Delete(int Id)
        {
            var bookToDelete = await _context.Books.FindAsync(Id);
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Category> Get(int Id)
        {
            return await _context.Books.FindAsync(Id);
        }
        public void Update(Category book)
        {
            _context.Entry(book).State = EntityState.Modified;

        }

        Task Interface.Update(Category book)
        {
            throw new NotImplementedException();
        }
    }
}
