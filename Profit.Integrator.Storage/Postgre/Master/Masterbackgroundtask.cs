
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("masterbackgroundtasks")]
    public partial class Masterbackgroundtask : IEquatable<Masterbackgroundtask>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string Name { get; set; } = null!; // character varying(512)
        [Column("description", DataType = DataType.Text, DbType = "text")] public string? Description { get; set; } // text
        [Column("rangeparams", DataType = DataType.Text, DbType = "text")] public string? Rangeparams { get; set; } // text
        [Column("weight", DataType = DataType.Int32, DbType = "integer")] public int? Weight { get; set; } // integer
        [Column("duetime", DataType = DataType.Int32, DbType = "integer")] public int? Duetime { get; set; } // integer
        [Column("period", DataType = DataType.Int32, DbType = "integer")] public int? Period { get; set; } // integer
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Masterbackgroundtask> _equalityComparer = ComparerBuilder.GetEqualityComparer<Masterbackgroundtask>(c => c.Id);

        public bool Equals(Masterbackgroundtask? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Masterbackgroundtask);
        }
        #endregion
    }
}
