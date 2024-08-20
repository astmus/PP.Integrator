
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("callcenterrecall")]
    public partial class Callcenterrecall
    {
        [Column("id"        , DataType  = DataType.Guid     , DbType   = "uuid"                                                                          )] public Guid      Id         { get; set; } // uuid
        [Column("callphone" , CanBeNull = false             , DataType = DataType.NVarChar                , DbType = "character varying(50)", Length = 50)] public string    Callphone  { get; set; } = null!; // character varying(50)
        [Column("caller"    , DataType  = DataType.Guid     , DbType   = "uuid"                                                                          )] public Guid?     Caller     { get; set; } // uuid
        [Column("incomeline", DataType  = DataType.Guid     , DbType   = "uuid"                                                                          )] public Guid      Incomeline { get; set; } // uuid
        [Column("calltime"  , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                               )] public DateTime  Calltime   { get; set; } // timestamp (6) without time zone
        [Column("operator"  , DataType  = DataType.Guid     , DbType   = "uuid"                                                                          )] public Guid?     Operator   { get; set; } // uuid
        [Column("recalldate", DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                               )] public DateTime? Recalldate { get; set; } // timestamp (6) without time zone
        [Column("isrecalled", DataType  = DataType.Boolean  , DbType   = "boolean"                                                                       )] public bool      Isrecalled { get; set; } // boolean
        [Column("ismissed"  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                       )] public bool      Ismissed   { get; set; } // boolean
        [Column("callid"    , DataType  = DataType.Guid     , DbType   = "uuid"                                                                          )] public Guid?     Callid     { get; set; } // uuid
    }
}
