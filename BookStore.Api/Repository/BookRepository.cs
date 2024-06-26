﻿using AutoMapper;
using BookStore.Api.Data;
using BookStore.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IMapper _mapper;
        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    
        // Get All Books 
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            //var records = await _context.Books.Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description,
            //}).ToListAsync();
            //return records;

            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }

        // Get one item by id 
        public async Task<BookModel> GetBookByIdAsync(int BookId)
        {
            //// we can use _context.Books.FindAsync(BookId) from getting this by id
        /*    var records = await _context.Books.Where(x => x.Id == BookId).Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
            }).FirstOrDefaultAsync();
            return records;      */

            //// we can use firstAsync instead of FirstOrDefaultAsync (different between this is if you are looking for the book if that book is not exist in
            //// repo/db then firstasync method give the error where FirstOrDefaultAsync give the null value)


            var book = await _context.Books.FindAsync(BookId);
            return _mapper.Map<BookModel>(book);
        }


        // Add New Book In To The Database 
        public async Task<int> AddNewBookAsync(BookModel model)
        {

            var book = new Books()
            {
                Title = model.Title,
                Description = model.Description
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }


        // Put Or update
        public async Task UpdateBookAsync(int BookId,BookModel bookModel)
        {
            //var book = await _context.Books.FindAsync(BookId);
            //if(book !=null)
            //{
            //    book.Title = bookModel.Title;
            //    book.Description = bookModel.Description;
            //    await _context.SaveChangesAsync();
            //}
            var book = new Books()
            {
                Id= bookModel.Id,
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }


        // Patch :- different between httpput and httppatch is that httpput is update all the properties  in the single records 
        //  where us patch update the specific property and all multiple properties also  in the records.

        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }



        public async Task DeleteBookAsync(int bookId)
        {
            //var book=_context.Books.Where(x=>x.Title=="").FirstOrDefault();
            var book = new Books() { Id = bookId };

             _context.Books.Remove(book);

            await _context.SaveChangesAsync();
        }
    }
}
