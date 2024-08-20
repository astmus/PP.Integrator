
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_products")]
    public partial class VoiceProduct : IEquatable<VoiceProduct>
    {
        [Column("id"               , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                { get; set; } // uuid
        [Column("title"            , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Title             { get; set; } // character varying(255)
        [Column("originaltitle"    , DataType = DataType.NVarChar , DbType = "character varying(255)"         , Length       = 255 )] public string?   Originaltitle     { get; set; } // character varying(255)
        [Column("isstrongalcohol"  , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Isstrongalcohol   { get; set; } // boolean
        [Column("ismercury"        , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Ismercury         { get; set; } // boolean
        [Column("productcategoryid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Productcategoryid { get; set; } // uuid
        [Column("createddate"      , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Createddate       { get; set; } // timestamp (6) without time zone
        [Column("updateddate"      , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate       { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"        , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Isdeleted         { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceProduct> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceProduct>(c => c.Id);

        public bool Equals(VoiceProduct? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceProduct);
        }
        #endregion
    }
}
