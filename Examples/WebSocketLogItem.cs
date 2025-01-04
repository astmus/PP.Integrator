namespace Examples;

public class WebSocketLogItem
{
	public WebSocketEventSource EventSource { set; get; }
	public WebSocketEventTypes EventType { set; get; }
	public Guid? SocketId { set; get; }
	public Guid? ServerId { set; get; }
	public string ServerUrl { set; get; }
	public string ClientIpAddress { set; get; }
	public int ClientPort { set; get; }
	public string MessageText { set; get; }
	public string Comments { set; get; }
}

public enum WebSocketEventTypes
{
	Open,
	GetMessage,
	SendMessage,
	Error,
	Close,
	Log
}

public enum WebSocketEventSource
{
	Server,
	Client
}
