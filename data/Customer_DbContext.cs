using codefirst.Models;
using Microsoft.EntityFrameworkCore;

namespace codefirst.data
{
    public class Customer_DbContext:DbContext
    {
        public Customer_DbContext(DbContextOptions<Customer_DbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
