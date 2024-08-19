
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("vi_sessionrelations")]
    public partial class ViSessionrelation : IEquatable<ViSessionrelation>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("sessionid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Sessionid { get; set; } // uuid
        [Column("relatedsessionid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Relatedsessionid { get; set; } // uuid
        [Column("starttime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Starttime { get; set; } // timestamp (6) without time zone
        [Column("endtime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Endtime { get; set; } // timestamp (6) without time zone
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViSessionrelation> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViSessionrelation>(c => c.Id);

        public bool Equals(ViSessionrelation? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViSessionrelation);
        }
        #endregion
    }
}
