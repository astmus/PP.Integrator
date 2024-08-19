
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("settingschangelog")]
    public partial class Settingschangelog : IEquatable<Settingschangelog>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("dttm", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Dttm { get; set; } // timestamp (6) without time zone
        [Column("user", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? User { get; set; } // character varying(255)
        [Column("setting", DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string? Setting { get; set; } // character varying(255)
        [Column("value", DataType = DataType.NVarChar, DbType = "character varying(4000)", Length = 4000)] public string? Value { get; set; } // character varying(4000)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Settingschangelog> _equalityComparer = ComparerBuilder.GetEqualityComparer<Settingschangelog>(c => c.Id);

        public bool Equals(Settingschangelog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Settingschangelog);
        }
        #endregion
    }
}
