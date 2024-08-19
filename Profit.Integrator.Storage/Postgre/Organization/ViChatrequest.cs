
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("vi_chatrequests")]
    public partial class ViChatrequest : IEquatable<ViChatrequest>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("sid", DataType = DataType.NVarChar, DbType = "character varying(6)", Length = 6)] public string? Sid { get; set; } // character varying(6)
        [Column("requestbody", DataType = DataType.Text, DbType = "text")] public string? Requestbody { get; set; } // text
        [Column("responsebody", DataType = DataType.Text, DbType = "text")] public string? Responsebody { get; set; } // text
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViChatrequest> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViChatrequest>(c => c.Id);

        public bool Equals(ViChatrequest? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViChatrequest);
        }
        #endregion
    }
}
