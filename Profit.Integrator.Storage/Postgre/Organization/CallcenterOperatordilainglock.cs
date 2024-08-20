
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("callcenter_operatordilainglocks")]
    public partial class CallcenterOperatordilainglock
    {
        [Column("id"                , DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid      Id                 { get; set; } // uuid
        [Column("operatorid"        , DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid      Operatorid         { get; set; } // uuid
        [Column("contextid"         , DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid?     Contextid          { get; set; } // uuid
        [Column("externalresourceid", DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid?     Externalresourceid { get; set; } // uuid
        [Column("locktime"          , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Locktime           { get; set; } // timestamp (6) without time zone
    }
}
