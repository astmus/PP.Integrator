
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("common_settings")]
    public partial class CommonSetting : IEquatable<CommonSetting>
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id              { get; set; } // uuid
        [Column("name"           , DataType = DataType.NVarChar , DbType = "character varying(128)"         , Length       = 128 )] public string?   Name            { get; set; } // character varying(128)
        [Column("title"          , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length       = 256 )] public string?   Title           { get; set; } // character varying(256)
        [Column("description"    , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Description     { get; set; } // character varying(1024)
        [Column("value"          , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length       = 256 )] public string?   Value           { get; set; } // character varying(256)
        [Column("possiblevalues" , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Possiblevalues  { get; set; } // text
        [Column("updatedbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<CommonSetting> _equalityComparer = ComparerBuilder.GetEqualityComparer<CommonSetting>(c => c.Id);

        public bool Equals(CommonSetting? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as CommonSetting);
        }
        #endregion
    }
}
