
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("log_objectsprocess")]
    public partial class LogObjectsprocess : IEquatable<LogObjectsprocess>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("objecttypeid", DataType = DataType.Guid, DbType = "uuid")] public Guid Objecttypeid { get; set; } // uuid
        [Column("objecttypetransactionid", DataType = DataType.Guid, DbType = "uuid")] public Guid Objecttypetransactionid { get; set; } // uuid
        [Column("objectid", DataType = DataType.Guid, DbType = "uuid")] public Guid Objectid { get; set; } // uuid
        [Column("statetransaction", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(20)", Length = 20)] public string Statetransaction { get; set; } = null!; // character varying(20)
        [Column("eventtime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Eventtime { get; set; } // timestamp (6) without time zone
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<LogObjectsprocess> _equalityComparer = ComparerBuilder.GetEqualityComparer<LogObjectsprocess>(c => c.Id);

        public bool Equals(LogObjectsprocess? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as LogObjectsprocess);
        }
        #endregion
    }
}
