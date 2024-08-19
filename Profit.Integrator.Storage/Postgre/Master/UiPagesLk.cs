
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("ui_pages_lk")]
    public partial class UiPagesLk : IEquatable<UiPagesLk>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("parentid", DataType = DataType.Guid, DbType = "uuid")] public Guid? Parentid { get; set; } // uuid
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Name { get; set; } = null!; // character varying(256)
        [Column("ico", DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string? Ico { get; set; } // character varying(256)
        [Column("position", DataType = DataType.Int32, DbType = "integer")] public int? Position { get; set; } // integer
        [Column("uri", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Uri { get; set; } // character varying(1024)
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
        [Column("isfolder", DataType = DataType.Boolean, DbType = "boolean")] public bool Isfolder { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<UiPagesLk> _equalityComparer = ComparerBuilder.GetEqualityComparer<UiPagesLk>(c => c.Id);

        public bool Equals(UiPagesLk? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as UiPagesLk);
        }
        #endregion
    }
}
