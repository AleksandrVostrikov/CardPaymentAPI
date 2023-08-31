using CardPaymentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CardPaymentAPI.Data
{
    public class CardPaymentsDbContext : DbContext
    {
        public CardPaymentsDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<UserCardDetails> UsersCardsDetails { get; set; }
    }
}
