
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("guiincidenttattributesonforms")]
    public partial class Guiincidenttattributesonform : IEquatable<Guiincidenttattributesonform>
    {
        [Column("id"              , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true                                    )] public Guid      Id               { get; set; } // uuid
        [Column("form"            , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid      Form             { get; set; } // uuid
        [Column("attribute"       , DataType  = DataType.Guid     , DbType   = "uuid"                                                                                    )] public Guid      Attribute        { get; set; } // uuid
        [Column("attrtitle"       , CanBeNull = false             , DataType = DataType.NVarChar                , DbType       = "character varying(1024)", Length = 1024)] public string    Attrtitle        { get; set; } = null!; // character varying(1024)
        [Column("attrdescription" , DataType  = DataType.Text     , DbType   = "text"                                                                                    )] public string?   Attrdescription  { get; set; } // text
        [Column("attrisrequired"  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Attrisrequired   { get; set; } // boolean
        [Column("attrisreadonly"  , DataType  = DataType.Boolean  , DbType   = "boolean"                                                                                 )] public bool?     Attrisreadonly   { get; set; } // boolean
        [Column("attrdefaultvalue", DataType  = DataType.Text     , DbType   = "text"                                                                                    )] public string?   Attrdefaultvalue { get; set; } // text
        [Column("cntrorder"       , DataType  = DataType.Int32    , DbType   = "integer"                                                                                 )] public int?      Cntrorder        { get; set; } // integer
        [Column("cntrproperties"  , DataType  = DataType.Text     , DbType   = "text"                                                                                    )] public string?   Cntrproperties   { get; set; } // text
        [Column("createdate"      , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Createdate       { get; set; } // timestamp (6) without time zone
        [Column("deletedate"      , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                                                         )] public DateTime? Deletedate       { get; set; } // timestamp (6) without time zone

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Guiincidenttattributesonform> _equalityComparer = ComparerBuilder.GetEqualityComparer<Guiincidenttattributesonform>(c => c.Id);

        public bool Equals(Guiincidenttattributesonform? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Guiincidenttattributesonform);
        }
        #endregion
    }
}
