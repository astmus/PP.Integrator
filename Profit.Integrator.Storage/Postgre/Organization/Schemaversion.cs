
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Master
{
    [Table("schemaversions")]
    public partial class Schemaversion : IEquatable<Schemaversion>
    {
        [Column("schemaversionsid", DataType = DataType.Int32, DbType = "integer", IsPrimaryKey = true, IsIdentity = true, SkipOnInsert = true, SkipOnUpdate = true)] public int Schemaversionsid { get; set; } // integer
        [Column("scriptname", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string Scriptname { get; set; } = null!; // character varying(255)
        [Column("applied", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime Applied { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Schemaversion> _equalityComparer = ComparerBuilder.GetEqualityComparer<Schemaversion>(c => c.Schemaversionsid);

        public bool Equals(Schemaversion? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Schemaversion);
        }
        #endregion
    }
}
