
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("ui_pagegroups")]
    public partial class UiPagegroup : IEquatable<UiPagegroup>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Name { get; set; } = null!; // character varying(256)
        [Column("parentid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Parentid { get; set; } // uuid
        [Column("description", DataType = DataType.Text, DbType = "text")] public string? Description { get; set; } // text
        [Column("position", DataType = DataType.Int32, DbType = "integer")] public int? Position { get; set; } // integer
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<UiPagegroup> _equalityComparer = ComparerBuilder.GetEqualityComparer<UiPagegroup>(c => c.Id);

        public bool Equals(UiPagegroup? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as UiPagegroup);
        }
        #endregion
    }
}
