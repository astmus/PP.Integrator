
using LinqToDB;
using LinqToDB.Mapping;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("nlu_stopwords")]
    public partial class NluStopword
    {
        [Column("slave"   , DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Slave    { get; set; } // character varying(50)
        [Column("master"  , DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Master   { get; set; } // character varying(50)
        [Column("relation", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Relation { get; set; } // character varying(50)
        [Column("weight"  , DataType = DataType.Double  , DbType = "double precision"                  )] public double? Weight   { get; set; } // double precision
    }
}
