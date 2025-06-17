using DesignPatterns.Command.ex1;

namespace DesignPatterns.Client.Command;

public class CommandClient
{
    public void Run()
    {
        // Create receivers (devices)
            var livingRoomLight = new Light("Living Room");
            var kitchenLight = new Light("Kitchen");
            var thermostat = new Thermostat("Main Floor");
            var musicPlayer = new MusicPlayer();

            // Create commands
            var livingRoomLightOn = new LightOnCommand(livingRoomLight);
            var livingRoomLightOff = new LightOffCommand(livingRoomLight);
            var kitchenLightOn = new LightOnCommand(kitchenLight);
            var kitchenLightOff = new LightOffCommand(kitchenLight);
            var increaseTemp = new ThermostatCommand(thermostat, 23.5f);
            var decreaseTemp = new ThermostatCommand(thermostat, 20.0f);
            var playMusic = new PlayMusicCommand(musicPlayer, "Relaxing Jazz");
            var stopMusic = new StopMusicCommand(musicPlayer);

            // Create a macro command for "Movie Mode"
            var movieMode = new MacroCommand("Movie Mode", new List<ICommand>
            {
                livingRoomLightOn,
                new LightOffCommand(kitchenLight),
                new ThermostatCommand(thermostat, 22.0f),
                playMusic
            });

            // Create a macro command for "Sleep Mode"
            var sleepMode = new MacroCommand("Sleep Mode", new List<ICommand>
            {
                livingRoomLightOff,
                kitchenLightOff,
                decreaseTemp,
                stopMusic
            });

            // Create the invoker
            var controller = new SmartHomeController();

            // Register commands with the controller
            controller.RegisterCommand("living_lights_on", livingRoomLightOn);
            controller.RegisterCommand("living_lights_off", livingRoomLightOff);
            controller.RegisterCommand("kitchen_lights_on", kitchenLightOn);
            controller.RegisterCommand("kitchen_lights_off", kitchenLightOff);
            controller.RegisterCommand("warm_up", increaseTemp);
            controller.RegisterCommand("cool_down", decreaseTemp);
            controller.RegisterCommand("play_music", playMusic);
            controller.RegisterCommand("stop_music", stopMusic);
            controller.RegisterCommand("movie_mode", movieMode);
            controller.RegisterCommand("sleep_mode", sleepMode);

            // Display available commands
            controller.ShowAvailableCommands();

            // Execute some commands
            Console.WriteLine("\n=== Executing Commands ===");
            controller.ExecuteCommand("kitchen_lights_on");
            controller.ExecuteCommand("warm_up");
            controller.ExecuteCommand("play_music");

            // Show command history
            controller.ShowCommandHistory();

            // Undo the last command
            Console.WriteLine("\n=== Undoing Last Command ===");
            controller.UndoLastCommand();

            // Execute a macro command
            Console.WriteLine("\n=== Executing Macro Command ===");
            controller.ExecuteCommand("movie_mode");

            // Show updated history
            controller.ShowCommandHistory();

            // Undo the macro command (will undo all commands in the macro in reverse)
            Console.WriteLine("\n=== Undoing Macro Command ===");
            controller.UndoLastCommand();
    }
}