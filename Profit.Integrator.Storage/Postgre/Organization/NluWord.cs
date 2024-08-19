
using LinqToDB;
using LinqToDB.Mapping;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage.Postgre.Organization
{
    [Table("nlu_words")]
    public partial class NluWord
    {
        [Column("word", DataType = DataType.NChar, DbType = "character(30)", Length = 30)] public string? Word { get; set; } // character(30)
        [Column("part", DataType = DataType.NChar, DbType = "character(6)", Length = 6)] public string? Part { get; set; } // character(6)
    }
}
