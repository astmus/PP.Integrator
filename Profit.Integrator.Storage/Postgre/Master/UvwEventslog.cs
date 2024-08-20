
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("uvw_eventslog", IsView = true)]
    public partial class UvwEventslog
    {
        [Column("id"             , DataType = DataType.Guid     , DbType = "uuid"                           , SkipOnInsert = true, SkipOnUpdate = true                     )] public Guid?     Id              { get; set; } // uuid
        [Column("entityid"       , DataType = DataType.Guid     , DbType = "uuid"                           , SkipOnInsert = true, SkipOnUpdate = true                     )] public Guid?     Entityid        { get; set; } // uuid
        [Column("pitserverid"    , DataType = DataType.Guid     , DbType = "uuid"                           , SkipOnInsert = true, SkipOnUpdate = true                     )] public Guid?     Pitserverid     { get; set; } // uuid
        [Column("eventtype"      , DataType = DataType.Int32    , DbType = "integer"                        , SkipOnInsert = true, SkipOnUpdate = true                     )] public int?      Eventtype       { get; set; } // integer
        [Column("eventsubtype"   , DataType = DataType.Int32    , DbType = "integer"                        , SkipOnInsert = true, SkipOnUpdate = true                     )] public int?      Eventsubtype    { get; set; } // integer
        [Column("eventproperties", DataType = DataType.Text     , DbType = "text"                           , SkipOnInsert = true, SkipOnUpdate = true                     )] public string?   Eventproperties { get; set; } // text
        [Column("createddate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone", SkipOnInsert = true, SkipOnUpdate = true                     )] public DateTime? Createddate     { get; set; } // timestamp (6) without time zone
        [Column("comments"       , DataType = DataType.Text     , DbType = "text"                           , SkipOnInsert = true, SkipOnUpdate = true                     )] public string?   Comments        { get; set; } // text
        [Column("servername"     , DataType = DataType.NVarChar , DbType = "character varying(512)"         , Length       = 512 , SkipOnInsert = true, SkipOnUpdate = true)] public string?   Servername      { get; set; } // character varying(512)
        [Column("entityname"     , DataType = DataType.NVarChar , DbType = "character varying(512)"         , Length       = 512 , SkipOnInsert = true, SkipOnUpdate = true)] public string?   Entityname      { get; set; } // character varying(512)
    }
}
