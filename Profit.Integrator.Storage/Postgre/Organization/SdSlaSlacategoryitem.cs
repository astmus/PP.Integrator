
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("sd_sla_slacategoryitems")]
    public partial class SdSlaSlacategoryitem : IEquatable<SdSlaSlacategoryitem>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("slaid", DataType = DataType.Guid, DbType = "uuid")] public Guid Slaid { get; set; } // uuid
        [Column("classificationid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Classificationid { get; set; } // uuid
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdSlaSlacategoryitem> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdSlaSlacategoryitem>(c => c.Id);

        public bool Equals(SdSlaSlacategoryitem? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdSlaSlacategoryitem);
        }
        #endregion
    }
}
