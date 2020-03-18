using System;
using System.Collections.Generic;
using System.Text;
using FreeSql.DataAnnotations;

namespace ConsoleApp.Models
{
    [Table(Name = "SubCompany")]
    [Index("IX_Name", "Name", false)]
    public class SubCompany
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public Guid Id { get; set; }

        [Column(DbType = "varchar(128) NOT NULL")]
        public string Name { get; set; }

    }
    [Table(Name = "User")]
    [Index("IX_Name", "Name", false)]
    public class User
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public Guid Id { get; set; }

        public Guid SubCompanyId { get; set; }

        [Column(DbType = "varchar(128) NOT NULL")]
        public string Name { get; set; }

        public SubCompany SubCompany { get; set; }
    }
}
