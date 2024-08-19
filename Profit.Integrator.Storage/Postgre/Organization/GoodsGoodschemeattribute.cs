
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("goods_goodschemeattributes")]
    public partial class GoodsGoodschemeattribute : IEquatable<GoodsGoodschemeattribute>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("goodid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Goodid { get; set; } // uuid
        [Column("schemeattributeid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Schemeattributeid { get; set; } // uuid
        [Column("value", DataType = DataType.Text, DbType = "text")] public string? Value { get; set; } // text
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<GoodsGoodschemeattribute> _equalityComparer = ComparerBuilder.GetEqualityComparer<GoodsGoodschemeattribute>(c => c.Id);

        public bool Equals(GoodsGoodschemeattribute? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as GoodsGoodschemeattribute);
        }
        #endregion
    }
}
