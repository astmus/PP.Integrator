
using LinqToDB;
using LinqToDB.Data;
using Profit.Integrator.Storage.Postgre.Organization;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable 1573, 1591

namespace Profit.Integrator.Storage
{
    /// <summary>
    /// Database       : pit_0025
    /// Data Source    : tcp://localhost:5432
    /// Server Version : 16.3
    /// 
    /// </summary>
    public partial class OrganizationDataBase : DataConnection
    {
        public OrganizationDataBase()
        {
            InitDataContext();
        }

        public OrganizationDataBase(string configuration)
            : base(configuration)
        {
            InitDataContext();
        }

        public OrganizationDataBase(DataOptions<OrganizationDataBase> options)
            : base(options.Options)
        {
            InitDataContext();
        }

        partial void InitDataContext();

        public ITable<Absencecandidate> Absencecandidates => this.GetTable<Absencecandidate>();
        public ITable<Absenceclassificationcandidate> Absenceclassificationcandidates => this.GetTable<Absenceclassificationcandidate>();
        public ITable<Absenseclassification> Absenseclassifications => this.GetTable<Absenseclassification>();
        public ITable<Accessform> Accessforms => this.GetTable<Accessform>();
        public ITable<Accessformsforrole> Accessformsforroles => this.GetTable<Accessformsforrole>();
        public ITable<Accesstoobject> Accesstoobjects => this.GetTable<Accesstoobject>();
        public ITable<Accrual> Accruals => this.GetTable<Accrual>();
        public ITable<ActivedirectoryGroup> ActivedirectoryGroups => this.GetTable<ActivedirectoryGroup>();
        public ITable<ActivedirectoryMembership> ActivedirectoryMemberships => this.GetTable<ActivedirectoryMembership>();
        public ITable<Activitylogtype> Activitylogtypes => this.GetTable<Activitylogtype>();
        public ITable<App> Apps => this.GetTable<App>();
        public ITable<Appscategory> Appscategories => this.GetTable<Appscategory>();
        public ITable<Appsmask> Appsmasks => this.GetTable<Appsmask>();
        public ITable<Appstype> Appstypes => this.GetTable<Appstype>();
        public ITable<Article> Articles => this.GetTable<Article>();
        public ITable<Attachedfile> Attachedfiles => this.GetTable<Attachedfile>();
        public ITable<AutoexplanatoryClassificationNotifieduser> AutoexplanatoryClassificationNotifiedusers => this.GetTable<AutoexplanatoryClassificationNotifieduser>();
        public ITable<BackLocalizedtext> BackLocalizedtexts => this.GetTable<BackLocalizedtext>();
        public ITable<BayesArea> BayesAreas => this.GetTable<BayesArea>();
        public ITable<BayesPrimarydatum> BayesPrimarydata => this.GetTable<BayesPrimarydatum>();
        public ITable<BayesStatistic> BayesStatistics => this.GetTable<BayesStatistic>();
        public ITable<BeizAu> BeizAus => this.GetTable<BeizAu>();
        public ITable<BeizKey> BeizKeys => this.GetTable<BeizKey>();
        public ITable<Bill> Bills => this.GetTable<Bill>();
        public ITable<Blobstorage> Blobstorages => this.GetTable<Blobstorage>();
        public ITable<Blobtempstorage> Blobtempstorages => this.GetTable<Blobtempstorage>();
        public ITable<Branch> Branches => this.GetTable<Branch>();
        public ITable<BsPhrasesclusteritem> BsPhrasesclusteritems => this.GetTable<BsPhrasesclusteritem>();
        public ITable<BsPhrasescluster> BsPhrasesclusters => this.GetTable<BsPhrasescluster>();
        public ITable<BsReferenceitem> BsReferenceitems => this.GetTable<BsReferenceitem>();
        public ITable<BsReferencesetting> BsReferencesettings => this.GetTable<BsReferencesetting>();
        public ITable<BsReferencetype> BsReferencetypes => this.GetTable<BsReferencetype>();
        public ITable<C1Change> C1Changes => this.GetTable<C1Change>();
        public ITable<CalException> CalExceptions => this.GetTable<CalException>();
        public ITable<Calendar> Calendars => this.GetTable<Calendar>();
        public ITable<Calendarmeeting> Calendarmeetings => this.GetTable<Calendarmeeting>();
        public ITable<CallcenterAppsetting> CallcenterAppsettings => this.GetTable<CallcenterAppsetting>();
        public ITable<CallcenterCallsqueue> CallcenterCallsqueues => this.GetTable<CallcenterCallsqueue>();
        public ITable<CallcenterOperatordilainglock> CallcenterOperatordilainglocks => this.GetTable<CallcenterOperatordilainglock>();
        public ITable<CallcenterOperatorreceivedcall> CallcenterOperatorreceivedcalls => this.GetTable<CallcenterOperatorreceivedcall>();
        public ITable<CallcenterOperatorsinwork> CallcenterOperatorsinworks => this.GetTable<CallcenterOperatorsinwork>();
        public ITable<CallcenterOutgoingruleabonent> CallcenterOutgoingruleabonents => this.GetTable<CallcenterOutgoingruleabonent>();
        public ITable<CallcenterOutgoingruleabonentsDpl> CallcenterOutgoingruleabonentsDpls => this.GetTable<CallcenterOutgoingruleabonentsDpl>();
        public ITable<CallcenterOutgoingruleoutgoingline> CallcenterOutgoingruleoutgoinglines => this.GetTable<CallcenterOutgoingruleoutgoingline>();
        public ITable<CallcenterOutgoingrule> CallcenterOutgoingrules => this.GetTable<CallcenterOutgoingrule>();
        public ITable<CallcenterVirtualline> CallcenterVirtuallines => this.GetTable<CallcenterVirtualline>();
        public ITable<Callcentercallstatelog> Callcentercallstatelogs => this.GetTable<Callcentercallstatelog>();
        public ITable<Callcentercallstatetimeslot> Callcentercallstatetimeslots => this.GetTable<Callcentercallstatetimeslot>();
        public ITable<Callcentercallstatetype> Callcentercallstatetypes => this.GetTable<Callcentercallstatetype>();
        public ITable<Callcentergroupcalltype> Callcentergroupcalltypes => this.GetTable<Callcentergroupcalltype>();
        public ITable<Callcenterincomeline> Callcenterincomelines => this.GetTable<Callcenterincomeline>();
        public ITable<Callcenterivrmenuitem> Callcenterivrmenuitems => this.GetTable<Callcenterivrmenuitem>();
        public ITable<Callcenterivrmenu> Callcenterivrmenus => this.GetTable<Callcenterivrmenu>();
        public ITable<Callcenterivrrecordfile> Callcenterivrrecordfiles => this.GetTable<Callcenterivrrecordfile>();
        public ITable<Callcenteroperator> Callcenteroperators => this.GetTable<Callcenteroperator>();
        public ITable<Callcenteroperatorsgroup> Callcenteroperatorsgroups => this.GetTable<Callcenteroperatorsgroup>();
        public ITable<Callcenteroperatorsingroup> Callcenteroperatorsingroups => this.GetTable<Callcenteroperatorsingroup>();
        public ITable<Callcenterrecall> Callcenterrecalls => this.GetTable<Callcenterrecall>();
        public ITable<Callcentertelbutton> Callcentertelbuttons => this.GetTable<Callcentertelbutton>();
        public ITable<Callresultstate> Callresultstates => this.GetTable<Callresultstate>();
        public ITable<Call> Calls => this.GetTable<Call>();
        public ITable<Callsrecord> Callsrecords => this.GetTable<Callsrecord>();
        public ITable<Callst> Callsts => this.GetTable<Callst>();
        public ITable<CcPrioritycall> CcPrioritycalls => this.GetTable<CcPrioritycall>();
        public ITable<CcSchedulecall> CcSchedulecalls => this.GetTable<CcSchedulecall>();
        public ITable<CcStatecall> CcStatecalls => this.GetTable<CcStatecall>();
        public ITable<CcUnsuccessfulcall> CcUnsuccessfulcalls => this.GetTable<CcUnsuccessfulcall>();
        public ITable<ChatActivity> ChatActivities => this.GetTable<ChatActivity>();
        public ITable<ChatActivityattachment> ChatActivityattachments => this.GetTable<ChatActivityattachment>();
        public ITable<Cleartablessetting> Cleartablessettings => this.GetTable<Cleartablessetting>();
        public ITable<ClipboardContent> ClipboardContents => this.GetTable<ClipboardContent>();
        public ITable<CommonSetting> CommonSettings => this.GetTable<CommonSetting>();
        public ITable<ConnectorsAccount> ConnectorsAccounts => this.GetTable<ConnectorsAccount>();
        public ITable<ConnectorsClasstimesync> ConnectorsClasstimesyncs => this.GetTable<ConnectorsClasstimesync>();
        public ITable<ConnectorsExchangedirection> ConnectorsExchangedirections => this.GetTable<ConnectorsExchangedirection>();
        public ITable<ConnectorsExchangeitem> ConnectorsExchangeitems => this.GetTable<ConnectorsExchangeitem>();
        public ITable<ConnectorsExchangelog> ConnectorsExchangelogs => this.GetTable<ConnectorsExchangelog>();
        public ITable<ConnectorsGrpcconnection> ConnectorsGrpcconnections => this.GetTable<ConnectorsGrpcconnection>();
        public ITable<ConnectorsObjectidentity> ConnectorsObjectidentities => this.GetTable<ConnectorsObjectidentity>();
        public ITable<ConnectorsProduct> ConnectorsProducts => this.GetTable<ConnectorsProduct>();
        public ITable<ConnectorsSetting> ConnectorsSettings => this.GetTable<ConnectorsSetting>();
        public ITable<ConsoleContact> ConsoleContacts => this.GetTable<ConsoleContact>();
        public ITable<ConsoleContactsemail> ConsoleContactsemails => this.GetTable<ConsoleContactsemail>();
        public ITable<ConsoleContactsgroup> ConsoleContactsgroups => this.GetTable<ConsoleContactsgroup>();
        public ITable<ConsoleContactsgroupsmember> ConsoleContactsgroupsmembers => this.GetTable<ConsoleContactsgroupsmember>();
        public ITable<ConsoleContactsphone> ConsoleContactsphones => this.GetTable<ConsoleContactsphone>();
        public ITable<ConsoleEventhistory> ConsoleEventhistories => this.GetTable<ConsoleEventhistory>();
        public ITable<ConsoleEventresulttype> ConsoleEventresulttypes => this.GetTable<ConsoleEventresulttype>();
        public ITable<ConsoleEventtype> ConsoleEventtypes => this.GetTable<ConsoleEventtype>();
        public ITable<ConsoleUser> ConsoleUsers => this.GetTable<ConsoleUser>();
        public ITable<ConsoleUserscontactsgroup> ConsoleUserscontactsgroups => this.GetTable<ConsoleUserscontactsgroup>();
        public ITable<ConsoleUserscontactsgroupsmember> ConsoleUserscontactsgroupsmembers => this.GetTable<ConsoleUserscontactsgroupsmember>();
        public ITable<ConsoleUserscontactsperson> ConsoleUserscontactspersons => this.GetTable<ConsoleUserscontactsperson>();
        public ITable<Constant> Constants => this.GetTable<Constant>();
        public ITable<Cweinstallation> Cweinstallations => this.GetTable<Cweinstallation>();
        public ITable<DctLemmaresult> DctLemmaresults => this.GetTable<DctLemmaresult>();
        public ITable<Departmentincidentassigneduser> Departmentincidentassignedusers => this.GetTable<Departmentincidentassigneduser>();
        public ITable<Departmentnotifychannel> Departmentnotifychannels => this.GetTable<Departmentnotifychannel>();
        public ITable<Departmentnotifyuser> Departmentnotifyusers => this.GetTable<Departmentnotifyuser>();
        public ITable<Department> Departments => this.GetTable<Department>();
        public ITable<Departmentssetting> Departmentssettings => this.GetTable<Departmentssetting>();
        public ITable<Discount> Discounts => this.GetTable<Discount>();
        public ITable<DwhCcCallstime> DwhCcCallstimes => this.GetTable<DwhCcCallstime>();
        public ITable<DwhChat> DwhChats => this.GetTable<DwhChat>();
        public ITable<DwhMetric> DwhMetrics => this.GetTable<DwhMetric>();
        public ITable<DwhMetricsAlertslog> DwhMetricsAlertslogs => this.GetTable<DwhMetricsAlertslog>();
        public ITable<DwhMetricsgroup> DwhMetricsgroups => this.GetTable<DwhMetricsgroup>();
        public ITable<DwhMetricsoperand> DwhMetricsoperands => this.GetTable<DwhMetricsoperand>();
        public ITable<DwhMetricsoperandsVoiceCheckpoint> DwhMetricsoperandsVoiceCheckpoints => this.GetTable<DwhMetricsoperandsVoiceCheckpoint>();
        public ITable<DwhPhraseclusterDialog> DwhPhraseclusterDialogs => this.GetTable<DwhPhraseclusterDialog>();
        public ITable<DwhVoiceCheckpoint> DwhVoiceCheckpoints => this.GetTable<DwhVoiceCheckpoint>();
        public ITable<Exclog> Exclogs => this.GetTable<Exclog>();
        public ITable<ExportResource> ExportResources => this.GetTable<ExportResource>();
        public ITable<Frequencyincidentresolution> Frequencyincidentresolutions => this.GetTable<Frequencyincidentresolution>();
        public ITable<GoodsBrand> GoodsBrands => this.GetTable<GoodsBrand>();
        public ITable<GoodsGood> GoodsGoods => this.GetTable<GoodsGood>();
        public ITable<GoodsGoodschemeattribute> GoodsGoodschemeattributes => this.GetTable<GoodsGoodschemeattribute>();
        public ITable<GoodsWordprocessing> GoodsWordprocessings => this.GetTable<GoodsWordprocessing>();
        public ITable<Group> Groups => this.GetTable<Group>();
        public ITable<Groupsmember> Groupsmembers => this.GetTable<Groupsmember>();
        public ITable<Guiincidentattribute> Guiincidentattributes => this.GetTable<Guiincidentattribute>();
        public ITable<Guiincidentattributesondynamicscontainer> Guiincidentattributesondynamicscontainers => this.GetTable<Guiincidentattributesondynamicscontainer>();
        public ITable<Guiincidentbuttonenabledattribute> Guiincidentbuttonenabledattributes => this.GetTable<Guiincidentbuttonenabledattribute>();
        public ITable<Guiincidentbutton> Guiincidentbuttons => this.GetTable<Guiincidentbutton>();
        public ITable<Guiincidentbuttonsetattribute> Guiincidentbuttonsetattributes => this.GetTable<Guiincidentbuttonsetattribute>();
        public ITable<Guiincidentbuttonsondynamicscontainer> Guiincidentbuttonsondynamicscontainers => this.GetTable<Guiincidentbuttonsondynamicscontainer>();
        public ITable<Guiincidentdynamicscontainer> Guiincidentdynamicscontainers => this.GetTable<Guiincidentdynamicscontainer>();
        public ITable<Guiincidentform> Guiincidentforms => this.GetTable<Guiincidentform>();
        public ITable<Guiincidentgridattributecolumn> Guiincidentgridattributecolumns => this.GetTable<Guiincidentgridattributecolumn>();
        public ITable<Guiincidentgridcalccolumn> Guiincidentgridcalccolumns => this.GetTable<Guiincidentgridcalccolumn>();
        public ITable<Guiincidentscript> Guiincidentscripts => this.GetTable<Guiincidentscript>();
        public ITable<Guiincidenttattributesonform> Guiincidenttattributesonforms => this.GetTable<Guiincidenttattributesonform>();
        public ITable<Guiincidentuserattributecontroltype> Guiincidentuserattributecontroltypes => this.GetTable<Guiincidentuserattributecontroltype>();
        public ITable<Guiincidentuserattribute> Guiincidentuserattributes => this.GetTable<Guiincidentuserattribute>();
        public ITable<Guiincidentuserattributesourceparam> Guiincidentuserattributesourceparams => this.GetTable<Guiincidentuserattributesourceparam>();
        public ITable<Guiincidentuserattributesourcetype> Guiincidentuserattributesourcetypes => this.GetTable<Guiincidentuserattributesourcetype>();
        public ITable<Guiincidentuserattributetype> Guiincidentuserattributetypes => this.GetTable<Guiincidentuserattributetype>();
        public ITable<HrCandidateonstagingitemstatus> HrCandidateonstagingitemstatuses => this.GetTable<HrCandidateonstagingitemstatus>();
        public ITable<HrCandidateonstepstatus> HrCandidateonstepstatuses => this.GetTable<HrCandidateonstepstatus>();
        public ITable<HrCandidateratingstatus> HrCandidateratingstatuses => this.GetTable<HrCandidateratingstatus>();
        public ITable<HrEmploymentcandidatesonstagingitem> HrEmploymentcandidatesonstagingitems => this.GetTable<HrEmploymentcandidatesonstagingitem>();
        public ITable<HrEmployment> HrEmployments => this.GetTable<HrEmployment>();
        public ITable<HrEmploymentsearchcandidate> HrEmploymentsearchcandidates => this.GetTable<HrEmploymentsearchcandidate>();
        public ITable<HrEmploymentsearchresult> HrEmploymentsearchresults => this.GetTable<HrEmploymentsearchresult>();
        public ITable<HrReferenceitem> HrReferenceitems => this.GetTable<HrReferenceitem>();
        public ITable<HrReferencetype> HrReferencetypes => this.GetTable<HrReferencetype>();
        public ITable<HrStagingemploymentitemhrcoworker> HrStagingemploymentitemhrcoworkers => this.GetTable<HrStagingemploymentitemhrcoworker>();
        public ITable<HrStagingemploymentitem> HrStagingemploymentitems => this.GetTable<HrStagingemploymentitem>();
        public ITable<HrStagingemployment> HrStagingemployments => this.GetTable<HrStagingemployment>();
        public ITable<JournalEntitychangeitem> JournalEntitychangeitems => this.GetTable<JournalEntitychangeitem>();
        public ITable<JournalEntitychange> JournalEntitychanges => this.GetTable<JournalEntitychange>();
        public ITable<Languagecode> Languagecodes => this.GetTable<Languagecode>();
        public ITable<Link> Links => this.GetTable<Link>();
        public ITable<Localizedtext> Localizedtexts => this.GetTable<Localizedtext>();
        public ITable<LogObjectsprocess> LogObjectsprocesses => this.GetTable<LogObjectsprocess>();
        public ITable<Log> Logs => this.GetTable<Log>();
        public ITable<LogsObjectstype> LogsObjectstypes => this.GetTable<LogsObjectstype>();
        public ITable<LogsTransactiontype> LogsTransactiontypes => this.GetTable<LogsTransactiontype>();
        public ITable<LogsVisitsobjectsbyuser> LogsVisitsobjectsbyusers => this.GetTable<LogsVisitsobjectsbyuser>();
        public ITable<Mark> Marks => this.GetTable<Mark>();
        public ITable<Message> Messages => this.GetTable<Message>();
        public ITable<MonitoringDeviceparam> MonitoringDeviceparams => this.GetTable<MonitoringDeviceparam>();
        public ITable<MonitoringDevice> MonitoringDevices => this.GetTable<MonitoringDevice>();
        public ITable<MonitoringDevicestype> MonitoringDevicestypes => this.GetTable<MonitoringDevicestype>();
        public ITable<MonitoringEventslog> MonitoringEventslogs => this.GetTable<MonitoringEventslog>();
        public ITable<MonitoringStatuslog> MonitoringStatuslogs => this.GetTable<MonitoringStatuslog>();
        public ITable<NluCategory> NluCategories => this.GetTable<NluCategory>();
        public ITable<NluRelation> NluRelations => this.GetTable<NluRelation>();
        public ITable<NluStopword> NluStopwords => this.GetTable<NluStopword>();
        public ITable<NluWordform> NluWordforms => this.GetTable<NluWordform>();
        public ITable<NluWord> NluWords => this.GetTable<NluWord>();
        public ITable<Notification> Notifications => this.GetTable<Notification>();
        public ITable<NotificationserviceDistributiongroup> NotificationserviceDistributiongroups => this.GetTable<NotificationserviceDistributiongroup>();
        public ITable<NotificationserviceDistributiongroupsmember> NotificationserviceDistributiongroupsmembers => this.GetTable<NotificationserviceDistributiongroupsmember>();
        public ITable<NotificationserviceMessage> NotificationserviceMessages => this.GetTable<NotificationserviceMessage>();
        public ITable<NotificationserviceQueue> NotificationserviceQueues => this.GetTable<NotificationserviceQueue>();
        public ITable<Notifychannel> Notifychannels => this.GetTable<Notifychannel>();
        public ITable<Objectpermission> Objectpermissions => this.GetTable<Objectpermission>();
        public ITable<Otheremailsbyuser> Otheremailsbyusers => this.GetTable<Otheremailsbyuser>();
        public ITable<Otherphonesbyuser> Otherphonesbyusers => this.GetTable<Otherphonesbyuser>();
        public ITable<Pitstate> Pitstates => this.GetTable<Pitstate>();
        public ITable<Poll> Polls => this.GetTable<Poll>();
        public ITable<Queue> Queues => this.GetTable<Queue>();
        public ITable<Region> Regions => this.GetTable<Region>();
        public ITable<Relatedincidentandcall> Relatedincidentandcalls => this.GetTable<Relatedincidentandcall>();
        public ITable<ReportsEnabledcustomreport> ReportsEnabledcustomreports => this.GetTable<ReportsEnabledcustomreport>();
        public ITable<ReportsExternalreport> ReportsExternalreports => this.GetTable<ReportsExternalreport>();
        public ITable<Role> Roles => this.GetTable<Role>();
        public ITable<Rolesmember> Rolesmembers => this.GetTable<Rolesmember>();
        public ITable<Schemaversion> Schemaversions => this.GetTable<Schemaversion>();
        public ITable<Scriptdetail> Scriptdetails => this.GetTable<Scriptdetail>();
        public ITable<Script> Scripts => this.GetTable<Script>();
        public ITable<SdEntitieschangelog> SdEntitieschangelogs => this.GetTable<SdEntitieschangelog>();
        public ITable<SdEntitytype> SdEntitytypes => this.GetTable<SdEntitytype>();
        public ITable<SdExchangeEventtype> SdExchangeEventtypes => this.GetTable<SdExchangeEventtype>();
        public ITable<SdExchangelog> SdExchangelogs => this.GetTable<SdExchangelog>();
        public ITable<SdExchangeout> SdExchangeouts => this.GetTable<SdExchangeout>();
        public ITable<SdKnowledgearticle> SdKnowledgearticles => this.GetTable<SdKnowledgearticle>();
        public ITable<SdKnowledgearticlesFolder> SdKnowledgearticlesFolders => this.GetTable<SdKnowledgearticlesFolder>();
        public ITable<SdSetting> SdSettings => this.GetTable<SdSetting>();
        public ITable<SdSla> SdSlas => this.GetTable<SdSla>();
        public ITable<SdSlaColor> SdSlaColors => this.GetTable<SdSlaColor>();
        public ITable<SdSlaMetric> SdSlaMetrics => this.GetTable<SdSlaMetric>();
        public ITable<SdSlaSlacategoryitem> SdSlaSlacategoryitems => this.GetTable<SdSlaSlacategoryitem>();
        public ITable<SdSlaSlametricitem> SdSlaSlametricitems => this.GetTable<SdSlaSlametricitem>();
        public ITable<SdTierqueuesenummember> SdTierqueuesenummembers => this.GetTable<SdTierqueuesenummember>();
        public ITable<SdWebrequest> SdWebrequests => this.GetTable<SdWebrequest>();
        public ITable<SdWorkitemColor> SdWorkitemColors => this.GetTable<SdWorkitemColor>();
        public ITable<SdWorkitemComment> SdWorkitemComments => this.GetTable<SdWorkitemComment>();
        public ITable<SdWorkitemCommentsauthortype> SdWorkitemCommentsauthortypes => this.GetTable<SdWorkitemCommentsauthortype>();
        public ITable<SdWorkitemCommentstype> SdWorkitemCommentstypes => this.GetTable<SdWorkitemCommentstype>();
        public ITable<SdWorkitemConditionsforsendingsm> SdWorkitemConditionsforsendingsms => this.GetTable<SdWorkitemConditionsforsendingsm>();
        public ITable<SdWorkitemElapsedtime> SdWorkitemElapsedtimes => this.GetTable<SdWorkitemElapsedtime>();
        public ITable<SdWorkitemEnum> SdWorkitemEnums => this.GetTable<SdWorkitemEnum>();
        public ITable<SdWorkitemEnumtype> SdWorkitemEnumtypes => this.GetTable<SdWorkitemEnumtype>();
        public ITable<SdWorkitemIncident> SdWorkitemIncidents => this.GetTable<SdWorkitemIncident>();
        public ITable<SdWorkitemListingsetting> SdWorkitemListingsettings => this.GetTable<SdWorkitemListingsetting>();
        public ITable<SdWorkitemRelatedknowledgearticle> SdWorkitemRelatedknowledgearticles => this.GetTable<SdWorkitemRelatedknowledgearticle>();
        public ITable<SdWorkitemSourceitem> SdWorkitemSourceitems => this.GetTable<SdWorkitemSourceitem>();
        public ITable<SdWorkitemsFactsla> SdWorkitemsFactslas => this.GetTable<SdWorkitemsFactsla>();
        public ITable<SdWorkitemsSla> SdWorkitemsSlas => this.GetTable<SdWorkitemsSla>();
        public ITable<ServicedeskSmsintegrationNotificationqueue> ServicedeskSmsintegrationNotificationqueues => this.GetTable<ServicedeskSmsintegrationNotificationqueue>();
        public ITable<Setting> Settings => this.GetTable<Setting>();
        public ITable<Settingschangelog> Settingschangelogs => this.GetTable<Settingschangelog>();
        public ITable<Settingsxml> Settingsxmls => this.GetTable<Settingsxml>();
        public ITable<Signatureuser> Signatureusers => this.GetTable<Signatureuser>();
        public ITable<SmsOperation> SmsOperations => this.GetTable<SmsOperation>();
        public ITable<Solution> Solutions => this.GetTable<Solution>();
        public ITable<Structcolumn> Structcolumns => this.GetTable<Structcolumn>();
        public ITable<StructkeyColumnUsage> StructkeyColumnUsages => this.GetTable<StructkeyColumnUsage>();
        public ITable<Structobject> Structobjects => this.GetTable<Structobject>();
        public ITable<Structsyscolumn> Structsyscolumns => this.GetTable<Structsyscolumn>();
        public ITable<StructtableConstraint> StructtableConstraints => this.GetTable<StructtableConstraint>();
        public ITable<Structtable> Structtables => this.GetTable<Structtable>();
        public ITable<T13> T13 => this.GetTable<T13>();
        public ITable<Temp1> Temp1 => this.GetTable<Temp1>();
        public ITable<Temp2> Temp2 => this.GetTable<Temp2>();
        public ITable<Textmessage> Textmessages => this.GetTable<Textmessage>();
        public ITable<Tierqueuesenumonadgroup> Tierqueuesenumonadgroups => this.GetTable<Tierqueuesenumonadgroup>();
        public ITable<Tim> Tims => this.GetTable<Tim>();
        public ITable<TimemanagementSchedule> TimemanagementSchedules => this.GetTable<TimemanagementSchedule>();
        public ITable<TimemanagementScheduleOffice> TimemanagementScheduleOffices => this.GetTable<TimemanagementScheduleOffice>();
        public ITable<TimemanagementScheduleOfficeroleassignment> TimemanagementScheduleOfficeroleassignments => this.GetTable<TimemanagementScheduleOfficeroleassignment>();
        public ITable<TimemanagementScheduleRole> TimemanagementScheduleRoles => this.GetTable<TimemanagementScheduleRole>();
        public ITable<TimemanagementScheduleWorkday> TimemanagementScheduleWorkdays => this.GetTable<TimemanagementScheduleWorkday>();
        public ITable<TimemanagementScheduleassignment> TimemanagementScheduleassignments => this.GetTable<TimemanagementScheduleassignment>();
        public ITable<Timezone> Timezones => this.GetTable<Timezone>();
        public ITable<TmpCallcentercallstatetimeslot> TmpCallcentercallstatetimeslots => this.GetTable<TmpCallcentercallstatetimeslot>();
        public ITable<Trustedapp> Trustedapps => this.GetTable<Trustedapp>();
        public ITable<UiPagegroup> UiPagegroups => this.GetTable<UiPagegroup>();
        public ITable<UiPage> UiPages => this.GetTable<UiPage>();
        public ITable<UiPagesingroup> UiPagesingroups => this.GetTable<UiPagesingroup>();
        public ITable<UiRoleaccesstopage> UiRoleaccesstopages => this.GetTable<UiRoleaccesstopage>();
        public ITable<Updatedatabasescript> Updatedatabasescripts => this.GetTable<Updatedatabasescript>();
        public ITable<Usercontact> Usercontacts => this.GetTable<Usercontact>();
        public ITable<Usercontacttype> Usercontacttypes => this.GetTable<Usercontacttype>();
        public ITable<Usernotification> Usernotifications => this.GetTable<Usernotification>();
        public ITable<Usernotificationsmacrose> Usernotificationsmacroses => this.GetTable<Usernotificationsmacrose>();
        public ITable<Usernotificationssendedbychannel> Usernotificationssendedbychannels => this.GetTable<Usernotificationssendedbychannel>();
        public ITable<Usernotificationstemplate> Usernotificationstemplates => this.GetTable<Usernotificationstemplate>();
        public ITable<Usernotificationstemplatesonbackgroundtask> Usernotificationstemplatesonbackgroundtasks => this.GetTable<Usernotificationstemplatesonbackgroundtask>();
        public ITable<Usernotificationstemplatesview> Usernotificationstemplatesviews => this.GetTable<Usernotificationstemplatesview>();
        public ITable<Usernotifychannel> Usernotifychannels => this.GetTable<Usernotifychannel>();
        public ITable<User> Users => this.GetTable<User>();
        public ITable<UsersLog> UsersLogs => this.GetTable<UsersLog>();
        public ITable<UsersProperty> UsersProperties => this.GetTable<UsersProperty>();
        public ITable<Usersstate> Usersstates => this.GetTable<Usersstate>();
        public ITable<Usersstateanalyzing> Usersstateanalyzings => this.GetTable<Usersstateanalyzing>();
        public ITable<ViAvitochatstatus> ViAvitochatstatuses => this.GetTable<ViAvitochatstatus>();
        public ITable<ViCall> ViCalls => this.GetTable<ViCall>();
        public ITable<ViChatactivity> ViChatactivities => this.GetTable<ViChatactivity>();
        public ITable<ViChatactivityattachment> ViChatactivityattachments => this.GetTable<ViChatactivityattachment>();
        public ITable<ViChatclientssetting> ViChatclientssettings => this.GetTable<ViChatclientssetting>();
        public ITable<ViChatloading> ViChatloadings => this.GetTable<ViChatloading>();
        public ITable<ViChatlog> ViChatlogs => this.GetTable<ViChatlog>();
        public ITable<ViChatlogtype> ViChatlogtypes => this.GetTable<ViChatlogtype>();
        public ITable<ViChatoperatorslog> ViChatoperatorslogs => this.GetTable<ViChatoperatorslog>();
        public ITable<ViChatoperatorssetting> ViChatoperatorssettings => this.GetTable<ViChatoperatorssetting>();
        public ITable<ViChatoperatorsstatus> ViChatoperatorsstatuses => this.GetTable<ViChatoperatorsstatus>();
        public ITable<ViChatplatform> ViChatplatforms => this.GetTable<ViChatplatform>();
        public ITable<ViChatrequest> ViChatrequests => this.GetTable<ViChatrequest>();
        public ITable<ViChatrichmediatemplate> ViChatrichmediatemplates => this.GetTable<ViChatrichmediatemplate>();
        public ITable<ViChatrichmediatemplatesbyplatform> ViChatrichmediatemplatesbyplatforms => this.GetTable<ViChatrichmediatemplatesbyplatform>();
        public ITable<ViChat> ViChats => this.GetTable<ViChat>();
        public ITable<ViChatsystemmessage> ViChatsystemmessages => this.GetTable<ViChatsystemmessage>();
        public ITable<ViChattimeout> ViChattimeouts => this.GetTable<ViChattimeout>();
        public ITable<ViCheckpoint> ViCheckpoints => this.GetTable<ViCheckpoint>();
        public ITable<ViClassificationstatistic> ViClassificationstatistics => this.GetTable<ViClassificationstatistic>();
        public ITable<ViDialog> ViDialogs => this.GetTable<ViDialog>();
        public ITable<ViExternalresource> ViExternalresources => this.GetTable<ViExternalresource>();
        public ITable<ViExternalresourcesavailability> ViExternalresourcesavailabilities => this.GetTable<ViExternalresourcesavailability>();
        public ITable<ViNotificationbychannel> ViNotificationbychannels => this.GetTable<ViNotificationbychannel>();
        public ITable<ViNotificationbyuser> ViNotificationbyusers => this.GetTable<ViNotificationbyuser>();
        public ITable<ViNotification> ViNotifications => this.GetTable<ViNotification>();
        public ITable<ViNotificationsendedbysession> ViNotificationsendedbysessions => this.GetTable<ViNotificationsendedbysession>();
        public ITable<ViObjectschemeAttributeValue> ViObjectschemeAttributeValues => this.GetTable<ViObjectschemeAttributeValue>();
        public ITable<ViObjectschemeAttribute> ViObjectschemeAttributes => this.GetTable<ViObjectschemeAttribute>();
        public ITable<ViObjectscheme> ViObjectschemes => this.GetTable<ViObjectscheme>();
        public ITable<ViPlatformlog> ViPlatformlogs => this.GetTable<ViPlatformlog>();
        public ITable<ViScriptbychannel> ViScriptbychannels => this.GetTable<ViScriptbychannel>();
        public ITable<ViSessionchannel> ViSessionchannels => this.GetTable<ViSessionchannel>();
        public ITable<ViSessionrelation> ViSessionrelations => this.GetTable<ViSessionrelation>();
        public ITable<ViSession> ViSessions => this.GetTable<ViSession>();
        public ITable<ViSessiontype> ViSessiontypes => this.GetTable<ViSessiontype>();
        public ITable<Viewedincident> Viewedincidents => this.GetTable<Viewedincident>();
        public ITable<VoiceAbonentaccountingtype> VoiceAbonentaccountingtypes => this.GetTable<VoiceAbonentaccountingtype>();
        public ITable<VoiceAbonentaddress> VoiceAbonentaddresses => this.GetTable<VoiceAbonentaddress>();
        public ITable<VoiceAbonentdebt> VoiceAbonentdebts => this.GetTable<VoiceAbonentdebt>();
        public ITable<VoiceAbonentdeviceaddress> VoiceAbonentdeviceaddresses => this.GetTable<VoiceAbonentdeviceaddress>();
        public ITable<VoiceAbonentdeviceowner> VoiceAbonentdeviceowners => this.GetTable<VoiceAbonentdeviceowner>();
        public ITable<VoiceAbonentdevicerate> VoiceAbonentdevicerates => this.GetTable<VoiceAbonentdevicerate>();
        public ITable<VoiceAbonentdeviceratetype> VoiceAbonentdeviceratetypes => this.GetTable<VoiceAbonentdeviceratetype>();
        public ITable<VoiceAbonentdevice> VoiceAbonentdevices => this.GetTable<VoiceAbonentdevice>();
        public ITable<VoiceAbonentdevicevalue> VoiceAbonentdevicevalues => this.GetTable<VoiceAbonentdevicevalue>();
        public ITable<VoiceAbonentdeviceverification> VoiceAbonentdeviceverifications => this.GetTable<VoiceAbonentdeviceverification>();
        public ITable<VoiceAbonentphonenumber> VoiceAbonentphonenumbers => this.GetTable<VoiceAbonentphonenumber>();
        public ITable<VoiceAbonent> VoiceAbonents => this.GetTable<VoiceAbonent>();
        public ITable<VoiceAppsetting> VoiceAppsettings => this.GetTable<VoiceAppsetting>();
        public ITable<VoiceAtm> VoiceAtms => this.GetTable<VoiceAtm>();
        public ITable<VoiceBilling> VoiceBillings => this.GetTable<VoiceBilling>();
        public ITable<VoiceBingcache> VoiceBingcaches => this.GetTable<VoiceBingcache>();
        public ITable<VoiceCall> VoiceCalls => this.GetTable<VoiceCall>();
        public ITable<VoiceCellblockingreason> VoiceCellblockingreasons => this.GetTable<VoiceCellblockingreason>();
        public ITable<VoiceCell> VoiceCells => this.GetTable<VoiceCell>();
        public ITable<VoiceCheckpointdetail> VoiceCheckpointdetails => this.GetTable<VoiceCheckpointdetail>();
        public ITable<VoiceCheckpoint> VoiceCheckpoints => this.GetTable<VoiceCheckpoint>();
        public ITable<VoiceClerkstoplist> VoiceClerkstoplists => this.GetTable<VoiceClerkstoplist>();
        public ITable<VoiceContextparameter> VoiceContextparameters => this.GetTable<VoiceContextparameter>();
        public ITable<VoiceContext> VoiceContexts => this.GetTable<VoiceContext>();
        public ITable<VoiceDialog> VoiceDialogs => this.GetTable<VoiceDialog>();
        public ITable<VoiceDocumentitem> VoiceDocumentitems => this.GetTable<VoiceDocumentitem>();
        public ITable<VoiceDocumentitemscannedmark> VoiceDocumentitemscannedmarks => this.GetTable<VoiceDocumentitemscannedmark>();
        public ITable<VoiceDocument> VoiceDocuments => this.GetTable<VoiceDocument>();
        public ITable<VoiceEmployee> VoiceEmployees => this.GetTable<VoiceEmployee>();
        public ITable<VoiceGrammaritem> VoiceGrammaritems => this.GetTable<VoiceGrammaritem>();
        public ITable<VoiceGrammar> VoiceGrammars => this.GetTable<VoiceGrammar>();
        public ITable<VoiceInterviewquestionanswer> VoiceInterviewquestionanswers => this.GetTable<VoiceInterviewquestionanswer>();
        public ITable<VoiceInterviewquestion> VoiceInterviewquestions => this.GetTable<VoiceInterviewquestion>();
        public ITable<VoiceInterview> VoiceInterviews => this.GetTable<VoiceInterview>();
        public ITable<VoiceInterviewuseranswer> VoiceInterviewuseranswers => this.GetTable<VoiceInterviewuseranswer>();
        public ITable<VoiceLocation> VoiceLocations => this.GetTable<VoiceLocation>();
        public ITable<VoiceLog> VoiceLogs => this.GetTable<VoiceLog>();
        public ITable<VoiceMethod> VoiceMethods => this.GetTable<VoiceMethod>();
        public ITable<VoiceMethodsargument> VoiceMethodsarguments => this.GetTable<VoiceMethodsargument>();
        public ITable<VoiceNoun> VoiceNouns => this.GetTable<VoiceNoun>();
        public ITable<VoiceObjecttype> VoiceObjecttypes => this.GetTable<VoiceObjecttype>();
        public ITable<VoiceOutgoingruleitemdetail> VoiceOutgoingruleitemdetails => this.GetTable<VoiceOutgoingruleitemdetail>();
        public ITable<VoiceProductbox> VoiceProductboxes => this.GetTable<VoiceProductbox>();
        public ITable<VoiceProductcategory> VoiceProductcategories => this.GetTable<VoiceProductcategory>();
        public ITable<VoiceProductimage> VoiceProductimages => this.GetTable<VoiceProductimage>();
        public ITable<VoiceProductmark> VoiceProductmarks => this.GetTable<VoiceProductmark>();
        public ITable<VoiceProductmarkstatus> VoiceProductmarkstatuses => this.GetTable<VoiceProductmarkstatus>();
        public ITable<VoiceProduct> VoiceProducts => this.GetTable<VoiceProduct>();
        public ITable<VoiceProductseries> VoiceProductseries => this.GetTable<VoiceProductseries>();
        public ITable<VoiceRecognizedphrase> VoiceRecognizedphrases => this.GetTable<VoiceRecognizedphrase>();
        public ITable<VoiceRecruitmentInterval> VoiceRecruitmentIntervals => this.GetTable<VoiceRecruitmentInterval>();
        public ITable<VoiceReplacement> VoiceReplacements => this.GetTable<VoiceReplacement>();
        public ITable<VoiceScript> VoiceScripts => this.GetTable<VoiceScript>();
        public ITable<VoiceScriptsgroup> VoiceScriptsgroups => this.GetTable<VoiceScriptsgroup>();
        public ITable<VoiceScriptsteplink> VoiceScriptsteplinks => this.GetTable<VoiceScriptsteplink>();
        public ITable<VoiceScriptstep> VoiceScriptsteps => this.GetTable<VoiceScriptstep>();
        public ITable<VoiceScriptstepsfreeanswerswitcher> VoiceScriptstepsfreeanswerswitchers => this.GetTable<VoiceScriptstepsfreeanswerswitcher>();
        public ITable<VoiceScriptsversion> VoiceScriptsversions => this.GetTable<VoiceScriptsversion>();
        public ITable<VoiceSettingsparameter> VoiceSettingsparameters => this.GetTable<VoiceSettingsparameter>();
        public ITable<VoiceSettingsparametersvalue> VoiceSettingsparametersvalues => this.GetTable<VoiceSettingsparametersvalue>();
        public ITable<VoiceSignin> VoiceSignins => this.GetTable<VoiceSignin>();
        public ITable<VoiceStepfrequency> VoiceStepfrequencies => this.GetTable<VoiceStepfrequency>();
        public ITable<VoiceSwop> VoiceSwops => this.GetTable<VoiceSwop>();
        public ITable<VoiceSwopsystemobject> VoiceSwopsystemobjects => this.GetTable<VoiceSwopsystemobject>();
        public ITable<VoiceSwopsystem> VoiceSwopsystems => this.GetTable<VoiceSwopsystem>();
        public ITable<VoiceSynthcache> VoiceSynthcaches => this.GetTable<VoiceSynthcache>();
        public ITable<VoiceUnitbarcode> VoiceUnitbarcodes => this.GetTable<VoiceUnitbarcode>();
        public ITable<VoiceUnit> VoiceUnits => this.GetTable<VoiceUnit>();
        public ITable<VoiceUnittype> VoiceUnittypes => this.GetTable<VoiceUnittype>();
        public ITable<VoiceUserrequesttype> VoiceUserrequesttypes => this.GetTable<VoiceUserrequesttype>();
        public ITable<VoiceUserrequesttypesargument> VoiceUserrequesttypesarguments => this.GetTable<VoiceUserrequesttypesargument>();
        public ITable<Way> Ways => this.GetTable<Way>();
        public ITable<Workcalendardayexception> Workcalendardayexceptions => this.GetTable<Workcalendardayexception>();
        public ITable<Workcalendardayrange> Workcalendardayranges => this.GetTable<Workcalendardayrange>();
        public ITable<Workcalendar> Workcalendars => this.GetTable<Workcalendar>();
        public ITable<Время> Времяs => this.GetTable<Время>();
        public ITable<Т13Report> Т13Reports => this.GetTable<Т13Report>();
        public ITable<UvwActionlog> UvwActionlogs => this.GetTable<UvwActionlog>();
        public ITable<UvwLastalivestatus> UvwLastalivestatuses => this.GetTable<UvwLastalivestatus>();
        public ITable<UvwStatushistory> UvwStatushistories => this.GetTable<UvwStatushistory>();
    }

    public static partial class ExtensionMethods
    {
        #region Table Extensions
        public static Absencecandidate? Find(this ITable<Absencecandidate> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Absencecandidate?> FindAsync(this ITable<Absencecandidate> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Absenceclassificationcandidate? Find(this ITable<Absenceclassificationcandidate> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Absenceclassificationcandidate?> FindAsync(this ITable<Absenceclassificationcandidate> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Accessformsforrole? Find(this ITable<Accessformsforrole> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Accessformsforrole?> FindAsync(this ITable<Accessformsforrole> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Accrual? Find(this ITable<Accrual> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Accrual?> FindAsync(this ITable<Accrual> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Activitylogtype? Find(this ITable<Activitylogtype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Activitylogtype?> FindAsync(this ITable<Activitylogtype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static App? Find(this ITable<App> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<App?> FindAsync(this ITable<App> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Appsmask? Find(this ITable<Appsmask> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Appsmask?> FindAsync(this ITable<Appsmask> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Appstype? Find(this ITable<Appstype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Appstype?> FindAsync(this ITable<Appstype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Attachedfile? Find(this ITable<Attachedfile> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Attachedfile?> FindAsync(this ITable<Attachedfile> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static AutoexplanatoryClassificationNotifieduser? Find(this ITable<AutoexplanatoryClassificationNotifieduser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<AutoexplanatoryClassificationNotifieduser?> FindAsync(this ITable<AutoexplanatoryClassificationNotifieduser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BayesArea? Find(this ITable<BayesArea> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BayesArea?> FindAsync(this ITable<BayesArea> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BayesPrimarydatum? Find(this ITable<BayesPrimarydatum> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BayesPrimarydatum?> FindAsync(this ITable<BayesPrimarydatum> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BayesStatistic? Find(this ITable<BayesStatistic> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BayesStatistic?> FindAsync(this ITable<BayesStatistic> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BeizAu? Find(this ITable<BeizAu> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BeizAu?> FindAsync(this ITable<BeizAu> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Blobstorage? Find(this ITable<Blobstorage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Blobstorage?> FindAsync(this ITable<Blobstorage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Blobtempstorage? Find(this ITable<Blobtempstorage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Blobtempstorage?> FindAsync(this ITable<Blobtempstorage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Branch? Find(this ITable<Branch> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Branch?> FindAsync(this ITable<Branch> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BsPhrasesclusteritem? Find(this ITable<BsPhrasesclusteritem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BsPhrasesclusteritem?> FindAsync(this ITable<BsPhrasesclusteritem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BsPhrasescluster? Find(this ITable<BsPhrasescluster> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BsPhrasescluster?> FindAsync(this ITable<BsPhrasescluster> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BsReferencesetting? Find(this ITable<BsReferencesetting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BsReferencesetting?> FindAsync(this ITable<BsReferencesetting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static BsReferencetype? Find(this ITable<BsReferencetype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<BsReferencetype?> FindAsync(this ITable<BsReferencetype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CallcenterAppsetting? Find(this ITable<CallcenterAppsetting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CallcenterAppsetting?> FindAsync(this ITable<CallcenterAppsetting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CallcenterOperatorsinwork? Find(this ITable<CallcenterOperatorsinwork> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CallcenterOperatorsinwork?> FindAsync(this ITable<CallcenterOperatorsinwork> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CallcenterOutgoingruleabonent? Find(this ITable<CallcenterOutgoingruleabonent> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CallcenterOutgoingruleabonent?> FindAsync(this ITable<CallcenterOutgoingruleabonent> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CallcenterOutgoingruleoutgoingline? Find(this ITable<CallcenterOutgoingruleoutgoingline> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CallcenterOutgoingruleoutgoingline?> FindAsync(this ITable<CallcenterOutgoingruleoutgoingline> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CallcenterOutgoingrule? Find(this ITable<CallcenterOutgoingrule> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CallcenterOutgoingrule?> FindAsync(this ITable<CallcenterOutgoingrule> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CallcenterVirtualline? Find(this ITable<CallcenterVirtualline> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CallcenterVirtualline?> FindAsync(this ITable<CallcenterVirtualline> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcentercallstatelog? Find(this ITable<Callcentercallstatelog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcentercallstatelog?> FindAsync(this ITable<Callcentercallstatelog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcentercallstatetimeslot? Find(this ITable<Callcentercallstatetimeslot> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcentercallstatetimeslot?> FindAsync(this ITable<Callcentercallstatetimeslot> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcentercallstatetype? Find(this ITable<Callcentercallstatetype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcentercallstatetype?> FindAsync(this ITable<Callcentercallstatetype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcentergroupcalltype? Find(this ITable<Callcentergroupcalltype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcentergroupcalltype?> FindAsync(this ITable<Callcentergroupcalltype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcenterincomeline? Find(this ITable<Callcenterincomeline> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcenterincomeline?> FindAsync(this ITable<Callcenterincomeline> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcenterivrmenuitem? Find(this ITable<Callcenterivrmenuitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcenterivrmenuitem?> FindAsync(this ITable<Callcenterivrmenuitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcenterivrmenu? Find(this ITable<Callcenterivrmenu> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcenterivrmenu?> FindAsync(this ITable<Callcenterivrmenu> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcenterivrrecordfile? Find(this ITable<Callcenterivrrecordfile> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcenterivrrecordfile?> FindAsync(this ITable<Callcenterivrrecordfile> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcenteroperator? Find(this ITable<Callcenteroperator> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcenteroperator?> FindAsync(this ITable<Callcenteroperator> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcenteroperatorsgroup? Find(this ITable<Callcenteroperatorsgroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcenteroperatorsgroup?> FindAsync(this ITable<Callcenteroperatorsgroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcenteroperatorsingroup? Find(this ITable<Callcenteroperatorsingroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcenteroperatorsingroup?> FindAsync(this ITable<Callcenteroperatorsingroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callcentertelbutton? Find(this ITable<Callcentertelbutton> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callcentertelbutton?> FindAsync(this ITable<Callcentertelbutton> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Callsrecord? Find(this ITable<Callsrecord> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Callsrecord?> FindAsync(this ITable<Callsrecord> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CcPrioritycall? Find(this ITable<CcPrioritycall> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CcPrioritycall?> FindAsync(this ITable<CcPrioritycall> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CcSchedulecall? Find(this ITable<CcSchedulecall> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CcSchedulecall?> FindAsync(this ITable<CcSchedulecall> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CcStatecall? Find(this ITable<CcStatecall> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CcStatecall?> FindAsync(this ITable<CcStatecall> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CcUnsuccessfulcall? Find(this ITable<CcUnsuccessfulcall> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CcUnsuccessfulcall?> FindAsync(this ITable<CcUnsuccessfulcall> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ChatActivity? Find(this ITable<ChatActivity> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ChatActivity?> FindAsync(this ITable<ChatActivity> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ChatActivityattachment? Find(this ITable<ChatActivityattachment> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ChatActivityattachment?> FindAsync(this ITable<ChatActivityattachment> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Cleartablessetting? Find(this ITable<Cleartablessetting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Cleartablessetting?> FindAsync(this ITable<Cleartablessetting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ClipboardContent? Find(this ITable<ClipboardContent> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ClipboardContent?> FindAsync(this ITable<ClipboardContent> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static CommonSetting? Find(this ITable<CommonSetting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<CommonSetting?> FindAsync(this ITable<CommonSetting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsAccount? Find(this ITable<ConnectorsAccount> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsAccount?> FindAsync(this ITable<ConnectorsAccount> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsClasstimesync? Find(this ITable<ConnectorsClasstimesync> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsClasstimesync?> FindAsync(this ITable<ConnectorsClasstimesync> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsExchangedirection? Find(this ITable<ConnectorsExchangedirection> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsExchangedirection?> FindAsync(this ITable<ConnectorsExchangedirection> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsExchangeitem? Find(this ITable<ConnectorsExchangeitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsExchangeitem?> FindAsync(this ITable<ConnectorsExchangeitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsExchangelog? Find(this ITable<ConnectorsExchangelog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsExchangelog?> FindAsync(this ITable<ConnectorsExchangelog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsGrpcconnection? Find(this ITable<ConnectorsGrpcconnection> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsGrpcconnection?> FindAsync(this ITable<ConnectorsGrpcconnection> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsObjectidentity? Find(this ITable<ConnectorsObjectidentity> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsObjectidentity?> FindAsync(this ITable<ConnectorsObjectidentity> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsProduct? Find(this ITable<ConnectorsProduct> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsProduct?> FindAsync(this ITable<ConnectorsProduct> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConnectorsSetting? Find(this ITable<ConnectorsSetting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConnectorsSetting?> FindAsync(this ITable<ConnectorsSetting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleContact? Find(this ITable<ConsoleContact> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleContact?> FindAsync(this ITable<ConsoleContact> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleContactsemail? Find(this ITable<ConsoleContactsemail> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleContactsemail?> FindAsync(this ITable<ConsoleContactsemail> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleContactsgroup? Find(this ITable<ConsoleContactsgroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleContactsgroup?> FindAsync(this ITable<ConsoleContactsgroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleContactsgroupsmember? Find(this ITable<ConsoleContactsgroupsmember> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleContactsgroupsmember?> FindAsync(this ITable<ConsoleContactsgroupsmember> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleContactsphone? Find(this ITable<ConsoleContactsphone> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleContactsphone?> FindAsync(this ITable<ConsoleContactsphone> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleEventhistory? Find(this ITable<ConsoleEventhistory> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleEventhistory?> FindAsync(this ITable<ConsoleEventhistory> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleEventresulttype? Find(this ITable<ConsoleEventresulttype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleEventresulttype?> FindAsync(this ITable<ConsoleEventresulttype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleEventtype? Find(this ITable<ConsoleEventtype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleEventtype?> FindAsync(this ITable<ConsoleEventtype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleUser? Find(this ITable<ConsoleUser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleUser?> FindAsync(this ITable<ConsoleUser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleUserscontactsgroup? Find(this ITable<ConsoleUserscontactsgroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleUserscontactsgroup?> FindAsync(this ITable<ConsoleUserscontactsgroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleUserscontactsgroupsmember? Find(this ITable<ConsoleUserscontactsgroupsmember> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleUserscontactsgroupsmember?> FindAsync(this ITable<ConsoleUserscontactsgroupsmember> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ConsoleUserscontactsperson? Find(this ITable<ConsoleUserscontactsperson> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ConsoleUserscontactsperson?> FindAsync(this ITable<ConsoleUserscontactsperson> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Constant? Find(this ITable<Constant> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Constant?> FindAsync(this ITable<Constant> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Cweinstallation? Find(this ITable<Cweinstallation> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Cweinstallation?> FindAsync(this ITable<Cweinstallation> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DctLemmaresult? Find(this ITable<DctLemmaresult> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DctLemmaresult?> FindAsync(this ITable<DctLemmaresult> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Departmentincidentassigneduser? Find(this ITable<Departmentincidentassigneduser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Departmentincidentassigneduser?> FindAsync(this ITable<Departmentincidentassigneduser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Departmentnotifychannel? Find(this ITable<Departmentnotifychannel> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Departmentnotifychannel?> FindAsync(this ITable<Departmentnotifychannel> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Departmentnotifyuser? Find(this ITable<Departmentnotifyuser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Departmentnotifyuser?> FindAsync(this ITable<Departmentnotifyuser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Department? Find(this ITable<Department> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Department?> FindAsync(this ITable<Department> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Departmentssetting? Find(this ITable<Departmentssetting> table, Guid deptid)
        {
            return table.FirstOrDefault(e => e.Deptid == deptid);
        }

        public static Task<Departmentssetting?> FindAsync(this ITable<Departmentssetting> table, Guid deptid, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Deptid == deptid, cancellationToken);
        }

        public static Discount? Find(this ITable<Discount> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Discount?> FindAsync(this ITable<Discount> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DwhCcCallstime? Find(this ITable<DwhCcCallstime> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DwhCcCallstime?> FindAsync(this ITable<DwhCcCallstime> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DwhMetric? Find(this ITable<DwhMetric> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DwhMetric?> FindAsync(this ITable<DwhMetric> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DwhMetricsAlertslog? Find(this ITable<DwhMetricsAlertslog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DwhMetricsAlertslog?> FindAsync(this ITable<DwhMetricsAlertslog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DwhMetricsgroup? Find(this ITable<DwhMetricsgroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DwhMetricsgroup?> FindAsync(this ITable<DwhMetricsgroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DwhMetricsoperand? Find(this ITable<DwhMetricsoperand> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DwhMetricsoperand?> FindAsync(this ITable<DwhMetricsoperand> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DwhMetricsoperandsVoiceCheckpoint? Find(this ITable<DwhMetricsoperandsVoiceCheckpoint> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DwhMetricsoperandsVoiceCheckpoint?> FindAsync(this ITable<DwhMetricsoperandsVoiceCheckpoint> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static DwhPhraseclusterDialog? Find(this ITable<DwhPhraseclusterDialog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<DwhPhraseclusterDialog?> FindAsync(this ITable<DwhPhraseclusterDialog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Exclog? Find(this ITable<Exclog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Exclog?> FindAsync(this ITable<Exclog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ExportResource? Find(this ITable<ExportResource> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ExportResource?> FindAsync(this ITable<ExportResource> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Frequencyincidentresolution? Find(this ITable<Frequencyincidentresolution> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Frequencyincidentresolution?> FindAsync(this ITable<Frequencyincidentresolution> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static GoodsBrand? Find(this ITable<GoodsBrand> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<GoodsBrand?> FindAsync(this ITable<GoodsBrand> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static GoodsGood? Find(this ITable<GoodsGood> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<GoodsGood?> FindAsync(this ITable<GoodsGood> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static GoodsGoodschemeattribute? Find(this ITable<GoodsGoodschemeattribute> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<GoodsGoodschemeattribute?> FindAsync(this ITable<GoodsGoodschemeattribute> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static GoodsWordprocessing? Find(this ITable<GoodsWordprocessing> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<GoodsWordprocessing?> FindAsync(this ITable<GoodsWordprocessing> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Group? Find(this ITable<Group> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Group?> FindAsync(this ITable<Group> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Groupsmember? Find(this ITable<Groupsmember> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Groupsmember?> FindAsync(this ITable<Groupsmember> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentattribute? Find(this ITable<Guiincidentattribute> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentattribute?> FindAsync(this ITable<Guiincidentattribute> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentattributesondynamicscontainer? Find(this ITable<Guiincidentattributesondynamicscontainer> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentattributesondynamicscontainer?> FindAsync(this ITable<Guiincidentattributesondynamicscontainer> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentbuttonenabledattribute? Find(this ITable<Guiincidentbuttonenabledattribute> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentbuttonenabledattribute?> FindAsync(this ITable<Guiincidentbuttonenabledattribute> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentbutton? Find(this ITable<Guiincidentbutton> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentbutton?> FindAsync(this ITable<Guiincidentbutton> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentbuttonsetattribute? Find(this ITable<Guiincidentbuttonsetattribute> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentbuttonsetattribute?> FindAsync(this ITable<Guiincidentbuttonsetattribute> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentbuttonsondynamicscontainer? Find(this ITable<Guiincidentbuttonsondynamicscontainer> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentbuttonsondynamicscontainer?> FindAsync(this ITable<Guiincidentbuttonsondynamicscontainer> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentdynamicscontainer? Find(this ITable<Guiincidentdynamicscontainer> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentdynamicscontainer?> FindAsync(this ITable<Guiincidentdynamicscontainer> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentform? Find(this ITable<Guiincidentform> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentform?> FindAsync(this ITable<Guiincidentform> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentgridattributecolumn? Find(this ITable<Guiincidentgridattributecolumn> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentgridattributecolumn?> FindAsync(this ITable<Guiincidentgridattributecolumn> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentgridcalccolumn? Find(this ITable<Guiincidentgridcalccolumn> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentgridcalccolumn?> FindAsync(this ITable<Guiincidentgridcalccolumn> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentscript? Find(this ITable<Guiincidentscript> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentscript?> FindAsync(this ITable<Guiincidentscript> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidenttattributesonform? Find(this ITable<Guiincidenttattributesonform> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidenttattributesonform?> FindAsync(this ITable<Guiincidenttattributesonform> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentuserattributecontroltype? Find(this ITable<Guiincidentuserattributecontroltype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentuserattributecontroltype?> FindAsync(this ITable<Guiincidentuserattributecontroltype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentuserattribute? Find(this ITable<Guiincidentuserattribute> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentuserattribute?> FindAsync(this ITable<Guiincidentuserattribute> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentuserattributesourceparam? Find(this ITable<Guiincidentuserattributesourceparam> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentuserattributesourceparam?> FindAsync(this ITable<Guiincidentuserattributesourceparam> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentuserattributesourcetype? Find(this ITable<Guiincidentuserattributesourcetype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentuserattributesourcetype?> FindAsync(this ITable<Guiincidentuserattributesourcetype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Guiincidentuserattributetype? Find(this ITable<Guiincidentuserattributetype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Guiincidentuserattributetype?> FindAsync(this ITable<Guiincidentuserattributetype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrCandidateonstagingitemstatus? Find(this ITable<HrCandidateonstagingitemstatus> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrCandidateonstagingitemstatus?> FindAsync(this ITable<HrCandidateonstagingitemstatus> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrCandidateonstepstatus? Find(this ITable<HrCandidateonstepstatus> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrCandidateonstepstatus?> FindAsync(this ITable<HrCandidateonstepstatus> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrCandidateratingstatus? Find(this ITable<HrCandidateratingstatus> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrCandidateratingstatus?> FindAsync(this ITable<HrCandidateratingstatus> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrEmploymentcandidatesonstagingitem? Find(this ITable<HrEmploymentcandidatesonstagingitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrEmploymentcandidatesonstagingitem?> FindAsync(this ITable<HrEmploymentcandidatesonstagingitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrEmployment? Find(this ITable<HrEmployment> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrEmployment?> FindAsync(this ITable<HrEmployment> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrEmploymentsearchcandidate? Find(this ITable<HrEmploymentsearchcandidate> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrEmploymentsearchcandidate?> FindAsync(this ITable<HrEmploymentsearchcandidate> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrEmploymentsearchresult? Find(this ITable<HrEmploymentsearchresult> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrEmploymentsearchresult?> FindAsync(this ITable<HrEmploymentsearchresult> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrReferenceitem? Find(this ITable<HrReferenceitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrReferenceitem?> FindAsync(this ITable<HrReferenceitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrReferencetype? Find(this ITable<HrReferencetype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrReferencetype?> FindAsync(this ITable<HrReferencetype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrStagingemploymentitemhrcoworker? Find(this ITable<HrStagingemploymentitemhrcoworker> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrStagingemploymentitemhrcoworker?> FindAsync(this ITable<HrStagingemploymentitemhrcoworker> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrStagingemploymentitem? Find(this ITable<HrStagingemploymentitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrStagingemploymentitem?> FindAsync(this ITable<HrStagingemploymentitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static HrStagingemployment? Find(this ITable<HrStagingemployment> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<HrStagingemployment?> FindAsync(this ITable<HrStagingemployment> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Languagecode? Find(this ITable<Languagecode> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Languagecode?> FindAsync(this ITable<Languagecode> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Localizedtext? Find(this ITable<Localizedtext> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Localizedtext?> FindAsync(this ITable<Localizedtext> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static LogObjectsprocess? Find(this ITable<LogObjectsprocess> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<LogObjectsprocess?> FindAsync(this ITable<LogObjectsprocess> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static LogsObjectstype? Find(this ITable<LogsObjectstype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<LogsObjectstype?> FindAsync(this ITable<LogsObjectstype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static LogsTransactiontype? Find(this ITable<LogsTransactiontype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<LogsTransactiontype?> FindAsync(this ITable<LogsTransactiontype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static LogsVisitsobjectsbyuser? Find(this ITable<LogsVisitsobjectsbyuser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<LogsVisitsobjectsbyuser?> FindAsync(this ITable<LogsVisitsobjectsbyuser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static MonitoringDeviceparam? Find(this ITable<MonitoringDeviceparam> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<MonitoringDeviceparam?> FindAsync(this ITable<MonitoringDeviceparam> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static MonitoringDevice? Find(this ITable<MonitoringDevice> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<MonitoringDevice?> FindAsync(this ITable<MonitoringDevice> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static MonitoringDevicestype? Find(this ITable<MonitoringDevicestype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<MonitoringDevicestype?> FindAsync(this ITable<MonitoringDevicestype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static MonitoringEventslog? Find(this ITable<MonitoringEventslog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<MonitoringEventslog?> FindAsync(this ITable<MonitoringEventslog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static MonitoringStatuslog? Find(this ITable<MonitoringStatuslog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<MonitoringStatuslog?> FindAsync(this ITable<MonitoringStatuslog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static NotificationserviceDistributiongroup? Find(this ITable<NotificationserviceDistributiongroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<NotificationserviceDistributiongroup?> FindAsync(this ITable<NotificationserviceDistributiongroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static NotificationserviceDistributiongroupsmember? Find(this ITable<NotificationserviceDistributiongroupsmember> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<NotificationserviceDistributiongroupsmember?> FindAsync(this ITable<NotificationserviceDistributiongroupsmember> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static NotificationserviceMessage? Find(this ITable<NotificationserviceMessage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<NotificationserviceMessage?> FindAsync(this ITable<NotificationserviceMessage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static NotificationserviceQueue? Find(this ITable<NotificationserviceQueue> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<NotificationserviceQueue?> FindAsync(this ITable<NotificationserviceQueue> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Notifychannel? Find(this ITable<Notifychannel> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Notifychannel?> FindAsync(this ITable<Notifychannel> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Objectpermission? Find(this ITable<Objectpermission> table, Guid objectid, string objecttype, Guid usergroupid)
        {
            return table.FirstOrDefault(e => e.Objectid == objectid && e.Objecttype == objecttype && e.Usergroupid == usergroupid);
        }

        public static Task<Objectpermission?> FindAsync(this ITable<Objectpermission> table, Guid objectid, string objecttype, Guid usergroupid, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Objectid == objectid && e.Objecttype == objecttype && e.Usergroupid == usergroupid, cancellationToken);
        }

        public static Otheremailsbyuser? Find(this ITable<Otheremailsbyuser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Otheremailsbyuser?> FindAsync(this ITable<Otheremailsbyuser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Otherphonesbyuser? Find(this ITable<Otherphonesbyuser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Otherphonesbyuser?> FindAsync(this ITable<Otherphonesbyuser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Pitstate? Find(this ITable<Pitstate> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Pitstate?> FindAsync(this ITable<Pitstate> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Queue? Find(this ITable<Queue> table, Guid rid)
        {
            return table.FirstOrDefault(e => e.Rid == rid);
        }

        public static Task<Queue?> FindAsync(this ITable<Queue> table, Guid rid, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Rid == rid, cancellationToken);
        }

        public static Region? Find(this ITable<Region> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Region?> FindAsync(this ITable<Region> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Relatedincidentandcall? Find(this ITable<Relatedincidentandcall> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Relatedincidentandcall?> FindAsync(this ITable<Relatedincidentandcall> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ReportsEnabledcustomreport? Find(this ITable<ReportsEnabledcustomreport> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ReportsEnabledcustomreport?> FindAsync(this ITable<ReportsEnabledcustomreport> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ReportsExternalreport? Find(this ITable<ReportsExternalreport> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ReportsExternalreport?> FindAsync(this ITable<ReportsExternalreport> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Role? Find(this ITable<Role> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Role?> FindAsync(this ITable<Role> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Rolesmember? Find(this ITable<Rolesmember> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Rolesmember?> FindAsync(this ITable<Rolesmember> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Schemaversion? Find(this ITable<Schemaversion> table, int schemaversionsid)
        {
            return table.FirstOrDefault(e => e.Schemaversionsid == schemaversionsid);
        }

        public static Task<Schemaversion?> FindAsync(this ITable<Schemaversion> table, int schemaversionsid, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Schemaversionsid == schemaversionsid, cancellationToken);
        }

        public static Script? Find(this ITable<Script> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Script?> FindAsync(this ITable<Script> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdEntitieschangelog? Find(this ITable<SdEntitieschangelog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdEntitieschangelog?> FindAsync(this ITable<SdEntitieschangelog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdEntitytype? Find(this ITable<SdEntitytype> table, int id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdEntitytype?> FindAsync(this ITable<SdEntitytype> table, int id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdExchangeEventtype? Find(this ITable<SdExchangeEventtype> table, int id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdExchangeEventtype?> FindAsync(this ITable<SdExchangeEventtype> table, int id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdExchangelog? Find(this ITable<SdExchangelog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdExchangelog?> FindAsync(this ITable<SdExchangelog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdExchangeout? Find(this ITable<SdExchangeout> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdExchangeout?> FindAsync(this ITable<SdExchangeout> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdKnowledgearticle? Find(this ITable<SdKnowledgearticle> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdKnowledgearticle?> FindAsync(this ITable<SdKnowledgearticle> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdKnowledgearticlesFolder? Find(this ITable<SdKnowledgearticlesFolder> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdKnowledgearticlesFolder?> FindAsync(this ITable<SdKnowledgearticlesFolder> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdSetting? Find(this ITable<SdSetting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdSetting?> FindAsync(this ITable<SdSetting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdSla? Find(this ITable<SdSla> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdSla?> FindAsync(this ITable<SdSla> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdSlaColor? Find(this ITable<SdSlaColor> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdSlaColor?> FindAsync(this ITable<SdSlaColor> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdSlaMetric? Find(this ITable<SdSlaMetric> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdSlaMetric?> FindAsync(this ITable<SdSlaMetric> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdSlaSlacategoryitem? Find(this ITable<SdSlaSlacategoryitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdSlaSlacategoryitem?> FindAsync(this ITable<SdSlaSlacategoryitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdSlaSlametricitem? Find(this ITable<SdSlaSlametricitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdSlaSlametricitem?> FindAsync(this ITable<SdSlaSlametricitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdTierqueuesenummember? Find(this ITable<SdTierqueuesenummember> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdTierqueuesenummember?> FindAsync(this ITable<SdTierqueuesenummember> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWebrequest? Find(this ITable<SdWebrequest> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWebrequest?> FindAsync(this ITable<SdWebrequest> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemColor? Find(this ITable<SdWorkitemColor> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemColor?> FindAsync(this ITable<SdWorkitemColor> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemComment? Find(this ITable<SdWorkitemComment> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemComment?> FindAsync(this ITable<SdWorkitemComment> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemCommentsauthortype? Find(this ITable<SdWorkitemCommentsauthortype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemCommentsauthortype?> FindAsync(this ITable<SdWorkitemCommentsauthortype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemCommentstype? Find(this ITable<SdWorkitemCommentstype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemCommentstype?> FindAsync(this ITable<SdWorkitemCommentstype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemConditionsforsendingsm? Find(this ITable<SdWorkitemConditionsforsendingsm> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemConditionsforsendingsm?> FindAsync(this ITable<SdWorkitemConditionsforsendingsm> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemElapsedtime? Find(this ITable<SdWorkitemElapsedtime> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemElapsedtime?> FindAsync(this ITable<SdWorkitemElapsedtime> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemEnum? Find(this ITable<SdWorkitemEnum> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemEnum?> FindAsync(this ITable<SdWorkitemEnum> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemEnumtype? Find(this ITable<SdWorkitemEnumtype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemEnumtype?> FindAsync(this ITable<SdWorkitemEnumtype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemIncident? Find(this ITable<SdWorkitemIncident> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemIncident?> FindAsync(this ITable<SdWorkitemIncident> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemListingsetting? Find(this ITable<SdWorkitemListingsetting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemListingsetting?> FindAsync(this ITable<SdWorkitemListingsetting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemRelatedknowledgearticle? Find(this ITable<SdWorkitemRelatedknowledgearticle> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemRelatedknowledgearticle?> FindAsync(this ITable<SdWorkitemRelatedknowledgearticle> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemSourceitem? Find(this ITable<SdWorkitemSourceitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemSourceitem?> FindAsync(this ITable<SdWorkitemSourceitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemsFactsla? Find(this ITable<SdWorkitemsFactsla> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemsFactsla?> FindAsync(this ITable<SdWorkitemsFactsla> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static SdWorkitemsSla? Find(this ITable<SdWorkitemsSla> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SdWorkitemsSla?> FindAsync(this ITable<SdWorkitemsSla> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ServicedeskSmsintegrationNotificationqueue? Find(this ITable<ServicedeskSmsintegrationNotificationqueue> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ServicedeskSmsintegrationNotificationqueue?> FindAsync(this ITable<ServicedeskSmsintegrationNotificationqueue> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Settingschangelog? Find(this ITable<Settingschangelog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Settingschangelog?> FindAsync(this ITable<Settingschangelog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Signatureuser? Find(this ITable<Signatureuser> table, Guid userid)
        {
            return table.FirstOrDefault(e => e.Userid == userid);
        }

        public static Task<Signatureuser?> FindAsync(this ITable<Signatureuser> table, Guid userid, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Userid == userid, cancellationToken);
        }

        public static SmsOperation? Find(this ITable<SmsOperation> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<SmsOperation?> FindAsync(this ITable<SmsOperation> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Solution? Find(this ITable<Solution> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Solution?> FindAsync(this ITable<Solution> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Textmessage? Find(this ITable<Textmessage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Textmessage?> FindAsync(this ITable<Textmessage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static TimemanagementSchedule? Find(this ITable<TimemanagementSchedule> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<TimemanagementSchedule?> FindAsync(this ITable<TimemanagementSchedule> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static TimemanagementScheduleOffice? Find(this ITable<TimemanagementScheduleOffice> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<TimemanagementScheduleOffice?> FindAsync(this ITable<TimemanagementScheduleOffice> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static TimemanagementScheduleOfficeroleassignment? Find(this ITable<TimemanagementScheduleOfficeroleassignment> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<TimemanagementScheduleOfficeroleassignment?> FindAsync(this ITable<TimemanagementScheduleOfficeroleassignment> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static TimemanagementScheduleRole? Find(this ITable<TimemanagementScheduleRole> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<TimemanagementScheduleRole?> FindAsync(this ITable<TimemanagementScheduleRole> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static TimemanagementScheduleWorkday? Find(this ITable<TimemanagementScheduleWorkday> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<TimemanagementScheduleWorkday?> FindAsync(this ITable<TimemanagementScheduleWorkday> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static TimemanagementScheduleassignment? Find(this ITable<TimemanagementScheduleassignment> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<TimemanagementScheduleassignment?> FindAsync(this ITable<TimemanagementScheduleassignment> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Trustedapp? Find(this ITable<Trustedapp> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Trustedapp?> FindAsync(this ITable<Trustedapp> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static UiPagegroup? Find(this ITable<UiPagegroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<UiPagegroup?> FindAsync(this ITable<UiPagegroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static UiPage? Find(this ITable<UiPage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<UiPage?> FindAsync(this ITable<UiPage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static UiPagesingroup? Find(this ITable<UiPagesingroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<UiPagesingroup?> FindAsync(this ITable<UiPagesingroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static UiRoleaccesstopage? Find(this ITable<UiRoleaccesstopage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<UiRoleaccesstopage?> FindAsync(this ITable<UiRoleaccesstopage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usercontact? Find(this ITable<Usercontact> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usercontact?> FindAsync(this ITable<Usercontact> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usercontacttype? Find(this ITable<Usercontacttype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usercontacttype?> FindAsync(this ITable<Usercontacttype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usernotification? Find(this ITable<Usernotification> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usernotification?> FindAsync(this ITable<Usernotification> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usernotificationsmacrose? Find(this ITable<Usernotificationsmacrose> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usernotificationsmacrose?> FindAsync(this ITable<Usernotificationsmacrose> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usernotificationssendedbychannel? Find(this ITable<Usernotificationssendedbychannel> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usernotificationssendedbychannel?> FindAsync(this ITable<Usernotificationssendedbychannel> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usernotificationstemplate? Find(this ITable<Usernotificationstemplate> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usernotificationstemplate?> FindAsync(this ITable<Usernotificationstemplate> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usernotificationstemplatesonbackgroundtask? Find(this ITable<Usernotificationstemplatesonbackgroundtask> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usernotificationstemplatesonbackgroundtask?> FindAsync(this ITable<Usernotificationstemplatesonbackgroundtask> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usernotificationstemplatesview? Find(this ITable<Usernotificationstemplatesview> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usernotificationstemplatesview?> FindAsync(this ITable<Usernotificationstemplatesview> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Usernotifychannel? Find(this ITable<Usernotifychannel> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Usernotifychannel?> FindAsync(this ITable<Usernotifychannel> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static User? Find(this ITable<User> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<User?> FindAsync(this ITable<User> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static UsersProperty? Find(this ITable<UsersProperty> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<UsersProperty?> FindAsync(this ITable<UsersProperty> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViAvitochatstatus? Find(this ITable<ViAvitochatstatus> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViAvitochatstatus?> FindAsync(this ITable<ViAvitochatstatus> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViCall? Find(this ITable<ViCall> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViCall?> FindAsync(this ITable<ViCall> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatactivityattachment? Find(this ITable<ViChatactivityattachment> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatactivityattachment?> FindAsync(this ITable<ViChatactivityattachment> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatloading? Find(this ITable<ViChatloading> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatloading?> FindAsync(this ITable<ViChatloading> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatlog? Find(this ITable<ViChatlog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatlog?> FindAsync(this ITable<ViChatlog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatlogtype? Find(this ITable<ViChatlogtype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatlogtype?> FindAsync(this ITable<ViChatlogtype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatoperatorslog? Find(this ITable<ViChatoperatorslog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatoperatorslog?> FindAsync(this ITable<ViChatoperatorslog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatoperatorsstatus? Find(this ITable<ViChatoperatorsstatus> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatoperatorsstatus?> FindAsync(this ITable<ViChatoperatorsstatus> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatplatform? Find(this ITable<ViChatplatform> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatplatform?> FindAsync(this ITable<ViChatplatform> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatrequest? Find(this ITable<ViChatrequest> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatrequest?> FindAsync(this ITable<ViChatrequest> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatrichmediatemplate? Find(this ITable<ViChatrichmediatemplate> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatrichmediatemplate?> FindAsync(this ITable<ViChatrichmediatemplate> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatrichmediatemplatesbyplatform? Find(this ITable<ViChatrichmediatemplatesbyplatform> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatrichmediatemplatesbyplatform?> FindAsync(this ITable<ViChatrichmediatemplatesbyplatform> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChatsystemmessage? Find(this ITable<ViChatsystemmessage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChatsystemmessage?> FindAsync(this ITable<ViChatsystemmessage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViChattimeout? Find(this ITable<ViChattimeout> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViChattimeout?> FindAsync(this ITable<ViChattimeout> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViCheckpoint? Find(this ITable<ViCheckpoint> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViCheckpoint?> FindAsync(this ITable<ViCheckpoint> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViClassificationstatistic? Find(this ITable<ViClassificationstatistic> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViClassificationstatistic?> FindAsync(this ITable<ViClassificationstatistic> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViExternalresource? Find(this ITable<ViExternalresource> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViExternalresource?> FindAsync(this ITable<ViExternalresource> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViNotificationbychannel? Find(this ITable<ViNotificationbychannel> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViNotificationbychannel?> FindAsync(this ITable<ViNotificationbychannel> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViNotificationbyuser? Find(this ITable<ViNotificationbyuser> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViNotificationbyuser?> FindAsync(this ITable<ViNotificationbyuser> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViNotification? Find(this ITable<ViNotification> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViNotification?> FindAsync(this ITable<ViNotification> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViNotificationsendedbysession? Find(this ITable<ViNotificationsendedbysession> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViNotificationsendedbysession?> FindAsync(this ITable<ViNotificationsendedbysession> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViObjectschemeAttributeValue? Find(this ITable<ViObjectschemeAttributeValue> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViObjectschemeAttributeValue?> FindAsync(this ITable<ViObjectschemeAttributeValue> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViObjectschemeAttribute? Find(this ITable<ViObjectschemeAttribute> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViObjectschemeAttribute?> FindAsync(this ITable<ViObjectschemeAttribute> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViObjectscheme? Find(this ITable<ViObjectscheme> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViObjectscheme?> FindAsync(this ITable<ViObjectscheme> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViPlatformlog? Find(this ITable<ViPlatformlog> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViPlatformlog?> FindAsync(this ITable<ViPlatformlog> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViScriptbychannel? Find(this ITable<ViScriptbychannel> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViScriptbychannel?> FindAsync(this ITable<ViScriptbychannel> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViSessionchannel? Find(this ITable<ViSessionchannel> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViSessionchannel?> FindAsync(this ITable<ViSessionchannel> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViSessionrelation? Find(this ITable<ViSessionrelation> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViSessionrelation?> FindAsync(this ITable<ViSessionrelation> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static ViSessiontype? Find(this ITable<ViSessiontype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<ViSessiontype?> FindAsync(this ITable<ViSessiontype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAbonentaccountingtype? Find(this ITable<VoiceAbonentaccountingtype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAbonentaccountingtype?> FindAsync(this ITable<VoiceAbonentaccountingtype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAbonentaddress? Find(this ITable<VoiceAbonentaddress> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAbonentaddress?> FindAsync(this ITable<VoiceAbonentaddress> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAbonentdebt? Find(this ITable<VoiceAbonentdebt> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAbonentdebt?> FindAsync(this ITable<VoiceAbonentdebt> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAbonentdevicerate? Find(this ITable<VoiceAbonentdevicerate> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAbonentdevicerate?> FindAsync(this ITable<VoiceAbonentdevicerate> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAbonentdeviceratetype? Find(this ITable<VoiceAbonentdeviceratetype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAbonentdeviceratetype?> FindAsync(this ITable<VoiceAbonentdeviceratetype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAbonentdevice? Find(this ITable<VoiceAbonentdevice> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAbonentdevice?> FindAsync(this ITable<VoiceAbonentdevice> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAbonent? Find(this ITable<VoiceAbonent> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAbonent?> FindAsync(this ITable<VoiceAbonent> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAppsetting? Find(this ITable<VoiceAppsetting> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAppsetting?> FindAsync(this ITable<VoiceAppsetting> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceAtm? Find(this ITable<VoiceAtm> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceAtm?> FindAsync(this ITable<VoiceAtm> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceBilling? Find(this ITable<VoiceBilling> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceBilling?> FindAsync(this ITable<VoiceBilling> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceBingcache? Find(this ITable<VoiceBingcache> table, int id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceBingcache?> FindAsync(this ITable<VoiceBingcache> table, int id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceCellblockingreason? Find(this ITable<VoiceCellblockingreason> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceCellblockingreason?> FindAsync(this ITable<VoiceCellblockingreason> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceCell? Find(this ITable<VoiceCell> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceCell?> FindAsync(this ITable<VoiceCell> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceClerkstoplist? Find(this ITable<VoiceClerkstoplist> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceClerkstoplist?> FindAsync(this ITable<VoiceClerkstoplist> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceContextparameter? Find(this ITable<VoiceContextparameter> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceContextparameter?> FindAsync(this ITable<VoiceContextparameter> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceDialog? Find(this ITable<VoiceDialog> table, long id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceDialog?> FindAsync(this ITable<VoiceDialog> table, long id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceDocumentitem? Find(this ITable<VoiceDocumentitem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceDocumentitem?> FindAsync(this ITable<VoiceDocumentitem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceDocumentitemscannedmark? Find(this ITable<VoiceDocumentitemscannedmark> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceDocumentitemscannedmark?> FindAsync(this ITable<VoiceDocumentitemscannedmark> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceDocument? Find(this ITable<VoiceDocument> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceDocument?> FindAsync(this ITable<VoiceDocument> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceEmployee? Find(this ITable<VoiceEmployee> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceEmployee?> FindAsync(this ITable<VoiceEmployee> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceGrammaritem? Find(this ITable<VoiceGrammaritem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceGrammaritem?> FindAsync(this ITable<VoiceGrammaritem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceGrammar? Find(this ITable<VoiceGrammar> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceGrammar?> FindAsync(this ITable<VoiceGrammar> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceInterviewquestionanswer? Find(this ITable<VoiceInterviewquestionanswer> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceInterviewquestionanswer?> FindAsync(this ITable<VoiceInterviewquestionanswer> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceInterviewquestion? Find(this ITable<VoiceInterviewquestion> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceInterviewquestion?> FindAsync(this ITable<VoiceInterviewquestion> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceInterview? Find(this ITable<VoiceInterview> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceInterview?> FindAsync(this ITable<VoiceInterview> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceInterviewuseranswer? Find(this ITable<VoiceInterviewuseranswer> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceInterviewuseranswer?> FindAsync(this ITable<VoiceInterviewuseranswer> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceLocation? Find(this ITable<VoiceLocation> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceLocation?> FindAsync(this ITable<VoiceLocation> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceMethod? Find(this ITable<VoiceMethod> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceMethod?> FindAsync(this ITable<VoiceMethod> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceMethodsargument? Find(this ITable<VoiceMethodsargument> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceMethodsargument?> FindAsync(this ITable<VoiceMethodsargument> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceNoun? Find(this ITable<VoiceNoun> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceNoun?> FindAsync(this ITable<VoiceNoun> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceObjecttype? Find(this ITable<VoiceObjecttype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceObjecttype?> FindAsync(this ITable<VoiceObjecttype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceProductbox? Find(this ITable<VoiceProductbox> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceProductbox?> FindAsync(this ITable<VoiceProductbox> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceProductcategory? Find(this ITable<VoiceProductcategory> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceProductcategory?> FindAsync(this ITable<VoiceProductcategory> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceProductimage? Find(this ITable<VoiceProductimage> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceProductimage?> FindAsync(this ITable<VoiceProductimage> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceProductmark? Find(this ITable<VoiceProductmark> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceProductmark?> FindAsync(this ITable<VoiceProductmark> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceProductmarkstatus? Find(this ITable<VoiceProductmarkstatus> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceProductmarkstatus?> FindAsync(this ITable<VoiceProductmarkstatus> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceProduct? Find(this ITable<VoiceProduct> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceProduct?> FindAsync(this ITable<VoiceProduct> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceProductseries? Find(this ITable<VoiceProductseries> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceProductseries?> FindAsync(this ITable<VoiceProductseries> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceRecognizedphrase? Find(this ITable<VoiceRecognizedphrase> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceRecognizedphrase?> FindAsync(this ITable<VoiceRecognizedphrase> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceRecruitmentInterval? Find(this ITable<VoiceRecruitmentInterval> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceRecruitmentInterval?> FindAsync(this ITable<VoiceRecruitmentInterval> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceReplacement? Find(this ITable<VoiceReplacement> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceReplacement?> FindAsync(this ITable<VoiceReplacement> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceScript? Find(this ITable<VoiceScript> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceScript?> FindAsync(this ITable<VoiceScript> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceScriptsgroup? Find(this ITable<VoiceScriptsgroup> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceScriptsgroup?> FindAsync(this ITable<VoiceScriptsgroup> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceScriptsteplink? Find(this ITable<VoiceScriptsteplink> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceScriptsteplink?> FindAsync(this ITable<VoiceScriptsteplink> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceScriptstep? Find(this ITable<VoiceScriptstep> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceScriptstep?> FindAsync(this ITable<VoiceScriptstep> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceScriptstepsfreeanswerswitcher? Find(this ITable<VoiceScriptstepsfreeanswerswitcher> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceScriptstepsfreeanswerswitcher?> FindAsync(this ITable<VoiceScriptstepsfreeanswerswitcher> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceSettingsparameter? Find(this ITable<VoiceSettingsparameter> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceSettingsparameter?> FindAsync(this ITable<VoiceSettingsparameter> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceSettingsparametersvalue? Find(this ITable<VoiceSettingsparametersvalue> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceSettingsparametersvalue?> FindAsync(this ITable<VoiceSettingsparametersvalue> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceStepfrequency? Find(this ITable<VoiceStepfrequency> table, Guid stepid)
        {
            return table.FirstOrDefault(e => e.Stepid == stepid);
        }

        public static Task<VoiceStepfrequency?> FindAsync(this ITable<VoiceStepfrequency> table, Guid stepid, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Stepid == stepid, cancellationToken);
        }

        public static VoiceSwop? Find(this ITable<VoiceSwop> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceSwop?> FindAsync(this ITable<VoiceSwop> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceSwopsystemobject? Find(this ITable<VoiceSwopsystemobject> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceSwopsystemobject?> FindAsync(this ITable<VoiceSwopsystemobject> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceSwopsystem? Find(this ITable<VoiceSwopsystem> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceSwopsystem?> FindAsync(this ITable<VoiceSwopsystem> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceSynthcache? Find(this ITable<VoiceSynthcache> table, int id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceSynthcache?> FindAsync(this ITable<VoiceSynthcache> table, int id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceUnitbarcode? Find(this ITable<VoiceUnitbarcode> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceUnitbarcode?> FindAsync(this ITable<VoiceUnitbarcode> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceUnit? Find(this ITable<VoiceUnit> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceUnit?> FindAsync(this ITable<VoiceUnit> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceUnittype? Find(this ITable<VoiceUnittype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceUnittype?> FindAsync(this ITable<VoiceUnittype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceUserrequesttype? Find(this ITable<VoiceUserrequesttype> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceUserrequesttype?> FindAsync(this ITable<VoiceUserrequesttype> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static VoiceUserrequesttypesargument? Find(this ITable<VoiceUserrequesttypesargument> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<VoiceUserrequesttypesargument?> FindAsync(this ITable<VoiceUserrequesttypesargument> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Way? Find(this ITable<Way> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Way?> FindAsync(this ITable<Way> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Workcalendardayexception? Find(this ITable<Workcalendardayexception> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Workcalendardayexception?> FindAsync(this ITable<Workcalendardayexception> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Workcalendardayrange? Find(this ITable<Workcalendardayrange> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Workcalendardayrange?> FindAsync(this ITable<Workcalendardayrange> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Workcalendar? Find(this ITable<Workcalendar> table, Guid id)
        {
            return table.FirstOrDefault(e => e.Id == id);
        }

        public static Task<Workcalendar?> FindAsync(this ITable<Workcalendar> table, Guid id, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public static Время? Find(this ITable<Время> table, DateTime pkДата)
        {
            return table.FirstOrDefault(e => e.PkДата == pkДата);
        }

        public static Task<Время?> FindAsync(this ITable<Время> table, DateTime pkДата, CancellationToken cancellationToken = default)
        {
            return table.FirstOrDefaultAsync(e => e.PkДата == pkДата, cancellationToken);
        }
        #endregion
    }
}
