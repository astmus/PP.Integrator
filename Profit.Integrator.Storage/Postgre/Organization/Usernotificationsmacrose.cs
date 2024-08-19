
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("usernotificationsmacroses")]
    public partial class Usernotificationsmacrose : IEquatable<Usernotificationsmacrose>
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid", IsPrimaryKey = true)] public Guid Id { get; set; } // uuid
        [Column("macrostitle", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Macrostitle { get; set; } = null!; // character varying(256)
        [Column("macrosname", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Macrosname { get; set; } = null!; // character varying(256)
        [Column("macrosvalue", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(256)", Length = 256)] public string Macrosvalue { get; set; } = null!; // character varying(256)
        [Column("userproperties", DataType = DataType.Text, DbType = "text")] public string? Userproperties { get; set; } // text
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Usernotificationsmacrose> _equalityComparer = ComparerBuilder.GetEqualityComparer<Usernotificationsmacrose>(c => c.Id);

        public bool Equals(Usernotificationsmacrose? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Usernotificationsmacrose);
        }
        #endregion
    }
}
