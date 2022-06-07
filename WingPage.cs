using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace WingAPI
{
    public class WingPage
    {
        public readonly List<WingPage> subpages = new();

        public Wing wing;
        public Transform transform;
        public TMPro.TextMeshProUGUI text;
        public Button closeButton;
        public Button openButton;

        internal WingPage(Wing wing, string name, int? index = null, Transform buttonParent = null)
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
            closeButton.onClick.AddListener(new Action(() =>
            {
                transform.gameObject.SetActive(false);
                wing.openedPages.RemoveAt(wing.openedPages.Count - 1);
                if (wing.openedPages.Count > 0)
                {
                    WingPage prev = wing.openedPages[^1];
                    prev.transform.gameObject.SetActive(true);
                }
                else wing.WingMenu.gameObject.SetActive(true);
            }));

            Transform open = Object.Instantiate(wing.ProfileButton, buttonParent ?? wing.WingButtons);
            openButton = open.GetComponent<Button>();

            if (index is int idx)
            {
                openButton.GetComponent<RectTransform>().sizeDelta = new Vector2(420, 144);
                openButton.transform.localPosition = new Vector3(0, 320 - (idx * 120), transform.transform.localPosition.z);
            }

            (text = open.GetComponentInChildren<TMPro.TextMeshProUGUI>()).text = name;

            openButton.onClick = new Button.ButtonClickedEvent();
            openButton.onClick.AddListener(new Action(() => {
                transform.gameObject.SetActive(true);
                wing.openedPages.Add(this);
                if (wing.openedPages.Count > 1)
                {
                    WingPage prev = wing.openedPages[^2];
                    prev.transform.gameObject.SetActive(false);
                }
                else wing.WingMenu.gameObject.SetActive(false);
            }));

            subpages.Add(this);
        }

        public WingPage CreateNestedPage(string name, int index) => new(wing, name, index, transform);
        public WingButton CreateButton(string name, int index, Action onClick) => new(this, name, index, onClick);
        public WingToggle CreateToggle(string name, int index, bool value, Action<bool> onClick) => new(wing, name, transform, 320 - (index * 120), value, onClick);
    }
}
