
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("queue")]
    public partial class Queue : IEquatable<Queue>
    {
        [Column("rid"      , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid     Rid       { get; set; } // uuid
        [Column("id"       , DataType  = DataType.Int64    , DbType   = "bigint"                                                                                )] public long     Id        { get; set; } // bigint
        [Column("incident" , DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length       = 50                                    )] public string?  Incident  { get; set; } // character varying(50)
        [Column("subject"  , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(160)", Length = 160)] public string   Subject   { get; set; } = null!; // character varying(160)
        [Column("message"  , CanBeNull = false             , DataType = DataType.Text                    , DbType       = "text"                                )] public string   Message   { get; set; } = null!; // text
        [Column("user"     , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(50)" , Length = 50 )] public string   User      { get; set; } = null!; // character varying(50)
        [Column("dt"       , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime Dt        { get; set; } // timestamp (6) without time zone
        [Column("sending"  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool     Sending   { get; set; } // boolean
        [Column("newwindow", DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool     Newwindow { get; set; } // boolean
        [Column("action"   , DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length       = 50                                    )] public string?  Action    { get; set; } // character varying(50)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Queue> _equalityComparer = ComparerBuilder.GetEqualityComparer<Queue>(c => c.Rid);

        public bool Equals(Queue? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Queue);
        }
        #endregion
    }
}
