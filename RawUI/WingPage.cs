using UnityEngine;
using UnityEngine.UI;

namespace KiraiMod.WingAPI.RawUI
{
    public class WingPage
    {
        public Wing.BaseWing wing;
        public Transform transform;
        public TMPro.TextMeshProUGUI text;
        public Button closeButton;
        public Button openButton;

        public WingPage(Wing.BaseWing wing, string name)
        {
            this.wing = wing;

            transform = Object.Instantiate(wing.ProfilePage, wing.WingPages);
            Transform content = transform.Find("ScrollRect/Viewport/VerticalLayoutGroup");
            transform.gameObject.SetActive(false);

            for (int i = 0; i < content.GetChildCount(); i++)
                Object.Destroy(content.GetChild(i).gameObject);
            transform.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = name;

            closeButton = transform.GetComponentInChildren<Button>();
            closeButton.onClick = new Button.ButtonClickedEvent();
            closeButton.onClick.AddListener(new System.Action(() =>
            {
                transform.gameObject.SetActive(false);
                wing.WingMenu.gameObject.SetActive(true);
            }));

            Transform open = Object.Instantiate(wing.ProfileButton, wing.WingButtons);
            (text = open.GetComponentInChildren<TMPro.TextMeshProUGUI>()).text = name;

            openButton = open.GetComponent<Button>();
            openButton.onClick = new Button.ButtonClickedEvent();
            openButton.onClick.AddListener(new System.Action(() => {
                transform.gameObject.SetActive(true);
                wing.WingMenu.gameObject.SetActive(false);
            }));
        }
    }
}
