using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Repositories.EFCore.DataContexts
{
    internal class BookManagerContextFactory :
        IDesignTimeDbContextFactory<BookManagerContext>
    {
        public BookManagerContext CreateDbContext(string[] args)
        {
            //Add-Migration InitialCreate -p BookManager.Repositories.EFCore -s BookManager.Repositories.EFCore -c BookManagerContext
            //Update-Database -p BookManager.Repositories.EFCore -s BookManager.Repositories.EFCore -context BookManagerContext
            var OptionsBuilder = new DbContextOptionsBuilder<BookManagerContext>();

            OptionsBuilder.UseSqlite(
                "Data Source=..\\BookManager.db");

            return new BookManagerContext(OptionsBuilder.Options);
        }
    }
}
