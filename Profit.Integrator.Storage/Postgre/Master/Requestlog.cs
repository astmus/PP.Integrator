
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("requestlog")]
    public partial class Requestlog : IEquatable<Requestlog>
    {
        [Column("id"         , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id          { get; set; } // uuid
        [Column("ipsender"   , DataType = DataType.NVarChar , DbType = "character varying(30)"          , Length       = 30  )] public string?  Ipsender    { get; set; } // character varying(30)
        [Column("dnssender"  , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length       = 256 )] public string?  Dnssender   { get; set; } // character varying(256)
        [Column("pitaddress" , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?  Pitaddress  { get; set; } // character varying(1024)
        [Column("requestbody", DataType = DataType.Text     , DbType = "text"                                                )] public string?  Requestbody { get; set; } // text
        [Column("isallowed"  , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?    Isallowed   { get; set; } // boolean
        [Column("isrejected" , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?    Isrejected  { get; set; } // boolean
        [Column("comments"   , DataType = DataType.Text     , DbType = "text"                                                )] public string?  Comments    { get; set; } // text
        [Column("createdate" , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Createdate  { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Isdeleted   { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Requestlog> _equalityComparer = ComparerBuilder.GetEqualityComparer<Requestlog>(c => c.Id);

        public bool Equals(Requestlog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Requestlog);
        }
        #endregion
    }
}
