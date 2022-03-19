using KiraiMod.Core;
using System;
using System.Collections;
using UnityEngine;

namespace WingAPI
{
    public static class Controller
    {
        static Controller() => FindUI().Start();

        public static event Action<Wing> WingInit;

        public static Wing Left;
        public static Wing Right;

        internal static IEnumerator FindUI()
        {
            while ((Memory.UserInterface = GameObject.Find("UserInterface")?.transform) is null)
                yield return null;

            while ((Memory.QuickMenu = Memory.UserInterface.Find("Canvas_QuickMenu(Clone)")) is null)
                yield return null;

            Left = new(Memory.QuickMenu.Find("Container/Window/Wing_Left"), false);
            Right = new(Memory.QuickMenu.Find("Container/Window/Wing_Right"), true);

            // this could possibly be changed to removeListener instead 
            Left.WingOpen.GetComponent<UnityEngine.UI.Button>().On(new Action(() => Init_L()));
            Right.WingOpen.GetComponent<UnityEngine.UI.Button>().On(new Action(() => Init_R()));
        }

        private static Action Init_L = new(() =>
        {
            Init_L = new Action(() => { });
            Plugin.log.LogInfo("Creating Left Wing UI");
            WingInit(Left);
        });

        private static Action Init_R = new(() =>
        {
            Init_R = new Action(() => { });
            Plugin.log.LogInfo("Creating Right Wing UI");
            WingInit(Right);
        });
    }
}
