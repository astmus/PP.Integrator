
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("usercontacttypes")]
    public partial class Usercontacttype : IEquatable<Usercontacttype>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("title", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Title { get; set; } = null!; // character varying(256)
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Usercontacttype> _equalityComparer = ComparerBuilder.GetEqualityComparer<Usercontacttype>(c => c.Id);

        public bool Equals(Usercontacttype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Usercontacttype);
        }
        #endregion
    }
}
