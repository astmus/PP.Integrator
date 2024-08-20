
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("voice_atms")]
    public partial class VoiceAtm : IEquatable<VoiceAtm>
    {
        [Column("id"                 , DataType = DataType.Guid    , DbType = "uuid"                   , IsPrimaryKey = true)] public Guid    Id                  { get; set; } // uuid
        [Column("title"              , DataType = DataType.NVarChar, DbType = "character varying(255)" , Length       = 255 )] public string? Title               { get; set; } // character varying(255)
        [Column("description"        , DataType = DataType.NVarChar, DbType = "character varying(1024)", Length       = 1024)] public string? Description         { get; set; } // character varying(1024)
        [Column("address"            , DataType = DataType.NVarChar, DbType = "character varying(255)" , Length       = 255 )] public string? Address             { get; set; } // character varying(255)
        [Column("schedule"           , DataType = DataType.NVarChar, DbType = "character varying(1024)", Length       = 1024)] public string? Schedule            { get; set; } // character varying(1024)
        [Column("availableoperations", DataType = DataType.NVarChar, DbType = "character varying(1024)", Length       = 1024)] public string? Availableoperations { get; set; } // character varying(1024)
        [Column("latitude"           , DataType = DataType.Double  , DbType = "double precision"                            )] public double? Latitude            { get; set; } // double precision
        [Column("longitude"          , DataType = DataType.Double  , DbType = "double precision"                            )] public double? Longitude           { get; set; } // double precision
        [Column("isdeleted"          , DataType = DataType.Boolean , DbType = "boolean"                                     )] public bool    Isdeleted           { get; set; } // boolean
        [Column("customerid"         , DataType = DataType.NVarChar, DbType = "character varying(50)"  , Length       = 50  )] public string? Customerid          { get; set; } // character varying(50)
        [Column("localityid"         , DataType = DataType.NVarChar, DbType = "character varying(50)"  , Length       = 50  )] public string? Localityid          { get; set; } // character varying(50)

        #region IEquatable<T> support
        private static readonly IEqualityComparer<VoiceAtm> _equalityComparer = ComparerBuilder.GetEqualityComparer<VoiceAtm>(c => c.Id);

        public bool Equals(VoiceAtm? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as VoiceAtm);
        }
        #endregion
    }
}
