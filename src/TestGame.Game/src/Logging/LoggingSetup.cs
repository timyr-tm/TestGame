using System.IO;
using Godot;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace TestGame.Game.Logging;

public partial class LoggingSetup: Node {
	private static ILogger Logger { get; set; } = null!;

	public static readonly LogEventLevel MinLevel = LogEventLevel.Debug;
	public static readonly string LogPath = Path.Join(
		OS.GetUserDataDir(),
		"/logs/",
		"log.jsonl"
	);
	
	public override void _Ready() {
		Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Is(MinLevel)
			.WriteTo.Sink(new GodotConsoleSink())
			.WriteTo.File(new JsonFormatter(), LogPath)
			.CreateLogger();
		
		Logger = Log.ForContext<LoggingSetup>();
		
		Logger
			.ForContext("LogLevel", MinLevel)
			.Information("Setup logging");
	}

	public override void _ExitTree() =>
		Logger.Information("Stop logging");
}