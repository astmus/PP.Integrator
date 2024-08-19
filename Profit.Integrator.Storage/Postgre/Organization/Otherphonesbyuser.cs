
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("otherphonesbyusers")]
    public partial class Otherphonesbyuser : IEquatable<Otherphonesbyuser>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("userid", DataType = DataType.Guid, DbType = "uuid")] public Guid Userid { get; set; } // uuid
        [Column("phone", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string Phone { get; set; } = null!; // character varying(128)
        [Column("place", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string Place { get; set; } = null!; // character varying(128)
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Otherphonesbyuser> _equalityComparer = ComparerBuilder.GetEqualityComparer<Otherphonesbyuser>(c => c.Id);

        public bool Equals(Otherphonesbyuser? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Otherphonesbyuser);
        }
        #endregion
    }
}
