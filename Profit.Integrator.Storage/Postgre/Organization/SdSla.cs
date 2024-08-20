
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sd_sla")]
    public partial class SdSla : IEquatable<SdSla>
    {
        [Column("id"                  , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                    )] public Guid      Id                   { get; set; } // uuid
        [Column("name"                , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1024)", Length = 1024)] public string    Name                 { get; set; } = null!; // character varying(1024)
        [Column("fromdate"            , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Fromdate             { get; set; } // timestamp (6) without time zone
        [Column("todate"              , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Todate               { get; set; } // timestamp (6) without time zone
        [Column("affecteddepartmentid", DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Affecteddepartmentid { get; set; } // uuid
        [Column("calendarid"          , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid      Calendarid           { get; set; } // uuid
        [Column("createdbyuserid"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid      Createdbyuserid      { get; set; } // uuid
        [Column("createddate"         , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime  Createddate          { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid?     Updatedbyuserid      { get; set; } // uuid
        [Column("updateddate"         , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Updateddate          { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"           , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool      Isdeleted            { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdSla> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdSla>(c => c.Id);

        public bool Equals(SdSla? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdSla);
        }
        #endregion
    }
}
