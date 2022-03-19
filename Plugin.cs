using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;

namespace WingAPI
{
    [BepInPlugin(GUID, "WingAPI", "1.0.0")]
    public class Plugin : BasePlugin
    {
        public const string GUID = "com.github.xKiraiChan.WingAPI";

        public static ManualLogSource log;

        public override void Load() => log = Log;
    }
}
