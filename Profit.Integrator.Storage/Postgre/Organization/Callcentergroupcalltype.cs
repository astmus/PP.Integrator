
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("callcentergroupcalltypes")]
    public partial class Callcentergroupcalltype : IEquatable<Callcentergroupcalltype>
    {
        [Column("id"            , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id             { get; set; } // uuid
        [Column("title"         , DataType = DataType.NVarChar , DbType = "character varying(128)"         , Length       = 128 )] public string?   Title          { get; set; } // character varying(128)
        [Column("cod"           , DataType = DataType.NVarChar , DbType = "character varying(128)"         , Length       = 128 )] public string?   Cod            { get; set; } // character varying(128)
        [Column("positionnumber", DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Positionnumber { get; set; } // integer
        [Column("visible"       , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Visible        { get; set; } // boolean
        [Column("createdate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Createdate     { get; set; } // timestamp (6) without time zone
        [Column("deletedate"    , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Deletedate     { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Callcentergroupcalltype> _equalityComparer = ComparerBuilder.GetEqualityComparer<Callcentergroupcalltype>(c => c.Id);

        public bool Equals(Callcentergroupcalltype? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Callcentergroupcalltype);
        }
        #endregion
    }
}
