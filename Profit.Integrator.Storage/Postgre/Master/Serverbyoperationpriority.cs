
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("serverbyoperationpriorities")]
    public partial class Serverbyoperationpriority : IEquatable<Serverbyoperationpriority>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("serverid", DataType = DataType.Guid, DbType = "uuid")] public Guid Serverid { get; set; } // uuid
        [Column("operationname", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string Operationname { get; set; } = null!; // character varying(512)
        [Column("priority", DataType = DataType.Int32, DbType = "integer")] public int? Priority { get; set; } // integer
        [Column("createdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createdate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Serverbyoperationpriority> _equalityComparer = ComparerBuilder.GetEqualityComparer<Serverbyoperationpriority>(c => c.Id);

        public bool Equals(Serverbyoperationpriority? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Serverbyoperationpriority);
        }
        #endregion
    }
}
