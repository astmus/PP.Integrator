
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("guiincidentuserattributetypes")]
    public partial class Guiincidentuserattributetype : IEquatable<Guiincidentuserattributetype>
    {
        [Column("id"  , DataType = DataType.Guid    , DbType = "uuid"                 , IsPrimaryKey = true)] public Guid    Id   { get; set; } // uuid
        [Column("name", DataType = DataType.NVarChar, DbType = "character varying(32)", Length       = 32  )] public string? Name { get; set; } // character varying(32)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Guiincidentuserattributetype> _equalityComparer = ComparerBuilder.GetEqualityComparer<Guiincidentuserattributetype>(c => c.Id);

        public bool Equals(Guiincidentuserattributetype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Guiincidentuserattributetype);
        }
        #endregion
    }
}
