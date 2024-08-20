
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("iamtokens")]
    public partial class Iamtoken : IEquatable<Iamtoken>
    {
        [Column("id"         , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                )] public Guid     Id          { get; set; } // uuid
        [Column("iamtoken"   , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(50)", Length = 50)] public string   Iamtoken1   { get; set; } = null!; // character varying(50)
        [Column("expireson"  , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                     )] public DateTime Expireson   { get; set; } // timestamp (6) without time zone
        [Column("authtokenid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                )] public Guid?    Authtokenid { get; set; } // uuid
        [Column("createddate", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                     )] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                             )] public bool     Isdeleted   { get; set; } // boolean
        [Column("tokentype"  , DataType  = DataType.Int32    , DbType   = "integer"                                                                             )] public int      Tokentype   { get; set; } // integer
        [Column("objectid"   , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                )] public Guid?    Objectid    { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Iamtoken> _equalityComparer = ComparerBuilder.GetEqualityComparer<Iamtoken>(c => c.Id);

        public bool Equals(Iamtoken? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Iamtoken);
        }
        #endregion
    }
}
