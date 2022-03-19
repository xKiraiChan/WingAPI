using System;
using UnityEngine;

namespace WingAPI
{
    public class WingToggle
    {
        private static Color32 on = new(0x00, 0xFF, 0x00, 0xFF);
        private static Color32 off = new(0xFF, 0x00, 0x00, 0xFF);

        private bool state;
        private readonly Action<bool> onClick;

        public Wing wing;
        public WingButton button;

        public bool State
        {
            get => state;
            set
            {
                if (state == value) return;
                button.text.color = value ? on : off;
                onClick(state = value);
            }
        }

        public WingToggle(Wing wing, string name, Transform parent, int pos, bool initial, Action<bool> onClick)
        {
            this.wing = wing;
            this.onClick = onClick;

            button = new WingButton(wing, name, parent, pos, () => State ^= true);

            button.text.color = initial ? on : off;
        }
    }
}
