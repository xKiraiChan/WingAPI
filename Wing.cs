using System.Collections.Generic;
using UnityEngine;

namespace WingAPI
{
    public class Wing
    {
        public List<WingPage> openedPages = new();

        public Wing(Transform wing, bool isRight)
        {
            IsRight = isRight;  
            Self = wing;
            WingOpen = wing.Find("Button");
            WingPages = wing.Find("Container/InnerContainer");
            WingMenu = WingPages.Find("WingMenu");
            WingButtons = WingPages.Find("WingMenu/ScrollRect/Viewport/VerticalLayoutGroup");
            ProfilePage = WingPages.Find("Profile");
            ProfileButton = WingButtons.Find("Button_Profile");
        }

        public readonly bool IsRight;
        public readonly Transform Self; //        UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left
        public readonly Transform WingOpen; //    UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button
        public readonly Transform WingPages; //   UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer
        public readonly Transform WingMenu; //    UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu
        public readonly Transform WingButtons; // UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup
        public readonly Transform ProfilePage;
        public readonly Transform ProfileButton;

        public WingPage CreatePage(string name) => new(this, name);
    }
}
