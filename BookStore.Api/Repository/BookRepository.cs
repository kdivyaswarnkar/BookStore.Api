using BookStore.Api.Data;
using BookStore.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Repository
{
    public class BookRepository: IBookRepository
    {
        private readonly BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
    
        // Get All Books 
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await _context.Books.Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
            }).ToListAsync();
            return records;
        }

        // Get one item by id 
        public async Task<BookModel> GetBookByIdAsync(int BookId)
        {
            // we can use _context.Books.FindAsync(BookId) from getting this by id
            var records = await _context.Books.Where(x=>x.Id==BookId).Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
            }).FirstOrDefaultAsync();

            // we can use firstAsync instead of FirstOrDefaultAsync (different between this is if you are lookin for the book if that book is not exist in
            // repo/db then firstasync method give the error where FirstOrDefaultAsync give the null value)
            return records;
        }
    }
}
