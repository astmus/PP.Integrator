
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("updatedatabasescripts")]
    public partial class Updatedatabasescript
    {
        [Column("id"              , DataType  = DataType.Guid     , DbType   = "uuid"                                                         )] public Guid     Id               { get; set; } // uuid
        [Column("scriptname"      , CanBeNull = false             , DataType = DataType.NVarChar                , DbType = "character varying")] public string   Scriptname       { get; set; } = null!; // character varying
        [Column("isexecutable"    , DataType  = DataType.Boolean  , DbType   = "boolean"                                                      )] public bool     Isexecutable     { get; set; } // boolean
        [Column("isexecutesuccess", DataType  = DataType.Boolean  , DbType   = "boolean"                                                      )] public bool     Isexecutesuccess { get; set; } // boolean
        [Column("createdat"       , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                              )] public DateTime Createdat        { get; set; } // timestamp (6) without time zone
    }
}
