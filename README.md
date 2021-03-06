If you believe any features to be missing, create an [issue](https://github.com/xKiraiChan/WingAPI/issues)

# Usage
- Add to mods folder (or call `Initialize()`)
- Add reference to mod
- Inside of `OnApplicationStart`:
  - `WingAPI.OnWingInit += new Action<WingAPI.BaseWing>(/*YOUR CODE HERE*/);`

# Example
```cs
// OnApplicationStart:
WingAPI.WingAPI.OnWingInit += new System.Action<Wing.BaseWing>(wing =>
{
  WingPage   page   = wing.CreatePage  ("KiraiMod");
  WingToggle toggle = page.CreateToggle("Flight", 0, UnityEngine.Color.green, UnityEngine.Color.red, false, new System.Action<bool>(state => Modules.Flight.State = state));
});
```

# Notes
- Buttons start at ~320 on this
- Each button is ~120 in size
- Methods taking `index` instead of `pos` expect a button position instead of a coordinate. Ex: (0, 1, 2)

# TODO
- API
  - [X] Basic Raw
  - [ ] Advanced Raw
  - [x] Simplistic
  - [ ] Reflective
- Features
  - [x] Pages
  - [x] Buttons 
  - [x] Toggles
  - [ ] Sliders
