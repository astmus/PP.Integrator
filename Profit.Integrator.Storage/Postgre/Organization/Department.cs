
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("departments")]
    public partial class Department : IEquatable<Department>
    {
        [Column("id"                , DataType  = DataType.Guid     , DbType   = "uuid"                           , IsPrimaryKey = true  )] public Guid      Id                 { get; set; } // uuid
        [Column("name"              , CanBeNull = false             , DataType = DataType.Text                    , DbType       = "text")] public string    Name               { get; set; } = null!; // text
        [Column("description"       , DataType  = DataType.Text     , DbType   = "text"                                                  )] public string?   Description        { get; set; } // text
        [Column("headdepartmentid"  , DataType  = DataType.Guid     , DbType   = "uuid"                                                  )] public Guid?     Headdepartmentid   { get; set; } // uuid
        [Column("calendarid"        , DataType  = DataType.Guid     , DbType   = "uuid"                                                  )] public Guid?     Calendarid         { get; set; } // uuid
        [Column("managerid"         , DataType  = DataType.Guid     , DbType   = "uuid"                                                  )] public Guid?     Managerid          { get; set; } // uuid
        [Column("implementerid"     , DataType  = DataType.Guid     , DbType   = "uuid"                                                  )] public Guid?     Implementerid      { get; set; } // uuid
        [Column("customproperties"  , DataType  = DataType.Text     , DbType   = "text"                                                  )] public string?   Customproperties   { get; set; } // text
        [Column("source"            , DataType  = DataType.NVarChar , DbType   = "character varying(8)"           , Length       = 8     )] public string?   Source             { get; set; } // character varying(8)
        [Column("externalid"        , DataType  = DataType.NVarChar , DbType   = "character varying(64)"          , Length       = 64    )] public string?   Externalid         { get; set; } // character varying(64)
        [Column("createdbyuserid"   , DataType  = DataType.Guid     , DbType   = "uuid"                                                  )] public Guid      Createdbyuserid    { get; set; } // uuid
        [Column("createddate"       , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                       )] public DateTime  Createddate        { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid"   , DataType  = DataType.Guid     , DbType   = "uuid"                                                  )] public Guid?     Updatedbyuserid    { get; set; } // uuid
        [Column("updateddate"       , DataType  = DataType.DateTime2, DbType   = "timestamp (6) without time zone"                       )] public DateTime? Updateddate        { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"         , DataType  = DataType.Boolean  , DbType   = "boolean"                                               )] public bool?     Isdeleted          { get; set; } // boolean
        [Column("usehardimplementer", DataType  = DataType.Boolean  , DbType   = "boolean"                                               )] public bool?     Usehardimplementer { get; set; } // boolean
        [Column("cityname"          , DataType  = DataType.NVarChar , DbType   = "character varying(128)"         , Length       = 128   )] public string?   Cityname           { get; set; } // character varying(128)
        [Column("address"           , DataType  = DataType.NVarChar , DbType   = "character varying(1024)"        , Length       = 1024  )] public string?   Address            { get; set; } // character varying(1024)
        [Column("phone"             , DataType  = DataType.NVarChar , DbType   = "character varying(32)"          , Length       = 32    )] public string?   Phone              { get; set; } // character varying(32)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<Department> _equalityComparer = ComparerBuilder.GetEqualityComparer<Department>(c => c.Id);

        public bool Equals(Department? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Department);
        }
        #endregion
    }
}
