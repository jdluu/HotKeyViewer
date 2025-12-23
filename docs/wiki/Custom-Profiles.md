# Action Labels & Sharable Profiles

In **HotKey Viewer**, keys don't just show their primary letter; they show what they **do**. These descriptions are called **Action Labels**.

Because every player has different mods and hotkey preferences, these labels are highly personal. You can save your collection of labels into a **Profile** (a JSON file) which can be backed up, modified, or shared with other players.

## Action Labels vs. Profiles

*   **Action Labels**: The specific text displayed on an on-screen key (e.g., "Torch", "Bag", "Quick-Save"). By default, the mod tries to pull these from your in-game keybindings, but you can override them with anything you like.
*   **Profiles**: A `.json` file containing a set of Action Labels. If you have different hotkey setups for different playthroughs (e.g., "Speedrun" vs "Relaxed"), you can swap between them in the settings.

## How to Customize Labels

Label data is stored in JSON profiles within the mod's folder.

1.  **Locate the File**: Go to your Stardew Valley game folder -> `Mods` -> `HotKeyViewer` -> `profiles`.
2.  **Open a Profile**: Open `default.json` (or any other profile) with a text editor.
3.  **Edit the `KeyLabels`**:
    *   Find the `"KeyLabels"` section.
    *   Add entries in the format `"KeyName": "Label text"`.

### Example

```json
{
  "ProfileName": "Utility Setup",
  "Author": "PlayerOne",
  "KeyLabels": {
    "LeftShift": "Sprinting",
    "I": "Bag",
    "M": "World Map",
    "K": "Flashlight"
  }
}
```

## Creating & Sharing Profiles

To create a new profile:
1. Copy an existing `.json` file in the `profiles/` folder.
2. Rename the file (e.g. `Stream-Setup.json`).
3. Change the `"ProfileName"` inside the file.
4. Customize your labels.

You can share these JSON files with other players so they don't have to manually re-type labels for common mod setups!

*Changes apply the next time you reload the save or select the profile in GMCM.*
