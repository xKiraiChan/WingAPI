using UnityEngine;
using UnityEngine.UI;

namespace KiraiMod.WingAPI.RawUI
{
    public class WingButton
    {
        public TMPro.TextMeshProUGUI text;

        public WingButton(Wing.BaseWing wing, string name, Transform parent, int pos, System.Action onClick)
        {
            Transform button = Object.Instantiate(wing.ProfileButton, parent);
            button.transform.localPosition = new Vector3(button.transform.localPosition.x, pos, button.transform.localPosition.z);

            (text = button.GetComponentInChildren<TMPro.TextMeshProUGUI>()).text = name;

            Button bc = button.GetComponent<Button>();
            bc.onClick = new Button.ButtonClickedEvent();
            bc.onClick.AddListener(onClick);
        }
    }
}
