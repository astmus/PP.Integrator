
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("servicerates")]
    public partial class Servicerate
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("name", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(512)", Length = 512)] public string Name { get; set; } = null!; // character varying(512)
        [Column("description", DataType = DataType.Text, DbType = "text")] public string? Description { get; set; } // text
        [Column("vendorcode", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Vendorcode { get; set; } // character varying(50)
        [Column("ratetype", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Ratetype { get; set; } // character varying(50)
        [Column("mensure", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string Mensure { get; set; } = null!; // character varying(50)
        [Column("price", DataType = DataType.Double, DbType = "double precision")] public double Price { get; set; } // double precision
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
    }
}
