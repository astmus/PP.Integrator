
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("guiincidentforms")]
    public partial class Guiincidentform : IEquatable<Guiincidentform>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("title", CanBeNull = false, DataType = DataType.Text, DbType = "text")] public string Title { get; set; } = null!; // text
        [Column("description", DataType = DataType.Text, DbType = "text")] public string? Description { get; set; } // text
        [Column("formproperties", DataType = DataType.Text, DbType = "text")] public string? Formproperties { get; set; } // text
        [Column("createdate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Createdate { get; set; } // timestamp (6) without time zone
        [Column("deletedate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Deletedate { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Guiincidentform> _equalityComparer = ComparerBuilder.GetEqualityComparer<Guiincidentform>(c => c.Id);

        public bool Equals(Guiincidentform? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Guiincidentform);
        }
        #endregion
    }
}
