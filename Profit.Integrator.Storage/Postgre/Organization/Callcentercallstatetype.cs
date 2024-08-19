
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("callcentercallstatetypes")]
    public partial class Callcentercallstatetype : IEquatable<Callcentercallstatetype>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("cod", DataType = DataType.Int32, DbType = "integer")] public int Cod { get; set; } // integer
        [Column("title", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string Title { get; set; } = null!; // character varying(128)
        [Column("description", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length = 1024)] public string? Description { get; set; } // character varying(1024)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Callcentercallstatetype> _equalityComparer = ComparerBuilder.GetEqualityComparer<Callcentercallstatetype>(c => c.Id);

        public bool Equals(Callcentercallstatetype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Callcentercallstatetype);
        }
        #endregion
    }
}
