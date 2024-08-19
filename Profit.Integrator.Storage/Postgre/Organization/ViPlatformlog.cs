
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("vi_platformlog")]
    public partial class ViPlatformlog : IEquatable<ViPlatformlog>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("platformid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Platformid { get; set; } // uuid
        [Column("accountid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Accountid { get; set; } // uuid
        [Column("method", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Method { get; set; } // character varying(128)
        [Column("context", DataType = DataType.Text, DbType = "text")] public string? Context { get; set; } // text
        [Column("message", DataType = DataType.Text, DbType = "text")] public string? Message { get; set; } // text
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViPlatformlog> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViPlatformlog>(c => c.Id);

        public bool Equals(ViPlatformlog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViPlatformlog);
        }
        #endregion
    }
}
