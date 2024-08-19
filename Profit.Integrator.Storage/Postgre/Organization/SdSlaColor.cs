
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("sd_sla_colors")]
    public partial class SdSlaColor : IEquatable<SdSlaColor>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("slastate", DataType = DataType.NVarChar, DbType = "character varying(64)", Length = 64)] public string? Slastate { get; set; } // character varying(64)
        [Column("statecolor", DataType = DataType.NVarChar, DbType = "character varying(16)", Length = 16)] public string? Statecolor { get; set; } // character varying(16)
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdSlaColor> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdSlaColor>(c => c.Id);

        public bool Equals(SdSlaColor? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdSlaColor);
        }
        #endregion
    }
}
