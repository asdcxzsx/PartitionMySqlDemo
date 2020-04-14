using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FreeSql;
using FreeSql.DataAnnotations;

namespace ConsoleApp1
{
    public class Context : DbContext
    {
        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseFreeSql(Program.fsql);
        }
    }

    public class Log
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public Guid Id { get; set; }

        [Column(IsPrimary = true)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        [MaxLength(20)]
        public string Msg { get; set; }
    }
}
