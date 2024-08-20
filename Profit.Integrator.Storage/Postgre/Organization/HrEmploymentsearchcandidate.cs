
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    [Table("hr_employmentsearchcandidates")]
    public partial class HrEmploymentsearchcandidate : IEquatable<HrEmploymentsearchcandidate>
    {
        [Column("id"                      , DataType = DataType.Guid     , DbType = "uuid"                           , IsPrimaryKey = true)] public Guid      Id                       { get; set; } // uuid
        [Column("employmentid"            , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Employmentid             { get; set; } // uuid
        [Column("employmentsearchresultid", DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Employmentsearchresultid { get; set; } // uuid
        [Column("properties"              , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Properties               { get; set; } // text
        [Column("gender"                  , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Gender                   { get; set; } // integer
        [Column("age"                     , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Age                      { get; set; } // integer
        [Column("hascontacts"             , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool?     Hascontacts              { get; set; } // boolean
        [Column("price"                   , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Price                    { get; set; } // integer
        [Column("firstname"               , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Firstname                { get; set; } // character varying(1024)
        [Column("middlename"              , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Middlename               { get; set; } // character varying(1024)
        [Column("lastname"                , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Lastname                 { get; set; } // character varying(1024)
        [Column("address"                 , DataType = DataType.NVarChar , DbType = "character varying(2048)"        , Length       = 2048)] public string?   Address                  { get; set; } // character varying(2048)
        [Column("profession"              , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Profession               { get; set; } // character varying(1024)
        [Column("educationid"             , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Educationid              { get; set; } // uuid
        [Column("educationhistory"        , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Educationhistory         { get; set; } // text
        [Column("expirienceyear"          , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Expirienceyear           { get; set; } // integer
        [Column("expiriencehistory"       , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Expiriencehistory        { get; set; } // text
        [Column("salary"                  , DataType = DataType.Int32    , DbType = "integer"                                             )] public int?      Salary                   { get; set; } // integer
        [Column("achievements"            , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Achievements             { get; set; } // text
        [Column("href"                    , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Href                     { get; set; } // character varying(1024)
        [Column("althref"                 , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Althref                  { get; set; } // character varying(1024)
        [Column("photohref"               , DataType = DataType.NVarChar , DbType = "character varying(1024)"        , Length       = 1024)] public string?   Photohref                { get; set; } // character varying(1024)
        [Column("candidateratingstatusid" , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Candidateratingstatusid  { get; set; } // uuid
        [Column("comments"                , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Comments                 { get; set; } // text
        [Column("source"                  , DataType = DataType.NVarChar , DbType = "character varying(8)"           , Length       = 8   )] public string?   Source                   { get; set; } // character varying(8)
        [Column("externalid"              , DataType = DataType.NVarChar , DbType = "character varying(64)"          , Length       = 64  )] public string?   Externalid               { get; set; } // character varying(64)
        [Column("sourcetext"              , DataType = DataType.Text     , DbType = "text"                                                )] public string?   Sourcetext               { get; set; } // text
        [Column("externalcreateddate"     , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Externalcreateddate      { get; set; } // timestamp (6) without time zone
        [Column("externalupdateddate"     , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Externalupdateddate      { get; set; } // timestamp (6) without time zone
        [Column("createdbyuserid"         , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid      Createdbyuserid          { get; set; } // uuid
        [Column("createddate"             , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime  Createddate              { get; set; } // timestamp (6) without time zone
        [Column("updatedbyuserid"         , DataType = DataType.Guid     , DbType = "uuid"                                                )] public Guid?     Updatedbyuserid          { get; set; } // uuid
        [Column("updateddate"             , DataType = DataType.DateTime2, DbType = "timestamp (6) without time zone"                     )] public DateTime? Updateddate              { get; set; } // timestamp (6) without time zone
        [Column("isdeleted"               , DataType = DataType.Boolean  , DbType = "boolean"                                             )] public bool      Isdeleted                { get; set; } // boolean

        #region IEquatable<T> support
        private static readonly IEqualityComparer<HrEmploymentsearchcandidate> _equalityComparer = ComparerBuilder.GetEqualityComparer<HrEmploymentsearchcandidate>(c => c.Id);

        public bool Equals(HrEmploymentsearchcandidate? other)
        {
            return _equalityComparer.Equals(this, other!);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as HrEmploymentsearchcandidate);
        }
        #endregion
    }
}
