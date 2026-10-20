# Air Traffic Simulation and Conflict Resolution System

A Windows desktop application that simulates aircraft flying across a 2D map, predicts
**conflicts** (two aircraft getting closer than a safety distance) and can solve them by slowing
flights down. It also exports the flights to Google Earth, manages airline contact details and
includes a small mini-game.

## Features

- **User accounts**: log in, register (with a confirmation email) and password recovery.
  Passwords are stored as salted PBKDF2-SHA256 hashes, never as plain text.
- **Flight plans**: enter flights by hand or load a saved simulation from a file.
- **Simulator**: move flights one cycle at a time or automatically, undo cycles, change a
  flight's speed, and see safety circles turn red when two aircraft get too close.
- **Conflict prediction and resolution**: before simulating, the program predicts whether any
  pair of flights will violate the safety distance, and can slow flights down to avoid it.
  The changes are written to `Conflict Log Solutions.txt`, together with the contact details of
  the affected airlines.
- **Fuel model**: fuel is burned according to the distance flown (0.8 units per unit of
  distance). Flights that will not reach their destination are highlighted in orange, and
  flights that run out of fuel stop and are highlighted in red.
- **Monitored point**: a circle on the map that turns red when any aircraft enters it.
- **Save / load**: save the whole simulation, including its undo history, to a text file.
- **Google Earth export**: export the initial, current and final positions and the
  trajectories of every flight to a `.kml` file.
- **Airline companies**: list, add (with logo) and delete airlines.
- **Mini-game**: a short side-scrolling game, opened from the main menu.

## Requirements

See [`requirements.txt`](requirements.txt) for the full list. In short:

- Windows 10 or 11
- Visual Studio 2022 (or newer) with the **.NET desktop development** workload
- .NET Framework **4.7.2** (developer pack / targeting pack)
- Optional: Google Earth Pro, to open the `.kml` exports
- Optional: a Gmail account with an app password, to send account emails

The only third-party library, `System.Data.SQLite` 1.0.79, is included in the `SQLite/` folder,
so no package download is needed.

## Getting started

1. Clone the repository and open `air-traffic-simulation-and-conflict-resolution-system.sln`
   in Visual Studio.
2. Select the **x86** platform (*Build → Configuration Manager*, or the toolbar). The bundled
   SQLite library is 32-bit only, so an *Any CPU* build can fail on 64-bit Windows when it opens
   the database.
3. Right-click the **Menu** project and choose **Set as Startup Project**.
4. Press **F5**. The login screen opens.
5. Click **Register** to create your first user. The database is created automatically the first
   time the program runs.

### Building from the command line

```powershell
msbuild air-traffic-simulation-and-conflict-resolution-system.sln /p:Configuration=Debug /p:Platform=x86
```

The executable is written to `Menu\bin\x86\Debug\Menu.exe`.

## Configuration

### Database

The program uses an SQLite file called `Database.db` **next to the executable**. If it does not
exist, it is created with empty tables on first run. If a database from an earlier version is
found under its old name (`BD.db`), it is renamed and kept, and any plain-text passwords in it are
converted to hashes.

The database contains user accounts, so it is excluded from git (see `.gitignore`).

### Email notifications (optional)

Registration and password recovery send an email through Gmail. The credentials are kept out of
the source code:

1. Copy `Menu/smtp.secrets.example.config` to `Menu/smtp.secrets.config`.
2. Fill in the Gmail address and a Gmail **app password** (never the real account password).
3. Rebuild. The file is copied next to the executable automatically.

`smtp.secrets.config` is ignored by git. If it is missing, the program still works and simply
skips the emails, telling the user that the email could not be sent.

## Project structure

| Project | Type | Purpose |
|---|---|---|
| `Menu` | Windows Forms app | The application: login, main menu, simulator and every other screen. |
| `FlightLib` | Class library | Flight logic: positions, movement, fuel, conflict prediction and resolution, save/load files, KML export and the conflict log. |
| `Database` | Class library | SQLite access (users and airlines) and password hashing. |
| `Videogame` | WPF app | The mini-game opened from the main menu. |
| `SQLite/` | Folder | The `System.Data.SQLite` library used by `Database` and `Menu`. |

Code is documented with XML documentation comments (`///`), which explain what each class and
method does and why.

## File formats

### Saved simulation (`.txt`)

```
TC DS
<cycle time in seconds> <safety distance>
Transponder xi yi cx cy xf yf speed fuel initialFuel
<one line per flight>
-
<undo history: one block of flight lines per previous state, most recent first>
```

Each flight line holds its ID, initial position (`xi yi`), current position (`cx cy`), final
position (`xf yf`), speed, current fuel and initial fuel. Files saved by older versions, without
the initial fuel value, still load. Numbers use the computer's regional format (for example
`12,5` on a Spanish Windows).

### Coordinates

The simulation canvas goes from (0, 0) at the top-left corner to (897, 597) at the bottom-right
corner. For the Google Earth export, it is mapped onto a box over the Iberian Peninsula.

## Branches

Each numbered branch (`1.1`, `1.2`, ...) is a version of the project; `main` holds the latest
merged version.
