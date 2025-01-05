using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PP.Integrator.Logging;
namespace Examples;
#nullable disable

public class LoggingExampleSecond : BackgroundService
{
    private ILogger<Status> statusLogger;
	private ILogger<Project> projectLogger;
    public int inta = 0;
	public LoggingExampleSecond(ILogger<Status> log, ILogger<Project> log2)
    {
        statusLogger = log;
        projectLogger = log2; 
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        LogLevel level = LogLevel.Debug;     
        inta = 0;
		var exc = new ArgumentNullException(nameof(stoppingToken));
		try
        {
            using var backgroundScope = statusLogger.BeginScope("statuslogs");
			using var projectScope = projectLogger.BeginScope(new LogScope("projectlogs"));

			for (int i = 0; i < 300; i++)
            {
                level = (LogLevel)(inta++ % 6);

                var logEntry = new Status
                {
                    Name = "Active",
                    Display = "Активен",
                    Version = inta,
                    Description = "Описание статуса",
                    Order = inta % 5
                };

				var projEntry = new Project
				{
					Name = "Test writting"+inta,
					Description = "проект номер "+inta,
					Version = inta,					
					LeftHours = inta*3
				};

				await Task.Delay(101);
				//statusLogger.Log(level, inta, logEntry, level >= LogLevel.Error ? exc : default, (item, err) => "Loglevel");
                if (level >= LogLevel.Error)
				    statusLogger.Log(level, exc, "Ошибка статуса {Status}", logEntry);

				statusLogger.LogInformation(inta, "Status {Name} ({Display}) updated version {Version} with order {Order}", logEntry.Name,logEntry.Display, logEntry.Version, logEntry.Order);
				projectLogger.LogInformation(inta+1, "Проект {Name} ({Description}) изменил версию на: {Version} с остатком часов: {LeftHours}", projEntry.Name, projEntry.Description, projEntry.Version, projEntry.LeftHours);
			}
        }
        catch (Exception err)
        {
            statusLogger.LogError(err.Message, err);
        }

        Console.WriteLine(nameof(LoggingExampleSecond)+" Logging completed" + inta);
    }

    public record Status
    {
        public string Name { get; set; }
        public string Display { get; set; }
        public int Version { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
    }

	public record Project
	{		
		public int Id { get; set; }		
		public string Name { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }
		public int Version { get; set; }
		public double LeftHours { get; set; }
	}
}

public class LoggingExample : BackgroundService
{	
	private ILogger<LoggingExample> logger;	
	public LoggingExample(ILogger<LoggingExample> log)
	{		
		this.logger = log;		
	}

	Rootobject[] objs;
	public int inta = 0;

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		LogLevel level = LogLevel.Debug;
		var loglevel = 1;
		objs = JsonConvert.DeserializeObject<Rootobject[]>(raw);
		var exc = new ArgumentNullException(nameof(stoppingToken));
		TimeSpan span = DateTime.Now.TimeOfDay.Add(TimeSpan.FromSeconds(3));
		var sw = Stopwatch.StartNew();

		inta = 0;
		try
		{
			using var background = logger.BeginScope("Backgroundlogs");

			while (!stoppingToken.IsCancellationRequested)
			{
				var current = objs[Convert.ToInt32(inta++ % 10)];
				level = (LogLevel)(loglevel++ % 6);

				var logEntry = new WebSocketLogItem
				{
					EventSource = WebSocketEventSource.Server,
					EventType = WebSocketEventTypes.Log,
					SocketId = Guid.NewGuid(),
					ServerId = Guid.NewGuid(),
					ClientIpAddress = IPAddress.Broadcast.ToString(),
					ClientPort = inta%65536,
					MessageText = current.company,
					Comments = current.address,
					Email = current.email
				};

				logger.Log(level, inta, logEntry, level >= LogLevel.Error ? exc : default,(item,err)=> "Запись пример обхекста в state");
				//logger.LogError(inta, "Error message");
				//_logger.LogInformation(inta, "Owner {Phone} Soket item {Item}", current.phone, logEntry);
				if (span < DateTime.Now.TimeOfDay) break;
			}
		    await Task.CompletedTask;
		}
		catch (Exception err)
		{
			logger.LogError(err.Message, err);
		}
		sw.Stop();
		Console.WriteLine(nameof(LoggingExampleSecond)+" Logging completed "+sw.Elapsed);
		Console.WriteLine(inta);
	}

	public class Rootobject
	{
		public string id { get; set; }
		public int index { get; set; }
		public Guid guid { get; set; }
		public bool isActive { get; set; }
		public string balance { get; set; }
		public string picture { get; set; }
		public int age { get; set; }
		public string eyeColor { get; set; }
		public string name { get; set; }
		public string gender { get; set; }
		public string company { get; set; }
		public string email { get; set; }
		public string phone { get; set; }
		public string address { get; set; }
		public string about { get; set; }
		public string registered { get; set; }
		public float latitude { get; set; }
		public float longitude { get; set; }
		public string[] tags { get; set; }
		public Friend[] friends { get; set; }
		public string greeting { get; set; }
		public string favoriteFruit { get; set; }
	}

	public class Friend
	{
		public int id { get; set; }
		public string name { get; set; }
	}

	static JArray jArray = JArray.Parse(raw);
    #region JsonData

    static string raw => @"[
          {
            ""_id"": ""66bc32123eda8995f192ccba"",
            ""index"": 0,
            ""guid"": ""f29816c6-e68b-4039-a0a3-a3597f44f8e7"",
            ""isActive"": true,
            ""balance"": ""$1,811.19"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 25,
            ""eyeColor"": ""brown"",
            ""name"": ""Beverly Perry"",
            ""gender"": ""female"",
            ""company"": ""COMTRAK"",
            ""email"": ""beverlyperry@comtrak.com"",
            ""phone"": ""+1 (840) 587-3191"",
            ""address"": ""524 Harbor Court, Dante, California, 9795"",
            ""about"": ""Ut incididunt dolor sit veniam sint eu est in laborum dolore. Minim fugiat ut quis magna incididunt culpa veniam elit eu. Minim exercitation deserunt nulla excepteur anim eiusmod sint ad duis voluptate occaecat. Et proident eiusmod nostrud consectetur. Duis fugiat duis amet elit dolor commodo nisi dolor culpa tempor irure quis. Labore fugiat minim ea cupidatat dolor tempor in sit consequat aliquip voluptate excepteur adipisicing eu. Ex quis elit quis sint excepteur proident id do eiusmod est minim et.\r\n"",
            ""registered"": ""2024-04-21T08:57:29 -03:00"",
            ""latitude"": 67.200822,
            ""longitude"": 168.810892,
            ""tags"": [
              ""proident"",
              ""id"",
              ""magna"",
              ""quis"",
              ""adipisicing"",
              ""velit"",
              ""labore""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Emily Rush""
              },
              {
                ""id"": 1,
                ""name"": ""Blanche Guthrie""
              },
              {
                ""id"": 2,
                ""name"": ""Winnie Keller""
              }
            ],
            ""greeting"": ""Hello, Beverly Perry! You have 1 unread messages."",
            ""favoriteFruit"": ""banana""
          },
          {
            ""_id"": ""66bc32128e3684c97f06d1d6"",
            ""index"": 1,
            ""guid"": ""e4737119-7040-42d4-b316-8f1e98ecdb6e"",
            ""isActive"": true,
            ""balance"": ""$1,845.06"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 28,
            ""eyeColor"": ""brown"",
            ""name"": ""Lowe Wilkins"",
            ""gender"": ""male"",
            ""company"": ""ECLIPSENT"",
            ""email"": ""lowewilkins@eclipsent.com"",
            ""phone"": ""+1 (991) 516-2353"",
            ""address"": ""856 Ocean Parkway, Sedley, Idaho, 1237"",
            ""about"": ""Eu ea amet incididunt consectetur aliqua ad officia labore aute deserunt. Ad in deserunt nostrud nulla quis non enim occaecat nisi tempor eiusmod ea. Proident dolor excepteur ut aliqua eu reprehenderit exercitation et esse eu aliqua dolor non eu. Ex tempor tempor anim irure mollit sint aliquip excepteur minim est fugiat sint. Nulla fugiat Lorem irure dolore reprehenderit sint. Id irure sint excepteur commodo aute consequat proident cillum culpa tempor dolor eu.\r\n"",
            ""registered"": ""2022-03-22T11:44:09 -03:00"",
            ""latitude"": 30.751606,
            ""longitude"": -2.915967,
            ""tags"": [
              ""quis"",
              ""ullamco"",
              ""irure"",
              ""incididunt"",
              ""enim"",
              ""minim"",
              ""irure""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Susan Cooper""
              },
              {
                ""id"": 1,
                ""name"": ""Ferguson Wooten""
              },
              {
                ""id"": 2,
                ""name"": ""Rosalinda Lowery""
              }
            ],
            ""greeting"": ""Hello, Lowe Wilkins! You have 5 unread messages."",
            ""favoriteFruit"": ""strawberry""
          },
          {
            ""_id"": ""66bc321287bfa997df122d22"",
            ""index"": 2,
            ""guid"": ""6bf2dac9-33f1-4536-a9c5-c8871406d505"",
            ""isActive"": true,
            ""balance"": ""$2,171.75"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 31,
            ""eyeColor"": ""blue"",
            ""name"": ""Nell Simpson"",
            ""gender"": ""female"",
            ""company"": ""REMOTION"",
            ""email"": ""nellsimpson@remotion.com"",
            ""phone"": ""+1 (939) 428-3345"",
            ""address"": ""293 Ingraham Street, Bedias, Tennessee, 5431"",
            ""about"": ""Ex ex do nulla amet occaecat ea do eiusmod. Incididunt est proident anim cillum. Occaecat eu qui duis ex. Nisi est est culpa ipsum aute exercitation mollit. Nostrud ut est enim fugiat proident occaecat tempor consectetur in enim incididunt.\r\n"",
            ""registered"": ""2018-12-18T04:21:00 -03:00"",
            ""latitude"": 18.423737,
            ""longitude"": -107.914459,
            ""tags"": [
              ""est"",
              ""esse"",
              ""voluptate"",
              ""do"",
              ""sunt"",
              ""exercitation"",
              ""dolore""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Hancock Hancock""
              },
              {
                ""id"": 1,
                ""name"": ""Rosie Christensen""
              },
              {
                ""id"": 2,
                ""name"": ""Goodwin Fisher""
              }
            ],
            ""greeting"": ""Hello, Nell Simpson! You have 10 unread messages."",
            ""favoriteFruit"": ""banana""
          },
          {
            ""_id"": ""66bc3212fa18f40ef76f0044"",
            ""index"": 3,
            ""guid"": ""62324e0b-3438-4c58-8f5d-3cf12de191de"",
            ""isActive"": false,
            ""balance"": ""$1,745.84"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 29,
            ""eyeColor"": ""brown"",
            ""name"": ""Carroll Lucas"",
            ""gender"": ""male"",
            ""company"": ""LETPRO"",
            ""email"": ""carrolllucas@letpro.com"",
            ""phone"": ""+1 (903) 597-3324"",
            ""address"": ""798 Fanchon Place, Hiwasse, Hawaii, 5423"",
            ""about"": ""Consequat Lorem pariatur et incididunt minim adipisicing duis ut sunt pariatur in dolor qui ipsum. Non aliquip velit do reprehenderit ad id laboris. Nisi pariatur esse labore velit eu adipisicing veniam sint amet. Sit incididunt irure velit enim ipsum aute nostrud commodo sunt est.\r\n"",
            ""registered"": ""2018-04-26T07:27:01 -03:00"",
            ""latitude"": -86.457078,
            ""longitude"": -122.277049,
            ""tags"": [
              ""quis"",
              ""nulla"",
              ""ullamco"",
              ""irure"",
              ""dolore"",
              ""amet"",
              ""elit""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Cleveland Neal""
              },
              {
                ""id"": 1,
                ""name"": ""Rena Haynes""
              },
              {
                ""id"": 2,
                ""name"": ""Pam Sharp""
              }
            ],
            ""greeting"": ""Hello, Carroll Lucas! You have 1 unread messages."",
            ""favoriteFruit"": ""banana""
          },
          {
            ""_id"": ""66bc32129c116302f6e57b95"",
            ""index"": 4,
            ""guid"": ""7629bafe-519c-4950-9a52-62593c659496"",
            ""isActive"": true,
            ""balance"": ""$1,380.50"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 38,
            ""eyeColor"": ""blue"",
            ""name"": ""Blevins Ballard"",
            ""gender"": ""male"",
            ""company"": ""MANGLO"",
            ""email"": ""blevinsballard@manglo.com"",
            ""phone"": ""+1 (990) 452-3312"",
            ""address"": ""857 Butler Street, Cloverdale, Marshall Islands, 9201"",
            ""about"": ""Nostrud exercitation tempor consectetur sit nisi. Deserunt proident labore nulla cupidatat dolore minim. Magna quis cillum laboris amet et proident. Eiusmod consectetur labore excepteur cillum ut consequat aliquip proident laboris. Dolor fugiat duis ea officia in id nisi sint enim consequat voluptate magna voluptate. Enim cupidatat fugiat amet ex aute mollit ullamco. Culpa ipsum magna deserunt non tempor incididunt culpa sunt eiusmod.\r\n"",
            ""registered"": ""2019-07-26T04:50:20 -03:00"",
            ""latitude"": -37.244629,
            ""longitude"": 17.257601,
            ""tags"": [
              ""sit"",
              ""anim"",
              ""dolore"",
              ""sit"",
              ""nisi"",
              ""duis"",
              ""anim""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Whitley Watkins""
              },
              {
                ""id"": 1,
                ""name"": ""Rosemary Sutton""
              },
              {
                ""id"": 2,
                ""name"": ""Gladys Ross""
              }
            ],
            ""greeting"": ""Hello, Blevins Ballard! You have 5 unread messages."",
            ""favoriteFruit"": ""strawberry""
          },
          {
            ""_id"": ""66bc32124e8c8e4b65a65b15"",
            ""index"": 5,
            ""guid"": ""d0a7073e-6dd5-4170-bc8d-7537949e968c"",
            ""isActive"": false,
            ""balance"": ""$1,937.85"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 23,
            ""eyeColor"": ""green"",
            ""name"": ""Kathy Sims"",
            ""gender"": ""female"",
            ""company"": ""SLOFAST"",
            ""email"": ""kathysims@slofast.com"",
            ""phone"": ""+1 (993) 487-3358"",
            ""address"": ""907 Bridge Street, Outlook, Oregon, 351"",
            ""about"": ""Eiusmod labore sit est aliquip. Ullamco aute non sunt veniam ex consequat laborum ullamco eu consequat id voluptate officia. Proident excepteur proident amet commodo cupidatat aliquip tempor in do ex qui. Pariatur nulla consectetur proident velit proident commodo in et qui excepteur aute pariatur nostrud elit. Pariatur commodo fugiat aliqua ut laboris deserunt tempor ullamco amet id elit cillum. Duis anim sunt ut nostrud ullamco duis tempor.\r\n"",
            ""registered"": ""2020-10-28T11:14:25 -03:00"",
            ""latitude"": -54.019058,
            ""longitude"": 55.69876,
            ""tags"": [
              ""in"",
              ""ad"",
              ""nostrud"",
              ""aute"",
              ""do"",
              ""officia"",
              ""exercitation""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Lilian Shaw""
              },
              {
                ""id"": 1,
                ""name"": ""Beatriz Delaney""
              },
              {
                ""id"": 2,
                ""name"": ""Estelle Kennedy""
              }
            ],
            ""greeting"": ""Hello, Kathy Sims! You have 5 unread messages."",
            ""favoriteFruit"": ""banana""
          },
          {
            ""_id"": ""66bc32120cec27eff079f03a"",
            ""index"": 6,
            ""guid"": ""54fe89d3-94ae-4352-bca3-1d8e4e0ed49c"",
            ""isActive"": true,
            ""balance"": ""$2,487.75"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 20,
            ""eyeColor"": ""blue"",
            ""name"": ""Hebert Lee"",
            ""gender"": ""male"",
            ""company"": ""EXOSPEED"",
            ""email"": ""hebertlee@exospeed.com"",
            ""phone"": ""+1 (873) 454-3157"",
            ""address"": ""618 Plymouth Street, Gallina, Virginia, 5969"",
            ""about"": ""Aliquip aliqua quis adipisicing nisi aliqua excepteur ipsum irure non dolor ea. Tempor dolore ut est laboris ipsum tempor et reprehenderit aliqua. Duis qui consequat ex ipsum officia veniam consequat pariatur incididunt esse labore. Cillum quis Lorem reprehenderit consectetur. Id ipsum anim velit incididunt reprehenderit aute. Occaecat qui id velit esse sint incididunt exercitation ut ipsum ex laborum dolore exercitation. Consequat nulla deserunt velit occaecat id culpa mollit velit sit cillum sit tempor nostrud commodo.\r\n"",
            ""registered"": ""2019-05-12T01:07:19 -03:00"",
            ""latitude"": -60.498179,
            ""longitude"": 103.464577,
            ""tags"": [
              ""esse"",
              ""cupidatat"",
              ""consectetur"",
              ""occaecat"",
              ""mollit"",
              ""pariatur"",
              ""eu""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Freda Smith""
              },
              {
                ""id"": 1,
                ""name"": ""Solomon Fuller""
              },
              {
                ""id"": 2,
                ""name"": ""Luna Harvey""
              }
            ],
            ""greeting"": ""Hello, Hebert Lee! You have 9 unread messages."",
            ""favoriteFruit"": ""strawberry""
          },
          {
            ""_id"": ""66bc321263acdba981bc4284"",
            ""index"": 7,
            ""guid"": ""74ac8538-0501-4f5c-ad14-625a7961f3d8"",
            ""isActive"": true,
            ""balance"": ""$1,903.97"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 28,
            ""eyeColor"": ""brown"",
            ""name"": ""Smith Burke"",
            ""gender"": ""male"",
            ""company"": ""TERRAGO"",
            ""email"": ""smithburke@terrago.com"",
            ""phone"": ""+1 (920) 478-3720"",
            ""address"": ""522 Senator Street, Snelling, Indiana, 8397"",
            ""about"": ""Consectetur ad Lorem elit amet dolore pariatur eu tempor amet. Do cillum ut pariatur elit eiusmod aute deserunt anim. Ex do excepteur sunt minim ea aute occaecat mollit nostrud amet. Ullamco aute excepteur do eiusmod eu enim non sunt anim adipisicing adipisicing. Ex consectetur est occaecat officia proident voluptate irure nisi proident laboris anim qui. Elit adipisicing ea laborum in.\r\n"",
            ""registered"": ""2022-01-21T04:34:34 -03:00"",
            ""latitude"": -43.141723,
            ""longitude"": 100.024822,
            ""tags"": [
              ""qui"",
              ""culpa"",
              ""officia"",
              ""elit"",
              ""sunt"",
              ""consectetur"",
              ""sunt""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Sims Mcintosh""
              },
              {
                ""id"": 1,
                ""name"": ""Durham Castillo""
              },
              {
                ""id"": 2,
                ""name"": ""Cobb Mckinney""
              }
            ],
            ""greeting"": ""Hello, Smith Burke! You have 4 unread messages."",
            ""favoriteFruit"": ""strawberry""
          },
          {
            ""_id"": ""66bc32123629614405b3003f"",
            ""index"": 8,
            ""guid"": ""2fbe164d-927f-467d-b68b-775561e2bf7e"",
            ""isActive"": false,
            ""balance"": ""$2,610.15"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 29,
            ""eyeColor"": ""green"",
            ""name"": ""Casandra Mills"",
            ""gender"": ""female"",
            ""company"": ""INTERFIND"",
            ""email"": ""casandramills@interfind.com"",
            ""phone"": ""+1 (945) 416-3707"",
            ""address"": ""900 Hillel Place, Lewis, Alaska, 1540"",
            ""about"": ""Et id consequat Lorem in voluptate quis amet. Eu sunt dolore aute quis quis non commodo veniam pariatur fugiat amet officia Lorem. Pariatur laboris id aliquip sunt duis ut id cupidatat velit minim enim do cillum. Consectetur ea mollit ullamco elit laboris. Et dolor veniam Lorem nisi cillum nostrud aliqua laboris est laboris ea. Eu anim laborum anim laboris quis Lorem Lorem labore.\r\n"",
            ""registered"": ""2019-11-23T12:05:57 -03:00"",
            ""latitude"": 40.409746,
            ""longitude"": 145.620811,
            ""tags"": [
              ""commodo"",
              ""ullamco"",
              ""minim"",
              ""consectetur"",
              ""quis"",
              ""sint"",
              ""et""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Amelia Watson""
              },
              {
                ""id"": 1,
                ""name"": ""Potts Patel""
              },
              {
                ""id"": 2,
                ""name"": ""Cooley Buck""
              }
            ],
            ""greeting"": ""Hello, Casandra Mills! You have 1 unread messages."",
            ""favoriteFruit"": ""strawberry""
          },
          {
            ""_id"": ""66bc3212fe4cc96f501db048"",
            ""index"": 9,
            ""guid"": ""a2a5413b-dfdb-452d-9733-43554c1a0602"",
            ""isActive"": true,
            ""balance"": ""$2,586.48"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 20,
            ""eyeColor"": ""blue"",
            ""name"": ""Tyler Hicks"",
            ""gender"": ""male"",
            ""company"": ""TASMANIA"",
            ""email"": ""tylerhicks@tasmania.com"",
            ""phone"": ""+1 (846) 507-3257"",
            ""address"": ""421 Sharon Street, Villarreal, Maryland, 3927"",
            ""about"": ""Cillum dolor nulla ullamco eu dolor do culpa labore. Ad esse laboris incididunt commodo quis reprehenderit ex elit aute laborum tempor. Velit laboris irure consequat aliqua magna do deserunt exercitation ullamco aliquip veniam fugiat.\r\n"",
            ""registered"": ""2019-02-23T01:06:30 -03:00"",
            ""latitude"": -6.397768,
            ""longitude"": 168.4759,
            ""tags"": [
              ""officia"",
              ""tempor"",
              ""et"",
              ""minim"",
              ""sunt"",
              ""consectetur"",
              ""sunt""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Maura Branch""
              },
              {
                ""id"": 1,
                ""name"": ""Kirk Berger""
              },
              {
                ""id"": 2,
                ""name"": ""Marquez Gregory""
              }
            ],
            ""greeting"": ""Hello, Tyler Hicks! You have 3 unread messages."",
            ""favoriteFruit"": ""banana""
          },
          {
            ""_id"": ""66bc3212f6f70c468f8e1287"",
            ""index"": 10,
            ""guid"": ""2e340bf9-9969-48e2-8dd5-515340cfabc9"",
            ""isActive"": true,
            ""balance"": ""$1,531.15"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 35,
            ""eyeColor"": ""blue"",
            ""name"": ""Gilliam Stone"",
            ""gender"": ""male"",
            ""company"": ""ZYTREK"",
            ""email"": ""gilliamstone@zytrek.com"",
            ""phone"": ""+1 (872) 457-3287"",
            ""address"": ""210 Bay Parkway, Wescosville, Vermont, 223"",
            ""about"": ""Do officia nisi reprehenderit aliquip ipsum exercitation proident eu velit exercitation fugiat sunt reprehenderit. Irure laborum est quis qui ea incididunt mollit aliquip labore adipisicing est ipsum nisi qui. Consectetur consequat commodo ea mollit consectetur pariatur esse minim ut in. Excepteur tempor dolor enim nulla cupidatat cillum nostrud dolor Lorem amet ipsum aliqua fugiat dolor. Veniam cupidatat Lorem do magna elit nulla proident aliqua laborum. Sit fugiat adipisicing consequat dolor elit.\r\n"",
            ""registered"": ""2019-06-20T07:32:51 -03:00"",
            ""latitude"": -41.259122,
            ""longitude"": -76.790033,
            ""tags"": [
              ""dolor"",
              ""commodo"",
              ""exercitation"",
              ""laboris"",
              ""magna"",
              ""cupidatat"",
              ""non""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Holly Aguirre""
              },
              {
                ""id"": 1,
                ""name"": ""Natalie Gilliam""
              },
              {
                ""id"": 2,
                ""name"": ""Eliza Montgomery""
              }
            ],
            ""greeting"": ""Hello, Gilliam Stone! You have 4 unread messages."",
            ""favoriteFruit"": ""apple""
          },
          {
            ""_id"": ""66bc3212245d95a06d84d104"",
            ""index"": 11,
            ""guid"": ""fcbd719d-0bfb-44c8-bf05-28b72df0b024"",
            ""isActive"": false,
            ""balance"": ""$2,519.11"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 37,
            ""eyeColor"": ""brown"",
            ""name"": ""Nona Guy"",
            ""gender"": ""female"",
            ""company"": ""KAGE"",
            ""email"": ""nonaguy@kage.com"",
            ""phone"": ""+1 (980) 446-3502"",
            ""address"": ""543 Jefferson Street, Convent, Mississippi, 1557"",
            ""about"": ""Quis Lorem officia minim in aliquip dolor proident tempor duis eiusmod irure. Sint eu veniam aliqua veniam sint magna aliqua cillum. Et cillum tempor sunt occaecat occaecat aliqua minim laboris. Culpa aute officia velit sit magna id dolor. Et eu enim eu dolore in id eiusmod ullamco nostrud duis dolore ipsum. Minim officia amet voluptate aliqua officia anim tempor.\r\n"",
            ""registered"": ""2020-07-07T04:16:47 -03:00"",
            ""latitude"": -63.125719,
            ""longitude"": 1.184387,
            ""tags"": [
              ""voluptate"",
              ""anim"",
              ""reprehenderit"",
              ""Lorem"",
              ""non"",
              ""nulla"",
              ""Lorem""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Catherine Stout""
              },
              {
                ""id"": 1,
                ""name"": ""Stacie Holmes""
              },
              {
                ""id"": 2,
                ""name"": ""Eleanor Barton""
              }
            ],
            ""greeting"": ""Hello, Nona Guy! You have 7 unread messages."",
            ""favoriteFruit"": ""strawberry""
          },
          {
            ""_id"": ""66bc3212edbf973f36e82ee4"",
            ""index"": 12,
            ""guid"": ""9b0b8b2b-dc99-45fb-9ab1-38c97aae95a4"",
            ""isActive"": false,
            ""balance"": ""$2,811.75"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 39,
            ""eyeColor"": ""green"",
            ""name"": ""Glenn Horn"",
            ""gender"": ""male"",
            ""company"": ""NEPTIDE"",
            ""email"": ""glennhorn@neptide.com"",
            ""phone"": ""+1 (861) 505-3080"",
            ""address"": ""160 Aster Court, Venice, Virgin Islands, 5726"",
            ""about"": ""Cupidatat velit occaecat culpa do qui cupidatat nostrud fugiat duis dolore anim ipsum. Nisi est ad excepteur reprehenderit velit adipisicing sit ut deserunt tempor dolor nostrud voluptate anim. Enim labore irure eu fugiat dolore officia sint aliqua ea cillum. Incididunt ipsum culpa amet pariatur anim magna eu consectetur duis irure quis est. Anim magna aute duis do quis consectetur aliquip sit.\r\n"",
            ""registered"": ""2014-04-26T12:35:44 -03:00"",
            ""latitude"": 44.841757,
            ""longitude"": -157.37466,
            ""tags"": [
              ""non"",
              ""aliquip"",
              ""et"",
              ""reprehenderit"",
              ""ea"",
              ""in"",
              ""quis""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Townsend Farley""
              },
              {
                ""id"": 1,
                ""name"": ""Lewis Mcgee""
              },
              {
                ""id"": 2,
                ""name"": ""Patton Fuentes""
              }
            ],
            ""greeting"": ""Hello, Glenn Horn! You have 8 unread messages."",
            ""favoriteFruit"": ""apple""
          },
          {
            ""_id"": ""66bc3212d3464fbc58d6d039"",
            ""index"": 13,
            ""guid"": ""24b69635-3fed-49e4-ba82-66c350203a1c"",
            ""isActive"": true,
            ""balance"": ""$3,762.81"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 30,
            ""eyeColor"": ""brown"",
            ""name"": ""Weeks Martinez"",
            ""gender"": ""male"",
            ""company"": ""ANACHO"",
            ""email"": ""weeksmartinez@anacho.com"",
            ""phone"": ""+1 (823) 549-2898"",
            ""address"": ""857 Durland Place, Hardyville, Pennsylvania, 8941"",
            ""about"": ""Adipisicing qui ullamco excepteur mollit consectetur reprehenderit. Cupidatat laboris do deserunt sunt adipisicing nostrud consequat aliquip. Tempor veniam exercitation laborum et consectetur tempor do eiusmod voluptate incididunt proident consectetur nostrud esse. Nulla et ad commodo sunt magna labore. Mollit laborum ad proident Lorem exercitation occaecat reprehenderit occaecat ut amet deserunt nulla voluptate occaecat. Sint veniam reprehenderit adipisicing velit esse nostrud et deserunt culpa et. Fugiat aliquip labore laboris eiusmod aliqua adipisicing Lorem deserunt ea occaecat.\r\n"",
            ""registered"": ""2021-02-09T11:43:27 -03:00"",
            ""latitude"": 74.317961,
            ""longitude"": -96.90978,
            ""tags"": [
              ""nulla"",
              ""exercitation"",
              ""cillum"",
              ""aliquip"",
              ""incididunt"",
              ""cillum"",
              ""nisi""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Diann House""
              },
              {
                ""id"": 1,
                ""name"": ""Louisa Padilla""
              },
              {
                ""id"": 2,
                ""name"": ""Holder Cobb""
              }
            ],
            ""greeting"": ""Hello, Weeks Martinez! You have 7 unread messages."",
            ""favoriteFruit"": ""apple""
          },
          {
            ""_id"": ""66bc32129f8fd3d49f68e9b7"",
            ""index"": 14,
            ""guid"": ""ec232c3d-c195-4ba5-993e-e7fe1ab0a7ec"",
            ""isActive"": false,
            ""balance"": ""$2,376.96"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 40,
            ""eyeColor"": ""brown"",
            ""name"": ""Kerr Benjamin"",
            ""gender"": ""male"",
            ""company"": ""PUSHCART"",
            ""email"": ""kerrbenjamin@pushcart.com"",
            ""phone"": ""+1 (919) 580-2074"",
            ""address"": ""526 Crescent Street, Rockhill, Connecticut, 5610"",
            ""about"": ""Anim eu nostrud laboris in. Eiusmod ut magna labore Lorem duis culpa. Aliquip culpa commodo officia culpa.\r\n"",
            ""registered"": ""2014-08-26T01:11:23 -03:00"",
            ""latitude"": -74.808244,
            ""longitude"": 65.707456,
            ""tags"": [
              ""sint"",
              ""tempor"",
              ""quis"",
              ""tempor"",
              ""sunt"",
              ""quis"",
              ""enim""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Cynthia Reese""
              },
              {
                ""id"": 1,
                ""name"": ""Johnnie Hewitt""
              },
              {
                ""id"": 2,
                ""name"": ""Rosario Spencer""
              }
            ],
            ""greeting"": ""Hello, Kerr Benjamin! You have 2 unread messages."",
            ""favoriteFruit"": ""strawberry""
          },
          {
            ""_id"": ""66bc32125140a959be3f0279"",
            ""index"": 15,
            ""guid"": ""87daa64b-51b7-4a4a-a0ee-1f1927707e09"",
            ""isActive"": false,
            ""balance"": ""$2,221.56"",
            ""picture"": ""http://placehold.it/32x32"",
            ""age"": 40,
            ""eyeColor"": ""green"",
            ""name"": ""Isabelle Roth"",
            ""gender"": ""female"",
            ""company"": ""LIQUICOM"",
            ""email"": ""isabelleroth@liquicom.com"",
            ""phone"": ""+1 (956) 504-3813"",
            ""address"": ""700 Jerome Avenue, Gilmore, West Virginia, 9265"",
            ""about"": ""Id incididunt culpa consectetur excepteur ullamco do dolore mollit. Do Lorem ipsum fugiat fugiat amet labore Lorem culpa. Commodo eiusmod qui do est sit mollit pariatur dolor quis et qui do non.\r\n"",
            ""registered"": ""2019-02-20T03:24:13 -03:00"",
            ""latitude"": 20.748513,
            ""longitude"": -129.109864,
            ""tags"": [
              ""id"",
              ""consectetur"",
              ""sunt"",
              ""velit"",
              ""tempor"",
              ""fugiat"",
              ""anim""
            ],
            ""friends"": [
              {
                ""id"": 0,
                ""name"": ""Knight Mccarthy""
              },
              {
                ""id"": 1,
                ""name"": ""Dorothea Moody""
              },
              {
                ""id"": 2,
                ""name"": ""Roxanne Dotson""
              }
            ],
            ""greeting"": ""Hello, Isabelle Roth! You have 8 unread messages."",
            ""favoriteFruit"": ""strawberry""
          }
        ]";

    #endregion
}

#nullable restore

