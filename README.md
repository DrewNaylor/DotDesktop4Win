# DotDesktop4Win
Partial Windows implementation of the Freedesktop.org Desktop Entry specification. This is mainly going to allow launching applications by double-clicking on .desktop files.

There's another project called [WinYourDesktop](https://github.com/dd86k/WinYourDesktop) that does more than this project will probably ever do, as this project is only a partial implementation and doesn't include everything to make itself fully compliant with the [Freedesktop.org Desktop Entry spec](https://specifications.freedesktop.org/desktop-entry-spec/desktop-entry-spec-latest.html). Some things that would make this fully compliant don't make sense on Windows as-is, such as menu entires, icons, and actions.

## Planned features
- Starting an application with the `Exec` key's value, including by double-clicking the file if it's associated with the launcher program.
- Showing how the desktop entry file is interpreted in a program just for that. This program will have a Browse dialog.
- `Type`, `Name`, `Exec`, and `URL` keys will be supported at the very least.
- Comments with the `#` symbol will act as comments and not cause issues.
- When opening a .desktop file with the launcher application, it'll process it and open the thing the file wants. Opening the launcher program directly will show a dialog where a .desktop file can be browsed for in addition to any configuration options, if needed.
- If the application or whatever is to be launched cannot be found, then the user will be made aware.
