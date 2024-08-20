
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("bills")]
    public partial class Bill
    {
        [Column("id"                 , DataType  = DataType.Guid     , DbType   = "uuid"                                                                            )] public Guid      Id                  { get; set; } // uuid
        [Column("title"              , CanBeNull = false             , DataType = DataType.NVarChar                , DbType = "character varying(255)", Length = 255)] public string    Title               { get; set; } = null!; // character varying(255)
        [Column("accountnumber"      , CanBeNull = false             , DataType = DataType.NVarChar                , DbType = "character varying(50)" , Length = 50 )] public string    Accountnumber       { get; set; } = null!; // character varying(50)
        [Column("file"               , CanBeNull = false             , DataType = DataType.Binary                  , DbType = "bytea"                               )] public byte[]    File                { get; set; } = null!; // bytea
        [Column("generatedate"       , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                 )] public DateTime  Generatedate        { get; set; } // timestamp (6) without time zone
        [Column("tarifficationscheme", DataType  = DataType.NVarChar , DbType   = "character varying(50)"          , Length = 50                                    )] public string?   Tarifficationscheme { get; set; } // character varying(50)
        [Column("createddate"        , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                 )] public DateTime? Createddate         { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"          , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                         )] public bool?     Isdeleted           { get; set; } // boolean
    }
}
