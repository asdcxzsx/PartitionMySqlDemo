using System;

namespace ConsoleApp1
{
    class Program
    {
        public static IFreeSql fsql = new FreeSql.FreeSqlBuilder()
             .UseConnectionString(FreeSql.DataType.MySql, @"Server=127.0.0.1;Port=3306;Database=LogDB;User=root;Password=123456;")
             .UseAutoSyncStructure(true) //自动同步实体结构到数据库
             .Build(); //请务必定义成 Singleton 单例模式

        static void Main(string[] args)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    Log l = new Log();
            //    l.Msg = Guid.NewGuid().ToString();
            //    l.CreateTime = DateTime.Now.AddSeconds(i);
            //    fsql.Insert(l).ExecuteAffrows();
            //}
            var lst = fsql.Select<Log>().ToList();
            var one = lst[0];
            if (one != null)
            {
                //fsql.Update<Log>(new { Id = one.Id }).Set(x => x.CreateTime == DateTime.Today.AddMonths(2))
                //    .ExecuteAffrows();

                using (var ctx = new Context())
                {
                    ctx.Orm.Update<Log>(new { Id = one.Id, CreateTime = one.CreateTime }).Set(x => x.CreateTime == DateTime.Today.AddMonths(2))
                        .ExecuteAffrows();
                    ctx.SaveChanges();
                }
            }



            //select PARTITION_NAME as "分区",TABLE_ROWS as "行数" from information_schema.partitions where table_schema="mysql_test" and table_name="test_11";
        }
    }
}

/*
 *
 * select PARTITION_NAME as "分区",TABLE_ROWS as "行数" from information_schema.partitions where table_schema="logdb" and table_name="log";

select to_days('2020-04-01');  # 737881

alter table logdb.log PARTITION BY RANGE (to_days(CreateTime))(PARTITION p20200401 VALUES LESS THAN (to_days('2020-04-20')));

ALTER TABLE logdb.log ADD PARTITION (PARTITION p20200501 VALUES LESS THAN (to_days('2020-05-01')));
 */
