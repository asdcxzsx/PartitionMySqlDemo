using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MySql.Data;
using MySql.Data.MySqlClient;
//https://www.cnblogs.com/756623607-zhang/p/6656022.html
//Mycat水平拆分之十种分片规则
namespace ConsoleApp
{

    class Program
    {


        static void Main(string[] args)
        {
            //TestBySql();
            //TestPomeloMysql();

            //FreeSqlTest.TestFreeSql();
            FreeSqlTest.TestSubCompany();
        }

        static void TestPomeloMysql()
        {
            //using (BloggingContext ctx = new BloggingContext())
            //{
            //    //ctx.Database.EnsureCreated();
            //    var blogs = ctx.Blogs.Include(x => x.Posts).ToList();
            //    foreach (var blog in blogs)
            //    {
            //        var ew = blog.Posts;
            //        ew.ToList().ForEach(q =>
            //        {
            //            Console.WriteLine($"Blog:{q.Title}");
            //        });
            //        //var lst = ctx.Posts.Where(x => x.BlogId == blog.Id);
            //    }
            //    Random r = new Random();
            //    //ctx.Blogs.Add(new Blog() { Rating = (uint)r.Next(0, 10), Url = $"http://www.baidu.com/{DateTime.Now.Ticks}" });
            //    //ctx.SaveChanges();
            //}
        }

        static void TestBySql()
        {
            string constructorString = "Server=127.0.0.1;Port=8066;Database=TESTDB;User=root;Password=123456;";
            MySqlConnection myConnnect = new MySqlConnection(constructorString);
            myConnnect.Open();
            MySqlCommand myCmd = new MySqlCommand($"INSERT INTO `blog` (`Id`,`Url`, `Rating`,`CreateTime`) VALUES ('{Guid.NewGuid()}','http://www.youku.com/', '0','{DateTime.Now.AddDays(-50).ToString("s")}');", myConnnect);
            Console.WriteLine(myCmd.CommandText);
            if (myCmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("数据插入成功！");
            }
            for (int i = 0; i < 50; i++)
            {
                var time = DateTime.Now.AddDays(i).ToString("s");
                var id = Guid.NewGuid();
                myCmd.CommandText = $"INSERT INTO `blog` (`Id`,`Url`, `Rating`,`CreateTime`)" +
                                    $" VALUES ('{id}','http://www.youku.com/', '{i}','{time}');";
                if (myCmd.ExecuteNonQuery() > 0)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        myCmd.CommandText = $"INSERT INTO `post` (`Id`,`Title`, `Content`,`BlogId`,`CreateTime`) Values('{Guid.NewGuid().ToString()}','{DateTime.Now}','','{id}','{time}');";
                        myCmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("数据插入成功！");
            }

            myCmd.CommandText = "delete from blogs";
            //Console.WriteLine(myCmd.CommandText);
            //if (myCmd.ExecuteNonQuery() > 0)
            //{
            //    Console.WriteLine("blogs表类型数据全部删除成功！");
            //}
            myCmd.Dispose();
            myConnnect.Close();
        }
    }
}
/*

    Pomelo.EntityFrameworkCore.MyCat

    Pomelo.EntityFrameworkCore.MySql



 *1、ADD PARTITION （新增分区）
ALTER TABLE t1 ADD PARTITION (PARTITION p3 VALUES LESS THAN (2002));
 alter table hash_partition_tbl partition by hash(a) partitions 4;   //不能删除 合并
 a是无符号整数

2、DROP PARTITION （删除分区）
ALTER TABLE t1 DROP PARTITION p0, p1;

3、TRUNCATE PARTITION（截取分区）
ALTER TABLE t1 TRUNCATE PARTITION p0;

ALTER TABLE t1 TRUNCATE PARTITION p1, p3;
 *
 * 
 * COALESCE PARTITION（合并分区）
 * ALTER TABLE t2 COALESCE PARTITION 2;
 */
