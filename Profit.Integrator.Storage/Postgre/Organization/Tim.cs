
using LinqToDB;
using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("tim")]
    public partial class Tim
    {
        [Column("pk_Дата"         , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                             )] public DateTime? PkДата         { get; set; } // timestamp (6) without time zone
        [Column("Дата_Имя"        , DataType  = DataType.NVarChar , DbType   = "character varying(102)"         , Length = 102                               )] public string?   ДатаИмя        { get; set; } // character varying(102)
        [Column("Год"             , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                             )] public DateTime? Год            { get; set; } // timestamp (6) without time zone
        [Column("Год_Имя"         , DataType  = DataType.NVarChar , DbType   = "character varying(40)"          , Length = 40                                )] public string?   ГодИмя         { get; set; } // character varying(40)
        [Column("Квартал"         , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                             )] public DateTime? Квартал        { get; set; } // timestamp (6) without time zone
        [Column("Квартал_Имя"     , DataType  = DataType.NVarChar , DbType   = "character varying(70)"          , Length = 70                                )] public string?   КварталИмя     { get; set; } // character varying(70)
        [Column("Месяц"           , DataType  = DataType.Date     , DbType   = "date"                                                                        )] public DateTime? Месяц          { get; set; } // date
        [Column("Месяц_Имя"       , DataType  = DataType.NVarChar , DbType   = "character varying(61)"          , Length = 61                                )] public string?   МесяцИмя       { get; set; } // character varying(61)
        [Column("Неделя"          , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                             )] public DateTime? Неделя         { get; set; } // timestamp (6) without time zone
        [Column("Неделя_Имя"      , DataType  = DataType.NVarChar , DbType   = "character varying(30)"          , Length = 30                                )] public string?   НеделяИмя      { get; set; } // character varying(30)
        [Column("День_Года"       , DataType  = DataType.Int32    , DbType   = "integer"                                                                     )] public int?      ДеньГода       { get; set; } // integer
        [Column("День_Квартала"   , DataType  = DataType.Int32    , DbType   = "integer"                                                                     )] public int?      ДеньКвартала   { get; set; } // integer
        [Column("День_Месяца"     , DataType  = DataType.Int32    , DbType   = "integer"                                                                     )] public int?      ДеньМесяца     { get; set; } // integer
        [Column("День_Недели"     , DataType  = DataType.Int32    , DbType   = "integer"                                                                     )] public int?      ДеньНедели     { get; set; } // integer
        [Column("День_Недели_Имя" , DataType  = DataType.NVarChar , DbType   = "character varying(30)"          , Length = 30                                )] public string?   ДеньНеделиИмя  { get; set; } // character varying(30)
        [Column("Неделя_Года"     , DataType  = DataType.Int32    , DbType   = "integer"                                                                     )] public int?      НеделяГода     { get; set; } // integer
        [Column("Месяц_Года"      , DataType  = DataType.Int32    , DbType   = "integer"                                                                     )] public int?      МесяцГода      { get; set; } // integer
        [Column("Месяц_Года_Имя"  , CanBeNull = false             , DataType = DataType.NVarChar                , DbType = "character varying(8)", Length = 8)] public string    МесяцГодаИмя   { get; set; } = null!; // character varying(8)
        [Column("Месяц_Квартала"  , DataType  = DataType.Int32    , DbType   = "integer"                                                                     )] public int?      МесяцКвартала  { get; set; } // integer
        [Column("Квартал_Года"    , DataType  = DataType.Int32    , DbType   = "integer"                                                                     )] public int?      КварталГода    { get; set; } // integer
        [Column("Квартал_Года_Имя", DataType  = DataType.NVarChar , DbType   = "character varying(38)"          , Length = 38                                )] public string?   КварталГодаИмя { get; set; } // character varying(38)
        [Column("Час_Дня"         , DataType  = DataType.Int32    , DbType   = "integer"                                                                     )] public int?      ЧасДня         { get; set; } // integer
        [Column("Час"             , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                             )] public DateTime? Час            { get; set; } // timestamp (6) without time zone
        [Column("Минуты_Часа"     , DataType  = DataType.Int32    , DbType   = "integer"                                                                     )] public int?      МинутыЧаса     { get; set; } // integer
        [Column("Минуты"          , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                             )] public DateTime? Минуты         { get; set; } // timestamp (6) without time zone
    }
}
