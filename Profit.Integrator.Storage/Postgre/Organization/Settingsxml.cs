
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("settingsxml")]
    public partial class Settingsxml
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid      Id              { get; set; } // uuid
        [Column("xmltext"        , DataType = DataType.Text     , DbType = "text"                           )] public string?   Xmltext         { get; set; } // text
        [Column("createdbyuserid", DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid      Createdbyuserid { get; set; } // uuid
        [Column("createddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime  Createddate     { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid", DataType = DataType.Guid     , DbType = "uuid"                           )] public Guid?     Updatedbyuserid { get; set; } // uuid
        [Column("updateddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone")] public DateTime? Updateddate     { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"      , DataType = DataType.Boolean  , DbType = "boolean"                        )] public bool?     Isdeleted       { get; set; } // boolean
    }
}
