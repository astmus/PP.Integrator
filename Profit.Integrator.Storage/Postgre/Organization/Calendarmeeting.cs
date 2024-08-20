
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("calendarmeeting")]
    public partial class Calendarmeeting
    {
        [Column("id"                , DataType  = DataType.Guid     , DbType   = "uuid"                                                                            )] public Guid     Id                 { get; set; } // uuid
        [Column("user"              , CanBeNull = false             , DataType = DataType.NVarChar                , DbType = "character varying(250)", Length = 250)] public string   User               { get; set; } = null!; // character varying(250)
        [Column("subject"           , DataType  = DataType.Text     , DbType   = "text"                                                                            )] public string?  Subject            { get; set; } // text
        [Column("datestart"         , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                 )] public DateTime Datestart          { get; set; } // timestamp (6) without time zone
        [Column("dateend"           , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                 )] public DateTime Dateend            { get; set; } // timestamp (6) without time zone
        [Column("listofparticipants", DataType  = DataType.NVarChar , DbType   = "character varying(1000)"        , Length = 1000                                  )] public string?  Listofparticipants { get; set; } // character varying(1000)
    }
}
