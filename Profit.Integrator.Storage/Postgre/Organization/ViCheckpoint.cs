
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("vi_checkpoints")]
    public partial class ViCheckpoint : IEquatable<ViCheckpoint>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("sessionid", DataType = DataType.Guid, DbType = "uuid")] public Guid Sessionid { get; set; } // uuid
        [Column("prevstepid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Prevstepid { get; set; } // uuid
        [Column("stepid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Stepid { get; set; } // uuid
        [Column("iteration", DataType = DataType.Int32, DbType = "integer")] public int? Iteration { get; set; } // integer
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("updateddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViCheckpoint> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViCheckpoint>(c => c.Id);

        public bool Equals(ViCheckpoint? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViCheckpoint);
        }
        #endregion
    }
}
