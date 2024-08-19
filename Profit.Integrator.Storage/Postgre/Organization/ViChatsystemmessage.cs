
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("vi_chatsystemmessages")]
    public partial class ViChatsystemmessage : IEquatable<ViChatsystemmessage>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("onevent", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Onevent { get; set; } // character varying(128)
        [Column("accountid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Accountid { get; set; } // uuid
        [Column("condition", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Condition { get; set; } // character varying(1024)
        [Column("message", DataType = DataType.Text, DbType = "text")] public string? Message { get; set; } // text
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViChatsystemmessage> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViChatsystemmessage>(c => c.Id);

        public bool Equals(ViChatsystemmessage? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViChatsystemmessage);
        }
        #endregion
    }
}
