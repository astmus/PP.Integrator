
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Master
{
    [Table("products")]
    public partial class Product
    {
        [Column("id", DataType = DataType.Guid, DbType = "uuid")] public Guid Id { get; set; } // uuid
        [Column("productname", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(255)", Length = 255)] public string Productname { get; set; } = null!; // character varying(255)
        [Column("vendorcode", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Vendorcode { get; set; } // character varying(50)
        [Column("rate", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Rate { get; set; } // character varying(50)
        [Column("mensure", CanBeNull = false, DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string Mensure { get; set; } = null!; // character varying(50)
        [Column("price", DataType = DataType.Double, DbType = "double precision")] public double Price { get; set; } // double precision
        [Column("isdeleted", DataType = DataType.Boolean, DbType = "boolean")] public bool Isdeleted { get; set; } // boolean
    }
}
