
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("attachedfiles")]
    public partial class Attachedfile : IEquatable<Attachedfile>
    {
        [Column("id"              , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                    )] public Guid     Id               { get; set; } // uuid
        [Column("displayname"     , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(4000)", Length = 4000)] public string   Displayname      { get; set; } = null!; // character varying(4000)
        [Column("extension"       , DataType  = DataType.NVarChar , DbType   = "character varying(256)"         , Length       = 256                                     )] public string?  Extension        { get; set; } // character varying(256)
        [Column("size"            , DataType  = DataType.Int32    , DbType   = "integer"                                                                                 )] public int?     Size             { get; set; } // integer
        [Column("attachedtoitemid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid     Attachedtoitemid { get; set; } // uuid
        [Column("blobstorageid"   , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid     Blobstorageid    { get; set; } // uuid
        [Column("createddate"     , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime Createddate      { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"       , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool     Isdeleted        { get; set; } // boolean
        [Column("createdbyuserid" , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid     Createdbyuserid  { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Attachedfile> _equalityComparer = ComparerBuilder.GetEqualityComparer<Attachedfile>(c => c.Id);

        public bool Equals(Attachedfile? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Attachedfile);
        }
        #endregion
    }
}
