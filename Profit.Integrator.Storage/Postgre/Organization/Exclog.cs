
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("exclog")]
    public partial class Exclog : IEquatable<Exclog>
    {
        [Column("id"         , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                  )] public Guid     Id          { get; set; } // uuid
        [Column("msg"        , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(255)", Length = 255)] public string   Msg         { get; set; } = null!; // character varying(255)
        [Column("pc"         , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(128)", Length = 128)] public string   Pc          { get; set; } = null!; // character varying(128)
        [Column("dt"         , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                       )] public DateTime Dt          { get; set; } // timestamp (6) without time zone
        [Column("iscenterreg", DataType  = DataType.Boolean  , DbType   = "boolean"                                                                               )] public bool     Iscenterreg { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Exclog> _equalityComparer = ComparerBuilder.GetEqualityComparer<Exclog>(c => c.Id);

        public bool Equals(Exclog? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Exclog);
        }
        #endregion
    }
}
