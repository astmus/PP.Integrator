
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("guiincidentuserattributesourcetypes")]
    public partial class Guiincidentuserattributesourcetype : IEquatable<Guiincidentuserattributesourcetype>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("name", DataType = DataType.NVarChar, DbType = "character varying(64)", Length = 64)] public string? Name { get; set; } // character varying(64)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Guiincidentuserattributesourcetype> _equalityComparer = ComparerBuilder.GetEqualityComparer<Guiincidentuserattributesourcetype>(c => c.Id);

        public bool Equals(Guiincidentuserattributesourcetype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Guiincidentuserattributesourcetype);
        }
        #endregion
    }
}
