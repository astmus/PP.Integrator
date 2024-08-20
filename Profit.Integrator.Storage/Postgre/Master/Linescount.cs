
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("linescount")]
    public partial class Linescount : IEquatable<Linescount>
    {
        [Column("id"                 , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                  { get; set; } // uuid
        [Column("entityid"           , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Entityid            { get; set; } // uuid
        [Column("repeattype"         , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Repeattype          { get; set; } // integer
        [Column("startdate"          , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Startdate           { get; set; } // timestamp (6) without time zone
        [Column("enddate"            , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Enddate             { get; set; } // timestamp (6) without time zone
        [Column("externallinesnumber", DataType = DataType.Int32    , DbType = "integer"                                             )] public int       Externallinesnumber { get; set; } // integer
        [Column("virtuallineid"      , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Virtuallineid       { get; set; } // uuid
        [Column("createdate"         , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Createdate          { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"          , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Isdeleted           { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Linescount> _equalityComparer = ComparerBuilder.GetEqualityComparer<Linescount>(c => c.Id);

        public bool Equals(Linescount? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Linescount);
        }
        #endregion
    }
}
