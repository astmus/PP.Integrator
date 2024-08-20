
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("vi_objectscheme_attributes")]
    public partial class ViObjectschemeAttribute : IEquatable<ViObjectschemeAttribute>
    {
        [Column("id"                , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                 { get; set; } // uuid
        [Column("objectschemeid"    , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Objectschemeid     { get; set; } // uuid
        [Column("position"          , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Position           { get; set; } // integer
        [Column("name"              , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Name               { get; set; } // character varying(1024)
        [Column("description"       , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Description        { get; set; } // character varying(1024)
        [Column("type"              , DataType = DataType.NVarChar , DbType = "character varying(32)"          , Length       = 32  )] public string?   Type               { get; set; } // character varying(32)
        [Column("referencetypeid"   , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Referencetypeid    { get; set; } // uuid
        [Column("objectschemetypeid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Objectschemetypeid { get; set; } // uuid
        [Column("isrequired"        , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Isrequired         { get; set; } // boolean
        [Column("question"          , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Question           { get; set; } // character varying(1024)
        [Column("settings"          , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Settings           { get; set; } // text
        [Column("createdbyuserid"   , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Createdbyuserid    { get; set; } // uuid
        [Column("createddate"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate        { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid"   , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid    { get; set; } // uuid
        [Column("updateddate"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate        { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"         , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted          { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViObjectschemeAttribute> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViObjectschemeAttribute>(c => c.Id);

        public bool Equals(ViObjectschemeAttribute? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViObjectschemeAttribute);
        }
        #endregion
    }
}
