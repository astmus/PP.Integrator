
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("sd_entitieschangelog")]
    public partial class SdEntitieschangelog : IEquatable<SdEntitieschangelog>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("internalid", DataType = DataType.Int64, DbType = "bigint")] public long Internalid { get; set; } // bigint
        [Column("entityid", DataType = DataType.Guid, DbType = "uuid")] public Guid Entityid { get; set; } // uuid
        [Column("entitytypeid", DataType = DataType.Int32, DbType = "integer")] public int Entitytypeid { get; set; } // integer
        [Column("columnname", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string Columnname { get; set; } = null!; // character varying(128)
        [Column("prevalue", DataType = DataType.Text, DbType = "text")] public string? Prevalue { get; set; } // text
        [Column("postvalue", DataType = DataType.Text, DbType = "text")] public string? Postvalue { get; set; } // text
        [Column("authorid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Authorid { get; set; } // uuid
        [Column("lastmodified", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Lastmodified { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdEntitieschangelog> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdEntitieschangelog>(c => c.Id);

        public bool Equals(SdEntitieschangelog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdEntitieschangelog);
        }
        #endregion
    }
}
