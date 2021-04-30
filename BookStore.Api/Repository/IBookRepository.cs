using BookStore.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Api.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int BookId);
        Task<int> AddNewBookAsync(BookModel model);
        Task UpdateBookAsync(int bookId, BookModel bookModel);
        Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel);
    }
}
