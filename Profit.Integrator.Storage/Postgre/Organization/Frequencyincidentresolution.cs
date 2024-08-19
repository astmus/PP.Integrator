
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("frequencyincidentresolution")]
    public partial class Frequencyincidentresolution : IEquatable<Frequencyincidentresolution>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("User", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(100)", Length = 100)] public string User { get; set; } = null!; // character varying(100)
        [Column("classification", DataType = DataType.Guid, DbType = "uuid")] public Guid? Classification { get; set; } // uuid
        [Column("countincidents", DataType = DataType.Int32, DbType = "integer")] public int Countincidents { get; set; } // integer

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Frequencyincidentresolution> _equalityComparer = ComparerBuilder.GetEqualityComparer<Frequencyincidentresolution>(c => c.Id);

        public bool Equals(Frequencyincidentresolution? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Frequencyincidentresolution);
        }
        #endregion
    }
}
