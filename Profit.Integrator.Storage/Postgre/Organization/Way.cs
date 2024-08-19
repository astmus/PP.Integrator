
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("ways")]
    public partial class Way : IEquatable<Way>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("scriptid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Scriptid { get; set; } // uuid
        [Column("solutionid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Solutionid { get; set; } // uuid
        [Column("scriptorder", DataType = DataType.Int32, DbType = "integer")] public int? Scriptorder { get; set; } // integer
        [Column("comment", DataType = DataType.Text, DbType = "text")] public string? Comment { get; set; } // text

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Way> _equalityComparer = ComparerBuilder.GetEqualityComparer<Way>(c => c.Id);

        public bool Equals(Way? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Way);
        }
        #endregion
    }
}
