
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("notifychannels")]
    public partial class Notifychannel : IEquatable<Notifychannel>
    {
        [Column("id"       , DataType  = DataType.Guid   , DbType   = "uuid"           , IsPrimaryKey = true                                )] public Guid   Id        { get; set; } // uuid
        [Column("name"     , CanBeNull = false           , DataType = DataType.NVarChar, DbType       = "character varying(32)", Length = 32)] public string Name      { get; set; } = null!; // character varying(32)
        [Column("isactive" , DataType  = DataType.Boolean, DbType   = "boolean"                                                             )] public bool?  Isactive  { get; set; } // boolean
        [Column("isdeleted", DataType  = DataType.Boolean, DbType   = "boolean"                                                             )] public bool?  Isdeleted { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Notifychannel> _equalityComparer = ComparerBuilder.GetEqualityComparer<Notifychannel>(c => c.Id);

        public bool Equals(Notifychannel? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Notifychannel);
        }
        #endregion
    }
}
