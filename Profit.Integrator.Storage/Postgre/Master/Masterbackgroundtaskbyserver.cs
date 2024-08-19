
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("masterbackgroundtaskbyservers")]
    public partial class Masterbackgroundtaskbyserver : IEquatable<Masterbackgroundtaskbyserver>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("server", DataType = DataType.Guid, DbType = "uuid")] public Guid Server { get; set; } // uuid
        [Column("masterbackgroundtask", DataType = DataType.Guid, DbType = "uuid")] public Guid Masterbackgroundtask { get; set; } // uuid
        [Column("updatetime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updatetime { get; set; } // timestamp (6) without time zone
        [Column("laststarttime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Laststarttime { get; set; } // timestamp (6) without time zone
        [Column("lastsaccessfulcompletetime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Lastsaccessfulcompletetime { get; set; } // timestamp (6) without time zone
        [Column("nextstarttime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Nextstarttime { get; set; } // timestamp (6) without time zone
        [Column("isactive", DataType = DataType.Boolean, DbType = "boolean")] public bool? Isactive { get; set; } // boolean
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
        [Column("startfromtime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Startfromtime { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Masterbackgroundtaskbyserver> _equalityComparer = ComparerBuilder.GetEqualityComparer<Masterbackgroundtaskbyserver>(c => c.Id);

        public bool Equals(Masterbackgroundtaskbyserver? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Masterbackgroundtaskbyserver);
        }
        #endregion
    }
}
