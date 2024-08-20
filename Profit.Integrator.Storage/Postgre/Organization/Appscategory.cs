
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("appscategory")]
    public partial class Appscategory
    {
        [Column("id"  , DataType  = DataType.Guid, DbType   = "uuid"                                                            )] public Guid   Id   { get; set; } // uuid
        [Column("name", CanBeNull = false        , DataType = DataType.NVarChar, DbType = "character varying(100)", Length = 100)] public string Name { get; set; } = null!; // character varying(100)
    }
}
