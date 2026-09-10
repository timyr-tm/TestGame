using Godot;
using Serilog;
using TestGame.Game.Event;

namespace TestGame.Game;

public partial class Main: Node {
	private static readonly ILogger Logger = Log.ForContext<Main>();
	
	public override async void _Ready() {
		Logger
			.ForContext("UserDataDir", OS.GetUserDataDir())
			.ForContext("DataDir", OS.GetDataDir())
			.ForContext("ConfigDir", OS.GetConfigDir())
			.Debug("Ready!");
		await EventBus.Instance.Publish(new SetupEvent());
	}
}