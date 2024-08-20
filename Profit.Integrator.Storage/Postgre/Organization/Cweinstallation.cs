
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("cweinstallation")]
    public partial class Cweinstallation : IEquatable<Cweinstallation>
    {
        [Column("id"       , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id        { get; set; } // uuid
        [Column("useruri"  , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?  Useruri   { get; set; } // character varying(50)
        [Column("ip"       , DataType = DataType.NVarChar , DbType = "character varying(50)"          , Length       = 50  )] public string?  Ip        { get; set; } // character varying(50)
        [Column("checkdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Checkdate { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Cweinstallation> _equalityComparer = ComparerBuilder.GetEqualityComparer<Cweinstallation>(c => c.Id);

        public bool Equals(Cweinstallation? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Cweinstallation);
        }
        #endregion
    }
}
