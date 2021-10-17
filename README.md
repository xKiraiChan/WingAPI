If you believe any features to be missing, create an [issue](https://github.com/xKiraiChan/WingAPI/issues)

# Usage
- Add to mods folder (or call `Initialize()`)
- Add reference to mod
- Inside of `OnApplicationStart`:
  - `WingAPI.OnWingInit += new Action<WingAPI.BaseWing>(/*YOUR CODE HERE*/);`
- Use `BaseWing::CreateCategory` to get a `CustomWing`
- Use `CustomWing::CreateButton` to create a button

# Example
```cs
// OnApplicationStart:
WingAPI.WingAPI.OnWingInit += new System.Action<Wing.BaseWing>(wing =>
{
    WingAPI.RawUI.WingPage page = new WingAPI.RawUI.WingPage(wing, "Example Menu");
    WingAPI.RawUI.WingButton button = new WingAPI.RawUI.WingButton(wing, "Example Button", page.page, 320, 
        new System.Action(() => MelonLogger.Msg("Clicked")));
});
```

# Notes
- Buttons start at ~320 on this
- Each button is ~120 in size

# TODO
- API
  - [X] Basic Raw
  - [ ] Advanced Raw
  - [ ] Simplistic
  - [ ] Reflective
- Features
  - [x] Pages
  - [x] Buttons 
  - [ ] Toggles
  - [ ] Sliders
