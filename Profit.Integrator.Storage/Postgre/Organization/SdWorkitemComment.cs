
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sd_workitem_comments")]
    public partial class SdWorkitemComment : IEquatable<SdWorkitemComment>
    {
        [Column("id"             , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                    )] public Guid     Id              { get; set; } // uuid
        [Column("comment"        , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(4000)", Length = 4000)] public string   Comment         { get; set; } = null!; // character varying(4000)
        [Column("typeid"         , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?    Typeid          { get; set; } // uuid
        [Column("commenttypeid"  , DataType  = DataType.Int32    , DbType   = "integer"                                                                                 )] public int      Commenttypeid   { get; set; } // integer
        [Column("isprivate"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?    Isprivate       { get; set; } // boolean
        [Column("workitemid"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid     Workitemid      { get; set; } // uuid
        [Column("createddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime Createddate     { get; set; } // timestamp (6) without time zone
        [Column("createdbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid     Createdbyuserid { get; set; } // uuid
        [Column("isdeleted"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool     Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdWorkitemComment> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdWorkitemComment>(c => c.Id);

        public bool Equals(SdWorkitemComment? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdWorkitemComment);
        }
        #endregion
    }
}
