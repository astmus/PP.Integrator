
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("vi_objectscheme_attribute_values")]
    public partial class ViObjectschemeAttributeValue : IEquatable<ViObjectschemeAttributeValue>
    {
        [Column("id"                     , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                      { get; set; } // uuid
        [Column("objectschemeattributeid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Objectschemeattributeid { get; set; } // uuid
        [Column("position"               , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Position                { get; set; } // integer
        [Column("texttorec"              , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Texttorec               { get; set; } // character varying(1024)
        [Column("texttospeech"           , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Texttospeech            { get; set; } // character varying(1024)
        [Column("texttoanswer"           , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Texttoanswer            { get; set; } // character varying(1024)
        [Column("textnorma"              , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Textnorma               { get; set; } // character varying(1024)
        [Column("createdbyuserid"        , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Createdbyuserid         { get; set; } // uuid
        [Column("createddate"            , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate             { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid"        , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid         { get; set; } // uuid
        [Column("updateddate"            , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate             { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"              , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted               { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ViObjectschemeAttributeValue> _equalityComparer = ComparerBuilder.GetEqualityComparer<ViObjectschemeAttributeValue>(c => c.Id);

        public bool Equals(ViObjectschemeAttributeValue? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ViObjectschemeAttributeValue);
        }
        #endregion
    }
}
