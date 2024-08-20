
using LinqToDB;
using LinqToDB.Mapping;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("nlu_relations")]
    public partial class NluRelation
    {
        [Column("category", DataType = DataType.NVarChar, DbType = "character varying(50)" , Length = 50 )] public string? Category { get; set; } // character varying(50)
        [Column("phrase"  , DataType = DataType.NVarChar, DbType = "character varying(800)", Length = 800)] public string? Phrase   { get; set; } // character varying(800)
        [Column("slave"   , DataType = DataType.NVarChar, DbType = "character varying(50)" , Length = 50 )] public string? Slave    { get; set; } // character varying(50)
        [Column("master"  , DataType = DataType.NVarChar, DbType = "character varying(50)" , Length = 50 )] public string? Master   { get; set; } // character varying(50)
        [Column("relation", DataType = DataType.NVarChar, DbType = "character varying(50)" , Length = 50 )] public string? Relation { get; set; } // character varying(50)
        [Column("isdel"   , DataType = DataType.Int16   , DbType = "smallint"                            )] public short?  Isdel    { get; set; } // smallint
    }
}
