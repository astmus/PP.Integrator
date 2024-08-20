
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("updatedatabaseslogs")]
    public partial class Updatedatabaseslog
    {
        [Column("id"             , DataType  = DataType.Guid     , DbType   = "uuid"                                                         )] public Guid     Id              { get; set; } // uuid
        [Column("entityid"       , DataType  = DataType.Guid     , DbType   = "uuid"                                                         )] public Guid     Entityid        { get; set; } // uuid
        [Column("issuccessful"   , DataType  = DataType.Boolean  , DbType   = "boolean"                                                      )] public bool     Issuccessful    { get; set; } // boolean
        [Column("currentversion" , DataType  = DataType.NVarChar , DbType   = "character varying"                                            )] public string?  Currentversion  { get; set; } // character varying
        [Column("errorscriptname", DataType  = DataType.NVarChar , DbType   = "character varying"                                            )] public string?  Errorscriptname { get; set; } // character varying
        [Column("messagetype"    , CanBeNull = false             , DataType = DataType.NVarChar                , DbType = "character varying")] public string   Messagetype     { get; set; } = null!; // character varying
        [Column("message"        , DataType  = DataType.NVarChar , DbType   = "character varying"                                            )] public string?  Message         { get; set; } // character varying
        [Column("ismanualupdate" , DataType  = DataType.Boolean  , DbType   = "boolean"                                                      )] public bool     Ismanualupdate  { get; set; } // boolean
        [Column("updateorder"    , DataType  = DataType.Int32    , DbType   = "integer"                                                      )] public int?     Updateorder     { get; set; } // integer
        [Column("createdat"      , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                              )] public DateTime Createdat       { get; set; } // timestamp (6) without time zone
    }
}
