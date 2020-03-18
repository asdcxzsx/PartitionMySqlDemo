using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    /// <summary>
    /// Add-Migration InitialCreate
    /// Update-Database
    /// </summary>
    //public class BloggingContext : DbContext
    //{
    //    public DbSet<Blog> Blogs { get; set; }

    //    public DbSet<Post> Posts { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");

    //        //主要使用以下两种
    //        //optionsBuilder.UseMySql(@"Server=127.0.0.1;Port=3306;Database=Cluster_DB_Test;User=root;Password=123456;");
    //        //optionsBuilder.UseMySql(@"Server=127.0.0.1;Port=3306;Database=Cluster_DB_Test_0;User=root;Password=123456;");
    //        //optionsBuilder.UseMySql(@"Server=127.0.0.1;Port=3306;Database=Cluster_DB_Test_1;User=root;Password=123456;");
    //        //optionsBuilder.UseMySql(@"Server=127.0.0.1;Port=8066;Database=TESTDB;User=root;Password=123456;"); //使用连接代理Pomelo.EntityFrameworkCore.MySql



    //        //optionsBuilder
    //        //    .UseMyCat("server=192.168.0.10;port=8066;uid=root;pwd=123456;database=TESTDB")
    //        //    .UseDataNode("192.168.0.10", "Cluster_DB_Test", "root", "123456")
    //        //    .UseDataNode("192.168.0.10", "Cluster_DB_Test_0", "root", "123456")
    //        //    .UseDataNode("192.168.0.10", "Cluster_DB_Test_1", "root", "123456");
    //        // optionsBuilder.UseMySQL(@"Server=127.0.0.1;Port=8066;Database=TESTDB;User=root;Password=123456;");

    //        //optionsBuilder.UseLazyLoadingProxies();
    //    }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);
    //        modelBuilder.Entity<Blog>(b =>
    //        {
    //            b.HasKey(x => new { x.Id, x.CreateTime });
    //            b.HasAlternateKey(x => x.Id);
    //            b.HasIndex(x => x.CreateTime);
    //        });
    //        modelBuilder.Entity<Post>(b =>
    //            {
    //                b.HasOne(x => x.Blog).WithMany(x => x.Posts).HasForeignKey(x => x.BlogId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Cascade);
    //            });
    //    }
    //}
 
}
