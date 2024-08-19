
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("goods_goods")]
    public partial class GoodsGood : IEquatable<GoodsGood>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("cod", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Cod { get; set; } // character varying(128)
        [Column("originalname", DataType = DataType.NVarChar, DbType = "character varying(2046)", Length = 2046)] public string? Originalname { get; set; } // character varying(2046)
        [Column("finalname", DataType = DataType.NVarChar, DbType = "character varying(2046)", Length = 2046)] public string? Finalname { get; set; } // character varying(2046)
        [Column("brandid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Brandid { get; set; } // uuid
        [Column("position", DataType = DataType.Int32, DbType = "integer")] public int? Position { get; set; } // integer
        [Column("objectschemeid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Objectschemeid { get; set; } // uuid
        [Column("externalid", DataType = DataType.NVarChar, DbType = "character varying(64)", Length = 64)] public string? Externalid { get; set; } // character varying(64)
        [Column("source", DataType = DataType.NVarChar, DbType = "character varying(8)", Length = 8)] public string? Source { get; set; } // character varying(8)
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<GoodsGood> _equalityComparer = ComparerBuilder.GetEqualityComparer<GoodsGood>(c => c.Id);

        public bool Equals(GoodsGood? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as GoodsGood);
        }
        #endregion
    }
}
