using UnityEngine;
using UnityEngine.UI;

namespace KiraiMod.WingAPI
{
    public static class Wing
    {
        public static BaseWing Left = new BaseWing();
        public static BaseWing Right = new BaseWing();

        public static class Misc 
        {
            public static Transform UserInterface; // UserInterface
            public static Transform QuickMenu; //     UserInterface/Canvas_QuickMenu(Clone)
        }

        public class BaseWing
        {
            internal void Setup(Transform wing)
            {
                Wing = wing;
                WingOpen = wing.Find("Button");
                WingPages = wing.Find("Container/InnerContainer");
                WingMenu = WingPages.Find("WingMenu");
                WingButtons = WingPages.Find("WingMenu/ScrollRect/Viewport/VerticalLayoutGroup");

                ProfilePage = WingPages.Find("Profile");
                ProfileButton = WingButtons.Find("Button_Profile");
            }

            public Transform Wing; //        UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left
            public Transform WingOpen; //    UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button
            public Transform WingPages; //   UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer
            public Transform WingMenu; //    UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu
            public Transform WingButtons; // UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup

            public Transform ProfilePage;
            public Transform ProfileButton;

            public CustomWing CreateCategory(string name)
            {
                CustomWing wing = new CustomWing();

                wing.wing = this;
                wing.page = Object.Instantiate(ProfilePage, WingPages);
                Transform content = wing.page.Find("ScrollRect/Viewport/VerticalLayoutGroup");
                wing.page.gameObject.SetActive(false);
                for (int i = 0; i < content.GetChildCount(); i++)
                    Object.Destroy(content.GetChild(i).gameObject);
                wing.page.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = name;
                Button closeButton = wing.page.GetComponentInChildren<Button>();
                wing.closeButton = closeButton.transform;
                closeButton.onClick = new Button.ButtonClickedEvent();
                closeButton.onClick.AddListener(new System.Action(() => 
                {
                    wing.page.gameObject.SetActive(false);
                    WingMenu.gameObject.SetActive(true);
                }));

                wing.openButton = Object.Instantiate(ProfileButton, WingButtons);
                wing.openButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = name;
                Button bc = wing.openButton.GetComponent<Button>();
                bc.onClick = new Button.ButtonClickedEvent();
                bc.onClick.AddListener(new System.Action(() => {
                    wing.page.gameObject.SetActive(true);
                    WingMenu.gameObject.SetActive(false);
                }));

                return wing;
            }
        }
    }
}
