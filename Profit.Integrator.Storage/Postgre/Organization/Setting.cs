
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("settings")]
    public partial class Setting
    {
        [Column("setting"         , CanBeNull = false             , DataType = DataType.Text                    , DbType = "text")] public string    Setting1       { get; set; } = null!; // text
        [Column("update"          , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                 )] public DateTime? Update         { get; set; } // timestamp (6) without time zone
        [Column("user"            , DataType  = DataType.Text     , DbType   = "text"                                            )] public string?   User           { get; set; } // text
        [Column("state"           , DataType  = DataType.Boolean  , DbType   = "boolean"                                         )] public bool?     State          { get; set; } // boolean
        [Column("tabel_mode_state", DataType  = DataType.Int16    , DbType   = "smallint"                                        )] public short?    TabelModeState { get; set; } // smallint
        [Column("title"           , DataType  = DataType.NVarChar , DbType   = "character varying(100)"         , Length = 100   )] public string?   Title          { get; set; } // character varying(100)
        [Column("description"     , DataType  = DataType.Text     , DbType   = "text"                                            )] public string?   Description    { get; set; } // text
    }
}
