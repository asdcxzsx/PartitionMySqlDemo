using System;
using System.Collections.Generic;
using System.Text;
using FreeSql.DataAnnotations;

namespace ConsoleApp.Models
{
    [Table(Name = "Blog")]
    [Index("IX_time", "CreateTime", false)]
    public class Blog
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public Guid Id { get; set; }

        [Column(DbType = "varchar(128) NOT NULL")]
        public string Url { get; set; }
        public uint Rating { get; set; }
        public DateTime CreateTime { get; set; }
        //[NotMapped]
        public virtual List<Post> Posts { get; set; } = new List<Post>();
    }
    [Table(Name = "Post")]
    public class Post
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("post_id")]
        [Column(IsIdentity = true, IsPrimary = true)]
        public Guid Id { get; set; }

        public string Title { get; set; }

        //[Column("Id")]

        public Guid BlogId { get; set; }
        //[NotMapped]

        public virtual Blog Blog { get; set; }

        public DateTime CreateTime { get; set; }
    }


    /// <summary>
    /// 唯一键(Unique Key)、索引（Index）
    /// 第三个参数 true 的时候是唯一键，false 的时候是普通索引。
    /// </summary>
    [Index("uk_phone", "phone", true)]
    [Index("uk_group_index", "group,index", true)]
    [Index("uk_group_index22", "group, index22 desc", true)]
    class AddUniquesInfo
    {
        public Guid id { get; set; }
        public string phone { get; set; }

        public string group { get; set; }
        public int index { get; set; }
        public string index22 { get; set; }
    }
}
