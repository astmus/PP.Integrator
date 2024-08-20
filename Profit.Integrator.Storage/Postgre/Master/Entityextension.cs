
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("entityextensions")]
    public partial class Entityextension : IEquatable<Entityextension>
    {
        [Column("id"           , DataType = DataType.Guid    , DbType = "uuid"                  , IsPrimaryKey = true)] public Guid    Id            { get; set; } // uuid
        [Column("entityid"     , DataType = DataType.Guid    , DbType = "uuid"                                       )] public Guid    Entityid      { get; set; } // uuid
        [Column("extensionid"  , DataType = DataType.Guid    , DbType = "uuid"                                       )] public Guid    Extensionid   { get; set; } // uuid
        [Column("extensionname", DataType = DataType.NVarChar, DbType = "character varying(255)", Length       = 255 )] public string? Extensionname { get; set; } // character varying(255)
        [Column("isabstract"   , DataType = DataType.Boolean , DbType = "boolean"                                    )] public bool    Isabstract    { get; set; } // boolean
        [Column("isenabled"    , DataType = DataType.Boolean , DbType = "boolean"                                    )] public bool    Isenabled     { get; set; } // boolean
        [Column("isdeleted"    , DataType = DataType.Boolean , DbType = "boolean"                                    )] public bool    Isdeleted     { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Entityextension> _equalityComparer = ComparerBuilder.GetEqualityComparer<Entityextension>(c => c.Id);

        public bool Equals(Entityextension? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Entityextension);
        }
        #endregion
    }
}
