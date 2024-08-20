
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("console_contactsphones")]
    public partial class ConsoleContactsphone : IEquatable<ConsoleContactsphone>
    {
        [Column("id"       , DataType  = DataType.Guid   , DbType   = "uuid"           , IsPrimaryKey = true                                )] public Guid   Id        { get; set; } // uuid
        [Column("contactid", DataType  = DataType.Guid   , DbType   = "uuid"                                                                )] public Guid   Contactid { get; set; } // uuid
        [Column("phone"    , CanBeNull = false           , DataType = DataType.NVarChar, DbType       = "character varying(64)", Length = 64)] public string Phone     { get; set; } = null!; // character varying(64)
        [Column("place"    , CanBeNull = false           , DataType = DataType.NVarChar, DbType       = "character varying(64)", Length = 64)] public string Place     { get; set; } = null!; // character varying(64)
        [Column("isdeleted", DataType  = DataType.Boolean, DbType   = "boolean"                                                             )] public bool   Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConsoleContactsphone> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConsoleContactsphone>(c => c.Id);

        public bool Equals(ConsoleContactsphone? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConsoleContactsphone);
        }
        #endregion
    }
}
