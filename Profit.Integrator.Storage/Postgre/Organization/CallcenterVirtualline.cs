
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("callcenter_virtuallines")]
    public partial class CallcenterVirtualline : IEquatable<CallcenterVirtualline>
    {
        [Column("id"                     , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid      Id                      { get; set; } // uuid
        [Column("name"                   , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string    Name                    { get; set; } = null!; // character varying(255)
        [Column("ivrmenuid"              , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Ivrmenuid               { get; set; } // uuid
        [Column("scriptid"               , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Scriptid                { get; set; } // uuid
        [Column("createddate"            , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime  Createddate             { get; set; } // timestamp (6) without time zone
        [Column("updateddate"            , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime? Updateddate             { get; set; } // timestamp (6) without time zone
        [Column("createdbyuserid"        , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid      Createdbyuserid         { get; set; } // uuid
        [Column("updatedbyuserid"        , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                  )] public Guid?     Updatedbyuserid         { get; set; } // uuid
        [Column("isdeleted"              , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool      Isdeleted               { get; set; } // boolean
        [Column("outgoingcallphoneprefix", DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length       = 50                                    )] public string?   Outgoingcallphoneprefix { get; set; } // character varying(50)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<CallcenterVirtualline> _equalityComparer = ComparerBuilder.GetEqualityComparer<CallcenterVirtualline>(c => c.Id);

        public bool Equals(CallcenterVirtualline? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as CallcenterVirtualline);
        }
        #endregion
    }
}
