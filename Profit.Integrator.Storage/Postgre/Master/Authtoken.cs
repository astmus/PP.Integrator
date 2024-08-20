
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("authtokens")]
    public partial class Authtoken : IEquatable<Authtoken>
    {
        [Column("id"         , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                )] public Guid     Id          { get; set; } // uuid
        [Column("authtoken"  , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(50)", Length = 50)] public string   Authtoken1  { get; set; } = null!; // character varying(50)
        [Column("expireson"  , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                     )] public DateTime Expireson   { get; set; } // timestamp (6) without time zone
        [Column("entityid"   , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                )] public Guid     Entityid    { get; set; } // uuid
        [Column("userid"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                )] public Guid?    Userid      { get; set; } // uuid
        [Column("createddate", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                     )] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                             )] public bool     Isdeleted   { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Authtoken> _equalityComparer = ComparerBuilder.GetEqualityComparer<Authtoken>(c => c.Id);

        public bool Equals(Authtoken? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Authtoken);
        }
        #endregion
    }
}
