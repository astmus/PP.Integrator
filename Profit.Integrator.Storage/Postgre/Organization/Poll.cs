
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("poll")]
    public partial class Poll
    {
        [Column("id"     , DataType  = DataType.Guid     , DbType   = "uuid"                                            )] public Guid     Id      { get; set; } // uuid
        [Column("session", DataType  = DataType.Guid     , DbType   = "uuid"                                            )] public Guid     Session { get; set; } // uuid
        [Column("dt"     , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                 )] public DateTime Dt      { get; set; } // timestamp (6) without time zone
        [Column("q"      , CanBeNull = false             , DataType = DataType.Text                    , DbType = "text")] public string   Q       { get; set; } = null!; // text
        [Column("a"      , CanBeNull = false             , DataType = DataType.Text                    , DbType = "text")] public string   A       { get; set; } = null!; // text
    }
}
