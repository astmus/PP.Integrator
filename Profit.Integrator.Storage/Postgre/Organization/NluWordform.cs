
using LinqToDB;
using LinqToDB.Mapping;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("nlu_wordforms")]
    public partial class NluWordform
    {
        [Column("form"    , DataType = DataType.NVarChar, DbType = "character varying(80)", Length = 80)] public string? Form     { get; set; } // character varying(80)
        [Column("attr"    , DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Attr     { get; set; } // character varying(50)
        [Column("udarenie", DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Udarenie { get; set; } // character varying(50)
        [Column("id"      , DataType = DataType.NVarChar, DbType = "character varying(50)", Length = 50)] public string? Id       { get; set; } // character varying(50)
        [Column("word"    , DataType = DataType.NChar   , DbType = "character(80)"        , Length = 80)] public string? Word     { get; set; } // character(80)
    }
}
