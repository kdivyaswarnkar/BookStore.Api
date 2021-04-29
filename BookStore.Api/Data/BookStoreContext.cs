using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Data
{
    //Inherit class with DbContext which is available in Microsoft.EntityFrameworkCore
    public class BookStoreContext:DbContext
    {
        // here we provide the options and also provide options for DbContext
        public BookStoreContext(DbContextOptions<BookStoreContext> options):base(options)
        {

        }
        // To work with database we need to tell our context class that we have to using new book class in this application
        // provide the  name of the property
        // this is created the new table in this books appliationsame name as provide here
       public DbSet<Books> Books { get; set; }


        //for use or provide conection string in here  we need to override

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //   // optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=BooksStoreApi;Integrated Security =True");
        //    optionsBuilder.UseSqlServer();
        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}
