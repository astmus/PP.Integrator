
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("callcentercallstatetimeslot")]
    public partial class Callcentercallstatetimeslot : IEquatable<Callcentercallstatetimeslot>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("logtime", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Logtime { get; set; } // timestamp (6) without time zone
        [Column("userwaitingcount", DataType = DataType.Int32, DbType = "integer")] public int? Userwaitingcount { get; set; } // integer
        [Column("userspeakingcount", DataType = DataType.Int32, DbType = "integer")] public int? Userspeakingcount { get; set; } // integer
        [Column("userinivrmenucount", DataType = DataType.Int32, DbType = "integer")] public int? Userinivrmenucount { get; set; } // integer
        [Column("operatorpausingcount", DataType = DataType.Int32, DbType = "integer")] public int? Operatorpausingcount { get; set; } // integer
        [Column("operatorworkingcount", DataType = DataType.Int32, DbType = "integer")] public int? Operatorworkingcount { get; set; } // integer
        [Column("operatorspeakingcount", DataType = DataType.Int32, DbType = "integer")] public int? Operatorspeakingcount { get; set; } // integer
        [Column("simulincomecallcount", DataType = DataType.Int32, DbType = "integer")] public int? Simulincomecallcount { get; set; } // integer
        [Column("simuloutgoingcallcount", DataType = DataType.Int32, DbType = "integer")] public int? Simuloutgoingcallcount { get; set; } // integer

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Callcentercallstatetimeslot> _equalityComparer = ComparerBuilder.GetEqualityComparer<Callcentercallstatetimeslot>(c => c.Id);

        public bool Equals(Callcentercallstatetimeslot? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Callcentercallstatetimeslot);
        }
        #endregion
    }
}
