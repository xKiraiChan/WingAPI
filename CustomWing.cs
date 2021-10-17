using UnityEngine;
using UnityEngine.UI;
using static KiraiMod.WingAPI.Wing;

namespace KiraiMod.WingAPI
{
    public class CustomWing
    {
        internal BaseWing wing;
        
        public Transform page;
        public Transform openButton;
        public Transform closeButton;

        public Transform CreateButton(string name, int pos, System.Action onClick)
        {
            Transform button = Object.Instantiate(wing.ProfileButton, page);
            button.transform.localPosition = new Vector3(button.transform.localPosition.x, pos, button.transform.localPosition.z);
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = name;
            Button bc = button.GetComponent<Button>();
            bc.onClick = new Button.ButtonClickedEvent();
            bc.onClick.AddListener(onClick);

            return button;
        }
    }
}
