
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("console_contactsgroups")]
    public partial class ConsoleContactsgroup : IEquatable<ConsoleContactsgroup>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("userid", DataType = DataType.Guid, DbType = "uuid")] public Guid Userid { get; set; } // uuid
        [Column("parentgroupid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Parentgroupid { get; set; } // uuid
        [Column("displayname", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string Displayname { get; set; } = null!; // character varying(512)
        [Column("relationshiplevel", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string Relationshiplevel { get; set; } = null!; // character varying(512)
        [Column("grouptype", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Grouptype { get; set; } // character varying(256)
        [Column("uri", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Uri { get; set; } // character varying(256)
        [Column("avatarurl", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Avatarurl { get; set; } // character varying(1024)
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConsoleContactsgroup> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConsoleContactsgroup>(c => c.Id);

        public bool Equals(ConsoleContactsgroup? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConsoleContactsgroup);
        }
        #endregion
    }
}
