using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp.Models;

namespace ConsoleApp
{
    public class FreeSqlTest
    {
        static IFreeSql fsql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.MySql, @"Server=127.0.0.1;Port=8066;Database=TESTDB;User=root;Password=123456;")
            .UseAutoSyncStructure(true) //自动同步实体结构到数据库
            .Build(); //请务必定义成 Singleton 单例模式
        public static void TestFreeSql()
        {

            List<Guid> subCompanyId = new List<Guid>()
            {
                Guid.Parse("5e724e04-335b-c438-002a-810112854f6e"), Guid.Parse("5e724e04-335b-c438-002a-810268666947")
                ,Guid.Parse("5e724e04-335b-c438-002a-81031929e6dc")
            };
            //var id = Guid.NewGuid();
            //for (uint i = 0; i < 50; i++)
            //{
            //    var rst = fsql.Insert(new Blog() { CreateTime = DateTime.Now, Rating = i, Url = $"{Guid.NewGuid()}" }).ExecuteAffrows();
            //}

            //var first = fsql.Select<Blog>().First(); //此时有也快照，等于多一次查询。。。。。
            //var repo = fsql.GetRepository<Blog>();
            //repo.Attach(first);//快照
            //first.Url = $"这就是free sql!!{DateTime.Now}";
            //repo.Update(first);//对比快照更新


            //var b = new Blog() { Id = id };
            //repo.Attach(b);
            //b.Rating = 500;
            //repo.Update(b);
            //fsql.Update<Blog>(b);

            //fsql.Update<Topic>()
            //    .SetSource(items)
            //    .Set(a => a.CreateTime, DateTime.Now)
            //    .ExecuteAffrows();

            //OneToOne、ManyToOne
            //var blogs = fsql.Select<Blog>()
            //     .Where(a => a.CreateTime > DateTime.Now.AddDays(-1))
            //     .IncludeMany(x => x.Posts)
            //     .Page(1, 5)
            //     .ToList();

            //var post1 = fsql.Select<Post1>().Where(x => x.CreateTime > DateTime.Now).ToList();
        }

        public static void TestSubCompany()
        {
            //List<Guid> subCompanyId = new List<Guid>()
            //{
            //    Guid.Parse("5e724e04-335b-c438-002a-810112854f6e"), Guid.Parse("5e724e04-335b-c438-002a-810268666947")
            //    ,Guid.Parse("5e724e04-335b-c438-002a-81031929e6dc")
            //};
            var rps = fsql.GetRepository<SubCompany>();
            var userRps = fsql.GetRepository<User>();
            for (uint i = 0; i < 50; i++)
            {
                SubCompany s = new SubCompany() { Name = $"{DateTime.Now.ToString("s")}_{i}" };
                rps.Insert(s);  //内部会将插入后的自增值填充给 blog.Id
                List<User> arr = new List<User>();
                for (int j = 0; j < 5; j++)
                {
                    User user = new User() { SubCompanyId = s.Id, Name = $"{s.Id}___{j}" };
                    userRps.Insert(user);
                    arr.Add(user);
                }
              
            }
        }
    }
}
