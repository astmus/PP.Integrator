
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("sd_workitem_relatedknowledgearticles")]
    public partial class SdWorkitemRelatedknowledgearticle : IEquatable<SdWorkitemRelatedknowledgearticle>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("workitemid", DataType = DataType.Guid, DbType = "uuid")] public Guid Workitemid { get; set; } // uuid
        [Column("articleid", DataType = DataType.Guid, DbType = "uuid")] public Guid Articleid { get; set; } // uuid
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("userid", DataType = DataType.Guid, DbType = "uuid")] public Guid Userid { get; set; } // uuid
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdWorkitemRelatedknowledgearticle> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdWorkitemRelatedknowledgearticle>(c => c.Id);

        public bool Equals(SdWorkitemRelatedknowledgearticle? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdWorkitemRelatedknowledgearticle);
        }
        #endregion
    }
}
