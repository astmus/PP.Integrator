
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("console_contacts")]
    public partial class ConsoleContact : IEquatable<ConsoleContact>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("sip", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Sip { get; set; } = null!; // character varying(256)
        [Column("displayname", DataType = DataType.NVarChar, DbType = "character varying(445)", Length = 445)] public string? Displayname { get; set; } // character varying(445)
        [Column("avatarurl", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Avatarurl { get; set; } // character varying(1024)
        [Column("persontype", DataType = DataType.NVarChar, DbType = "character varying(16)", Length = 16)] public string? Persontype { get; set; } // character varying(16)
        [Column("company", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Company { get; set; } // character varying(512)
        [Column("department", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Department { get; set; } // character varying(512)
        [Column("office", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Office { get; set; } // character varying(512)
        [Column("position", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Position { get; set; } // character varying(512)
        [Column("note", DataType = DataType.Text, DbType = "text")] public string? Note { get; set; } // text
        [Column("comments", DataType = DataType.Text, DbType = "text")] public string? Comments { get; set; } // text
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConsoleContact> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConsoleContact>(c => c.Id);

        public bool Equals(ConsoleContact? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConsoleContact);
        }
        #endregion
    }
}
