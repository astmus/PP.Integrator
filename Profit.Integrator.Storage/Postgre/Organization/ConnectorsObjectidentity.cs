
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("connectors_objectidentities")]
    public partial class ConnectorsObjectidentity : IEquatable<ConnectorsObjectidentity>
    {
        [Column("id"               , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid     Id                { get; set; } // uuid
        [Column("product1id"       , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Product1Id        { get; set; } // uuid
        [Column("product1extrainfo", DataType = DataType.NVarChar , DbType = "character varying(128)"         , Length       = 128 )] public string?  Product1Extrainfo { get; set; } // character varying(128)
        [Column("product1objectid" , DataType = DataType.NVarChar , DbType = "character varying(64)"          , Length       = 64  )] public string?  Product1Objectid  { get; set; } // character varying(64)
        [Column("product2id"       , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid     Product2Id        { get; set; } // uuid
        [Column("product2extrainfo", DataType = DataType.NVarChar , DbType = "character varying(128)"         , Length       = 128 )] public string?  Product2Extrainfo { get; set; } // character varying(128)
        [Column("product2objectid" , DataType = DataType.NVarChar , DbType = "character varying(64)"          , Length       = 64  )] public string?  Product2Objectid  { get; set; } // character varying(64)
        [Column("createddate"      , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime Createddate       { get; set; } // timestamp (6) without time zone
        [Column("isfirstfromsm"    , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool     Isfirstfromsm     { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<ConnectorsObjectidentity> _equalityComparer = ComparerBuilder.GetEqualityComparer<ConnectorsObjectidentity>(c => c.Id);

        public bool Equals(ConnectorsObjectidentity? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ConnectorsObjectidentity);
        }
        #endregion
    }
}
