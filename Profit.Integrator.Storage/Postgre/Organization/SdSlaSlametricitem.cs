
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("sd_sla_slametricitems")]
    public partial class SdSlaSlametricitem : IEquatable<SdSlaSlametricitem>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("slaid", DataType = DataType.Guid, DbType = "uuid")] public Guid Slaid { get; set; } // uuid
        [Column("metricid", DataType = DataType.Guid, DbType = "uuid")] public Guid Metricid { get; set; } // uuid
        [Column("urgencyid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Urgencyid { get; set; } // uuid
        [Column("impactid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Impactid { get; set; } // uuid
        [Column("warningoffsetminutes", DataType = DataType.Int32, DbType = "integer")] public int? Warningoffsetminutes { get; set; } // integer
        [Column("limitminutes", DataType = DataType.Int32, DbType = "integer")] public int? Limitminutes { get; set; } // integer
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdSlaSlametricitem> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdSlaSlametricitem>(c => c.Id);

        public bool Equals(SdSlaSlametricitem? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdSlaSlametricitem);
        }
        #endregion
    }
}
