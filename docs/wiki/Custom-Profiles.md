# Custom Profiles

HotKey Viewer allows you to override the displayed name of any key. This is useful if you want to use specific terminology (e.g., "Sprint" instead of "LeftShift") or if you have a non-standard layout.

## How to Customize Labels

Profile data is stored in JSON files within the mod's folder.

1.  **Locate the File**: Go to your Stardew Valley game folder -> `Mods` -> `HotKeyViewer` -> `profiles`.
2.  **Open `default.json`**: Open this file with any text editor (Notepad, VS Code, etc.).
3.  **Edit the `KeyLabels`**:
    *   Find the `"KeyLabels"` section.
    *   Add entries in the format `"KeyName": "Label"`.

### Example

```json
{
  "ProfileName": "My Custom Layout",
  "Author": "PlayerOne",
  "KeyLabels": {
    "LeftShift": "Running",
    "I": "Inventory",
    "M": "Map Screen",
    "Space": "Action"
  }
}
```

## Key Names
You must use the internal `SButton` names for the keys. Common ones include:
*   `LeftShift`, `RightShift`
*   `LeftControl`, `LeftAlt`
*   `Space`, `Enter`, `Back`
*   `D0` through `D9` (Number row)
*   `NumPad0` through `NumPad9` (Numpad)

*Changes apply the next time you restart the game or reload the save.*
