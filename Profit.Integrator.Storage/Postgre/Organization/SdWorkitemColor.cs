
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("sd_workitem_colors")]
    public partial class SdWorkitemColor : IEquatable<SdWorkitemColor>
    {
        [Column("id"         , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id          { get; set; } // uuid
        [Column("title"      , DataType = DataType.NVarChar , DbType = "character varying(256)"         , Length       = 256 )] public string?  Title       { get; set; } // character varying(256)
        [Column("conditions" , DataType = DataType.Text     , DbType = "text"                                                )] public string?  Conditions  { get; set; } // text
        [Column("priority"   , DataType = DataType.Double   , DbType = "double precision"                                    )] public double   Priority    { get; set; } // double precision
        [Column("wicolor"    , DataType = DataType.NVarChar , DbType = "character varying(16)"          , Length       = 16  )] public string?  Wicolor     { get; set; } // character varying(16)
        [Column("createddate", DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Createddate { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"  , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Isdeleted   { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<SdWorkitemColor> _equalityComparer = ComparerBuilder.GetEqualityComparer<SdWorkitemColor>(c => c.Id);

        public bool Equals(SdWorkitemColor? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as SdWorkitemColor);
        }
        #endregion
    }
}
