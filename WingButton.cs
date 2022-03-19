using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace WingAPI
{
    public class WingButton
    {
        public Wing wing;
        public TMPro.TextMeshProUGUI text;
        public Transform transform;

        public WingButton(Wing wing, string name, Transform parent, int pos, Action onClick)
        {
            this.wing = wing;

            transform = Object.Instantiate(wing.ProfileButton, parent);
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(420, 144);
            transform.transform.localPosition = new Vector3(0, pos, transform.transform.localPosition.z);

            (text = transform.GetComponentInChildren<TMPro.TextMeshProUGUI>()).text = name;

            Button button = transform.GetComponent<Button>();
            button.onClick = new Button.ButtonClickedEvent();
            button.onClick.AddListener(onClick);
        }

        public WingButton(WingPage page, string name, int index, Action onClick) : this(page.wing, name, page.transform, 320 - (index * 120), onClick) {}
    }
}
