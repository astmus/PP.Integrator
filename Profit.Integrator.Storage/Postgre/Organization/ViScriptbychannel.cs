
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("vi_scriptbychannel")]
    public partial class ViScriptbychannel : IEquatable<ViScriptbychannel>
    {
        [Column("id"                    , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                     { get; set; } // uuid
        [Column("channelid"             , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Channelid              { get; set; } // uuid
        [Column("accountid"             , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Accountid              { get; set; } // uuid
        [Column("scriptid"              , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Scriptid               { get; set; } // uuid
        [Column("href"                  , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Href                   { get; set; } // character varying(1024)
        [Column("settings"              , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Settings               { get; set; } // text
        [Column("createdbyuserid"       , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Createdbyuserid        { get; set; } // uuid
        [Column("createddate"           , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate            { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid"       , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid        { get; set; } // uuid
        [Column("updateddate"           , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate            { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"             , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted              { get; set; } // boolean
        [Column("isscriptresultrequired", DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isscriptresultrequired { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViScriptbychannel> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViScriptbychannel>(c => c.Id);

        public bool Equals(ViScriptbychannel? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViScriptbychannel);
        }
        #endregion
    }
}
