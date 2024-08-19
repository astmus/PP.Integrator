
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("sd_tierqueuesenummembers")]
    public partial class SdTierqueuesenummember : IEquatable<SdTierqueuesenummember>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("tierqueuesenumid", DataType = DataType.Guid, DbType = "uuid")] public Guid Tierqueuesenumid { get; set; } // uuid
        [Column("groupid", DataType = DataType.Guid, DbType = "uuid")] public Guid Groupid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Updatedbyuserid { get; set; } // uuid
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isdeleted { get; set; } // boolean
        [Column("createdbyuserid", DataType = DataType.Guid, DbType = "uuid")] public Guid Createdbyuserid { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdTierqueuesenummember> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdTierqueuesenummember>(c => c.Id);

        public bool Equals(SdTierqueuesenummember? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdTierqueuesenummember);
        }
        #endregion
    }
}
