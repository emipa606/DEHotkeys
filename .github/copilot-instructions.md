# Copilot Instructions for DEHotkeys (Continued) Mod Development

## Overview and Purpose

**Mod Name:** DEHotkeys (Continued)

The DEHotkeys mod is a quality-of-life improvement for the game RimWorld. Initially created by DemonEinstein, this continued version updates the functionality to streamline the gameplay experience by enhancing the usability of hotkeys. The primary purpose of the mod is to ensure that order hotkeys are functional outside the specified order menu, minimizing unnecessary mouse clicks and optimizing player efficiency during gameplay.

## Key Features and Systems

- **Automatic Hotkey Activation:** The mod allows the use of order hotkeys without needing to open the order menu, significantly speeding up various tasks such as designating trees for harvesting or uninstalling buildings.

- **Custom Hotkeys:** Introduces two new hotkeys:
  - **J Key:** Assigns the task to harvest wood.
  - **Z Key:** Assigns the task to uninstall buildings.

- **Context-Sensitive Disabling:** Hotkeys are automatically disabled when other menus that use hotkeys are open, preventing interference and enhancing menu navigation.

## Coding Patterns and Conventions

- **Code Organization:** 
  - The source code is structured primarily in C# files, with a clear separation of functionality:
    - `InputPatch.cs` handles the main logic for checking hotkey activation and ensuring compatibility with game states.
    - `Main.cs` manages initialization and other auxiliary functions.
  
- **Naming Conventions:**
  - Classes are named using PascalCase (e.g., `InputPatch`, `Main`).
  - Method names also follow PascalCase (e.g., `checkHotkey`, `checkSelectedDesignatorValid`).
  - Consistency with C# standards ensures readability and maintainability.

## XML Integration

- **Current Status:** This mod version does not include XML definitions as part of its functionality. Future improvements can consider adding XML components if there is a need to manage mod configurations or add further definitions.
  
## Harmony Patching

- **Harmony Library:** The mod relies on Harmony for runtime patching. This framework allows for modifications of the core game methods to enable or override the default behavior.
  
- **Patch Implementation:**
  - **InputPatch.cs:** Utilizes Harmony to intercept game input processes and enable or disable hotkeys based on the game state.
  - Methods are structured to apply postfixes, ensuring the mod's logic integrates seamlessly with the existing game framework without overriding baseline functionalities.

## Suggestions for Copilot

- **Enhanced Hotkey Management:** Suggest methods to detect and handle conflicts with other mods that might introduce similar hotkeys, potentially creating a collaborative map of active keys.

- **Logging and Debugging:** Implement helper methods to log hotkey activations and potential clashes, aiding users in diagnosing issues quickly.

- **Additional Features:** Explore opportunities for Copilot to suggest user-configurable hotkeys through XML file configuration, opening avenues for customization.

- **Performance Monitoring:** Develop Copilot-driven methods to assess the performance impact of hotkeys during intense game sessions and optimize as necessary.

By following these copilot guidance principles, mod developers can enhance the DEHotkeys mod further, ensuring an intuitive and player-friendly experience. Feel free to contribute suggestions or raise issues on GitHub to collaborate on evolving this mod!

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

