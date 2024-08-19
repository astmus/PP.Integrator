
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("goods_wordprocessings")]
    public partial class GoodsWordprocessing : IEquatable<GoodsWordprocessing>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("goodid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Goodid { get; set; } // uuid
        [Column("originalword", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Originalword { get; set; } // character varying(256)
        [Column("position", DataType = DataType.Int32, DbType = "integer")] public int? Position { get; set; } // integer
        [Column("word", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Word { get; set; } // character varying(256)
        [Column("selected", DataType = DataType.Boolean, DbType = "boolean")] public bool? Selected { get; set; } // boolean
        [Column("holded", DataType = DataType.Boolean, DbType = "boolean")] public bool? Holded { get; set; } // boolean
        [Column("inbrand", DataType = DataType.Boolean, DbType = "boolean")] public bool? Inbrand { get; set; } // boolean
        [Column("highlighted", DataType = DataType.Boolean, DbType = "boolean")] public bool? Highlighted { get; set; } // boolean
        [Column("ignored", DataType = DataType.Boolean, DbType = "boolean")] public bool? Ignored { get; set; } // boolean
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<GoodsWordprocessing> _equalityComparer = ComparerBuilder.GetEqualityComparer<GoodsWordprocessing>(c => c.Id);

        public bool Equals(GoodsWordprocessing? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as GoodsWordprocessing);
        }
        #endregion
    }
}
