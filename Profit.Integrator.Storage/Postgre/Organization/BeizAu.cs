
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("beiz_au")]
    public partial class BeizAu : IEquatable<BeizAu>
    {
        [Column("id"  , DataType  = DataType.Guid , DbType   = "uuid"           , IsPrimaryKey = true                                  )] public Guid   Id   { get; set; } // uuid
        [Column("user", DataType  = DataType.Guid , DbType   = "uuid"                                                                  )] public Guid   User { get; set; } // uuid
        [Column("word", CanBeNull = false         , DataType = DataType.NVarChar, DbType       = "character varying(255)", Length = 255)] public string Word { get; set; } = null!; // character varying(255)
        [Column("freq", DataType  = DataType.Int32, DbType   = "integer"                                                               )] public int    Freq { get; set; } // integer

        #region IEquatable<T> support
        private static readonly IEqualityComparer<BeizAu> _equalityComparer = ComparerBuilder.GetEqualityComparer<BeizAu>(c => c.Id);

        public bool Equals(BeizAu? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BeizAu);
        }
        #endregion
    }
}
