
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_scriptstepsfreeanswerswitcher")]
    public partial class VoiceScriptstepsfreeanswerswitcher : IEquatable<VoiceScriptstepsfreeanswerswitcher>
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id              { get; set; } // uuid
        [Column("stepid"         , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Stepid          { get; set; } // uuid
        [Column("variant"        , DataType = DataType.NVarChar , DbType = "character varying(512)"         , Length       = 512 )] public string?   Variant         { get; set; } // character varying(512)
        [Column("variantnorma"   , DataType = DataType.NVarChar , DbType = "character varying(512)"         , Length       = 512 )] public string?   Variantnorma    { get; set; } // character varying(512)
        [Column("variantweight"  , DataType = DataType.Double   , DbType = "double precision"                                    )] public double?   Variantweight   { get; set; } // double precision
        [Column("varianttarget"  , DataType = DataType.NVarChar , DbType = "character varying(512)"         , Length       = 512 )] public string?   Varianttarget   { get; set; } // character varying(512)
        [Column("version"        , DataType = DataType.Int32    , DbType = "integer"                                             )] public int       Version         { get; set; } // integer
        [Column("createdbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted       { get; set; } // boolean
        [Column("typesource"     , DataType = DataType.NVarChar , DbType = "character varying(8)"           , Length       = 8   )] public string?   Typesource      { get; set; } // character varying(8)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceScriptstepsfreeanswerswitcher> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceScriptstepsfreeanswerswitcher>(c => c.Id);

        public bool Equals(VoiceScriptstepsfreeanswerswitcher? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceScriptstepsfreeanswerswitcher);
        }
        #endregion
    }
}
