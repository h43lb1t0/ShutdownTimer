# ShutdownTimer

A lightweight Windows system tray application for scheduling and managing system shutdowns.

## Features

- Schedule a system shutdown after a custom delay
- Set the delay in minutes, hours, or days
- Add time to an already running countdown
- Cancel a pending shutdown at any time
- Countdown display showing the remaining time until shutdown
- Minimizes to the system tray on startup and when minimized
- Registers itself in the Windows startup folder on first run so it starts automatically on login
- Supports durations from minutes up to years, with automatic display formatting
- Maximum allowed duration of 10 years enforced

## Requirements

- Windows operating system
- .NET Framework 4.7.2 or later

## Usage

1. Launch the application manually the first time. It will register itself in the Windows startup folder and minimize to the system tray automatically.
2. Right-click the icon at the tray to open the menu.
3. To schedule a shutdown:
   - Enter a number in the custom duration field.
   - Select a unit from the **Unit** submenu (minutes, hours, or days).
4. To add time to an existing countdown, use the add time menu items.
5. To cancel a pending shutdown, click **Reset Timer**.
6. The remaining time is displayed as `hh:mm:ss`, `dd:hh:mm:ss`, or `yy:dd:hh:mm:ss` depending on the duration.
7. To exit the application, click **Exit** in the tray menu. It will NOT cancel any pending shutdowns, so they will still occur as scheduled.

## Building

Open the solution in Visual Studio and build using the standard build process, or run:

```
msbuild ShutdownTimer.sln
```

## License

This project is licensed under the MIT License. See [LICENSE.txt](LICENSE.txt) for details.


## Winforms
It is building using the outdated Winforms framework, which is not ideal for modern applications. However, it was chosen for its simplicity and ease of use for this small utility. Future versions may consider migrating to a more modern framework like WPF or .NET MAUI for improved performance and features.