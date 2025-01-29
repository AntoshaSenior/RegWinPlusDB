using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace JustWpf
{
    class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }  

        public AppContext() : base(GetOptions())  
        {  
        }  


        private static DbContextOptions<AppContext> GetOptions()  
        {  
            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();  
            var connectionString = ConfigurationManager.ConnectionStrings["Clients"].ConnectionString;  
            optionsBuilder.UseSqlServer(connectionString);  
            return optionsBuilder.Options;  
        } 
        
    }
}
