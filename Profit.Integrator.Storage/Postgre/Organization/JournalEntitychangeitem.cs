
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("journal_entitychangeitems")]
    public partial class JournalEntitychangeitem
    {
        [Column("id"        , DataType = DataType.Guid    , DbType = "uuid"                                )] public Guid    Id         { get; set; } // uuid
        [Column("changesid" , DataType = DataType.Guid    , DbType = "uuid"                                )] public Guid    Changesid  { get; set; } // uuid
        [Column("columnname", DataType = DataType.NVarChar, DbType = "character varying(128)", Length = 128)] public string? Columnname { get; set; } // character varying(128)
        [Column("prevalue"  , DataType = DataType.Text    , DbType = "text"                                )] public string? Prevalue   { get; set; } // text
        [Column("postvalue" , DataType = DataType.Text    , DbType = "text"                                )] public string? Postvalue  { get; set; } // text
        [Column("isdeleted" , DataType = DataType.Boolean , DbType = "boolean"                             )] public bool    Isdeleted  { get; set; } // boolean
    }
}
