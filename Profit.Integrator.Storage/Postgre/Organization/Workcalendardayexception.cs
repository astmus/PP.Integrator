
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("workcalendardayexceptions")]
    public partial class Workcalendardayexception : IEquatable<Workcalendardayexception>
    {
        [Column("id"            , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id             { get; set; } // uuid
        [Column("workcalendarid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Workcalendarid { get; set; } // uuid
        [Column("exdate"        , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Exdate         { get; set; } // timestamp (6) without time zone
        [Column("is24"          , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Is24           { get; set; } // boolean
        [Column("isholiday"     , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Isholiday      { get; set; } // boolean
        [Column("starttime"     , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Starttime      { get; set; } // timestamp (6) without time zone
        [Column("endtime"       , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Endtime        { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"     , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted      { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Workcalendardayexception> _equalityComparer = ComparerBuilder.GetEqualityComparer<Workcalendardayexception>(c => c.Id);

        public bool Equals(Workcalendardayexception? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Workcalendardayexception);
        }
        #endregion
    }
}
