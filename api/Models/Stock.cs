using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.EntityFrameworkCore;



namespace api.Models {


    public class Stock {

        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        [Column(TypeName="decimal(18,2)")]
        public decimal Purchase { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCup { get; set; }
  //      public Comment Comments { get; set; } = new Comment();
        public List<Comment> Comments { get; set; } = new List<Comment>();

 //       public DbSet<Stock> Stocks { get; set; }

  //      public DbSet<Comment> Comments { get; set; }
    }

}