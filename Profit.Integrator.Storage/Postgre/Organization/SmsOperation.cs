
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sms_operations")]
    public partial class SmsOperation : IEquatable<SmsOperation>
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id              { get; set; } // uuid
        [Column("originalid"     , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Originalid      { get; set; } // uuid
        [Column("connectorid"    , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Connectorid     { get; set; } // uuid
        [Column("operationtype"  , DataType = DataType.NVarChar , DbType = "character varying(16)"          , Length       = 16  )] public string?   Operationtype   { get; set; } // character varying(16)
        [Column("text"           , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Text            { get; set; } // character varying(1024)
        [Column("phone"          , DataType = DataType.NVarChar , DbType = "character varying(16)"          , Length       = 16  )] public string?   Phone           { get; set; } // character varying(16)
        [Column("plandate"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Plandate        { get; set; } // timestamp (6) without time zone
        [Column("requesttext"    , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Requesttext     { get; set; } // text
        [Column("responsetext"   , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Responsetext    { get; set; } // text
        [Column("errortext"      , DataType = DataType.NVarChar , DbType = "character varying(2048)"        , Length       = 2048)] public string?   Errortext       { get; set; } // character varying(2048)
        [Column("issuccess"      , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Issuccess       { get; set; } // boolean
        [Column("createdbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted       { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SmsOperation> _equalityComparer = ComparerBuilder.GetEqualityComparer<SmsOperation>(c => c.Id);

        public bool Equals(SmsOperation? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SmsOperation);
        }
        #endregion
    }
}
