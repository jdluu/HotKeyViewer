# HotKey Viewer for Stardew Valley

![Stardew Valley](https://img.shields.io/badge/Stardew%20Valley-1.6+-green.svg)
![SMAPI](https://img.shields.io/badge/SMAPI-4.0+-blue.svg)

**HotKey Viewer** provides an on-screen, visual keyboard overlay that highlights your currently pressed keys in real-time.

## Features

*   **Real-Time Visualization**: Keys light up instantly as you press them.
*   **Stardew Aesthetic**: Designed with pixel-art fonts and colors to match the game's UI.
*   **Action Labels**: Displays the in-game action (e.g., "Menu", "Chat", "Run") bound to each key, not just the letter.
*   **Custom Profiles**: Rename keys to match your specific setup (e.g., "Flashlight", "Split") via simple JSON editing.
*   **Configurable**: Adjust transparency, scale, and toggle hotkeys via Generic Mod Config Menu (GMCM).

## Installation

1.  **Install SMAPI**: Make sure you have the latest version of [SMAPI](https://smapi.io) installed.
2.  **Download**: Get the latest release of `HotKeyViewer` from Nexus Mods or GitHub.
3.  **Unzip**: Extract the `HotKeyViewer` folder into your Stardew Valley `Mods` folder.
4.  **Launch**: Run the game using SMAPI.

## Usage

*   **Toggle Overlay**: Press **F1** (default) to show or hide the keyboard viewer.
*   **Configuration**:
    *   Install **Generic Mod Config Menu (GMCM)** to access settings in-game.
    *   Go to the title screen -> click the gear icon (GMCM) -> select **HotKey Viewer**.
    *   Adjust **Overlay Scale** and **Transparency**.

## Customizing Key Labels

You can give your keys custom names (like "Map" instead of "M") by editing the profile configuration.

1.  Navigate to `Mods/HotKeyViewer/profiles/`.
2.  Open `default.json` (or create a new one).
3.  Add entries to the `"KeyLabels"` section:
    ```json
    "KeyLabels": {
      "M": "Map",
      "I": "Inv",
      "LeftShift": "Run"
    }
    ```
4.  Save the file. Your changes will appear next time you load the overlay.

## Compatibility

*   Works with **Stardew Valley 1.6+**.
*   Requires **SMAPI 4.0+**.
*   Compatible with **Generic Mod Config Menu**.

## License

GNU Lesser General Public License v3.0. See [LICENSE.txt](LICENSE.txt) for details.
