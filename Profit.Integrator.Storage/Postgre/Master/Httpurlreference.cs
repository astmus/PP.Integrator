
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("httpurlreferences")]
    public partial class Httpurlreference : IEquatable<Httpurlreference>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("code", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(8)", Length = 8)] public string Code { get; set; } = null!; // character varying(8)
        [Column("url", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Url { get; set; } // character varying(1024)
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
        [Column("expireson", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Expireson { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Httpurlreference> _equalityComparer = ComparerBuilder.GetEqualityComparer<Httpurlreference>(c => c.Id);

        public bool Equals(Httpurlreference? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Httpurlreference);
        }
        #endregion
    }
}
