# WingAPI
API to create pages and buttons on VRChat's new Wings.

# Usage:
- Add to mods folder (or call `Initialize()`)
- Add reference to mod
- Inside of `OnApplicationStart`:
  - `WingAPI.OnWingInit += new Action<WingAPI.BaseWing>(/*YOUR CODE HERE*/)`;
- Use `BaseWing::CreateCategory` to get a `CustomWing`
- Use `CustomWing::CreateButton` to create a button.

# Notes:
- Buttons start at ~320 on this
- Each button is ~120 in size
