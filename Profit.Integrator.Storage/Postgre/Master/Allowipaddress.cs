
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("allowipaddresses")]
    public partial class Allowipaddress : IEquatable<Allowipaddress>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("senderaddress", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Senderaddress { get; set; } // character varying(512)
        [Column("operationname", DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string? Operationname { get; set; } // character varying(512)
        [Column("createdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createdate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Allowipaddress> _equalityComparer = ComparerBuilder.GetEqualityComparer<Allowipaddress>(c => c.Id);

        public bool Equals(Allowipaddress? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Allowipaddress);
        }
        #endregion
    }
}
