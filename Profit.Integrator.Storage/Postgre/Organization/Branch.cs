
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("branches")]
    public partial class Branch : IEquatable<Branch>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("regionid", DataType = DataType.Guid, DbType = "uuid")] public Guid Regionid { get; set; } // uuid
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string Name { get; set; } = null!; // character varying(255)
        [Column("email", DataType = DataType.NVarChar, DbType = "character varying(100)", Length = 100)] public string? Email { get; set; } // character varying(100)
        [Column("address", DataType = DataType.Text, DbType = "text")] public string? Address { get; set; } // text

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Branch> _equalityComparer = ComparerBuilder.GetEqualityComparer<Branch>(c => c.Id);

        public bool Equals(Branch? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Branch);
        }
        #endregion
    }
}
