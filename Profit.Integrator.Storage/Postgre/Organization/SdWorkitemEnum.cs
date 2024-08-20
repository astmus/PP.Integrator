
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sd_workitem_enums")]
    public partial class SdWorkitemEnum : IEquatable<SdWorkitemEnum>
    {
        [Column("id"             , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id              { get; set; } // uuid
        [Column("name"           , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(512)", Length = 512)] public string    Name            { get; set; } = null!; // character varying(512)
        [Column("position"       , DataType  = DataType.Int32    , DbType   = "integer"                                                                               )] public int?      Position        { get; set; } // integer
        [Column("enumtypeid"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid      Enumtypeid      { get; set; } // uuid
        [Column("parentid"       , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Parentid        { get; set; } // uuid
        [Column("source"         , DataType  = DataType.NVarChar , DbType   = "character varying(8)"           , Length       = 8                                     )] public string?   Source          { get; set; } // character varying(8)
        [Column("issystem"       , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool?     Issystem        { get; set; } // boolean
        [Column("externalid"     , DataType  = DataType.NVarChar , DbType   = "character varying(64)"          , Length       = 64                                    )] public string?   Externalid      { get; set; } // character varying(64)
        [Column("createdbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool?     Isdeleted       { get; set; } // boolean
        [Column("lastsourceid"   , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Lastsourceid    { get; set; } // uuid

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdWorkitemEnum> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdWorkitemEnum>(c => c.Id);

        public bool Equals(SdWorkitemEnum? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdWorkitemEnum);
        }
        #endregion
    }
}
