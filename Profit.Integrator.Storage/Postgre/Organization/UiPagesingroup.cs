
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("ui_pagesingroups")]
    public partial class UiPagesingroup : IEquatable<UiPagesingroup>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("pageid", DataType = DataType.Guid, DbType = "uuid")] public Guid Pageid { get; set; } // uuid
        [Column("groupid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Groupid { get; set; } // uuid
        [Column("priority", DataType = DataType.Int32, DbType = "integer")] public int? Priority { get; set; } // integer
        [Column("position", DataType = DataType.Int32, DbType = "integer")] public int? Position { get; set; } // integer
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<UiPagesingroup> _equalityComparer = ComparerBuilder.GetEqualityComparer<UiPagesingroup>(c => c.Id);

        public bool Equals(UiPagesingroup? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as UiPagesingroup);
        }
        #endregion
    }
}
