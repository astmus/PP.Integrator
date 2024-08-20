
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sd_workitem_conditionsforsendingsms")]
    public partial class SdWorkitemConditionsforsendingsm : IEquatable<SdWorkitemConditionsforsendingsm>
    {
        [Column("id"             , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id              { get; set; } // uuid
        [Column("conditiontype"  , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(100)", Length = 100)] public string    Conditiontype   { get; set; } = null!; // character varying(100)
        [Column("value"          , DataType  = DataType.NVarChar , DbType   = "character varying(100)"         , Length       = 100                                   )] public string?   Value           { get; set; } // character varying(100)
        [Column("smsbodytemplate", DataType  = DataType.NVarChar , DbType   = "character varying(2000)"        , Length       = 2000                                  )] public string?   Smsbodytemplate { get; set; } // character varying(2000)
        [Column("createdbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdWorkitemConditionsforsendingsm> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdWorkitemConditionsforsendingsm>(c => c.Id);

        public bool Equals(SdWorkitemConditionsforsendingsm? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdWorkitemConditionsforsendingsm);
        }
        #endregion
    }
}
