
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_abonentdebts")]
    public partial class VoiceAbonentdebt : IEquatable<VoiceAbonentdebt>
    {
        [Column("id"         , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                )] public Guid      Id          { get; set; } // uuid
        [Column("abonentid"  , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                )] public Guid      Abonentid   { get; set; } // uuid
        [Column("value"      , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(50)", Length = 50)] public string    Value       { get; set; } = null!; // character varying(50)
        [Column("startdate"  , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                     )] public DateTime  Startdate   { get; set; } // timestamp (6) without time zone
        [Column("enddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                     )] public DateTime? Enddate     { get; set; } // timestamp (6) without time zone
        [Column("createddate", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                     )] public DateTime  Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                             )] public bool      Isdeleted   { get; set; } // boolean
        [Column("debttype"   , DataType  = DataType.NVarChar , DbType   = "character varying(255)"         , Length       = 255                                 )] public string?   Debttype    { get; set; } // character varying(255)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceAbonentdebt> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceAbonentdebt>(c => c.Id);

        public bool Equals(VoiceAbonentdebt? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceAbonentdebt);
        }
        #endregion
    }
}
