namespace HomeWork2.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LetterContext : DbContext
    {
        public LetterContext()
            : base("name=LetterContext")
        {
        }
        public DbSet<Letter> Letters { get; set; }
    }
}