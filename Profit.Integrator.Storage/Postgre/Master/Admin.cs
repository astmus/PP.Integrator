
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("admins")]
    public partial class Admin : IEquatable<Admin>
    {
        [Column("id"         , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id          { get; set; } // uuid
        [Column("sid"        , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(256)", Length = 256)] public string    Sid         { get; set; } = null!; // character varying(256)
        [Column("sip"        , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                   )] public string?   Sip         { get; set; } // character varying(256)
        [Column("name"       , DataType  = DataType.NVarChar , DbType   = "character varying(512)"         , Length       = 512                                   )] public string?   Name        { get; set; } // character varying(512)
        [Column("isactive"   , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool?     Isactive    { get; set; } // boolean
        [Column("createddate", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Createddate { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Admin> _equalityComparer = ComparerBuilder.GetEqualityComparer<Admin>(c => c.Id);

        public bool Equals(Admin? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Admin);
        }
        #endregion
    }
}
