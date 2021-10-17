using UnityEngine;
using UnityEngine.UI;

namespace KiraiMod.WingAPI.RawUI
{
    public class WingPage
    {
        public Transform page;
        public TMPro.TextMeshProUGUI text;
        public Button closeButton;
        public Button openButton;

        public WingPage(Wing.BaseWing wing, string name)
        {
            page = Object.Instantiate(wing.ProfilePage, wing.WingPages);
            Transform content = page.Find("ScrollRect/Viewport/VerticalLayoutGroup");
            page.gameObject.SetActive(false);

            for (int i = 0; i < content.GetChildCount(); i++)
                Object.Destroy(content.GetChild(i).gameObject);
            page.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = name;

            closeButton = page.GetComponentInChildren<Button>();
            closeButton.onClick = new Button.ButtonClickedEvent();
            closeButton.onClick.AddListener(new System.Action(() =>
            {
                page.gameObject.SetActive(false);
                wing.WingMenu.gameObject.SetActive(true);
            }));

            Transform open = Object.Instantiate(wing.ProfileButton, wing.WingButtons);
            (text = open.GetComponentInChildren<TMPro.TextMeshProUGUI>()).text = name;

            openButton = open.GetComponent<Button>();
            openButton.onClick = new Button.ButtonClickedEvent();
            openButton.onClick.AddListener(new System.Action(() => {
                page.gameObject.SetActive(true);
                wing.WingMenu.gameObject.SetActive(false);
            }));
        }
    }
}
