using TMPro;
using Ui.UiCore;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

namespace Ui.Realization.InteractObjectStatusWindow
{
    public class InteractObjectStatusView : AWindowView
    {
        public TMP_Text ObjectName;
        public TMP_Text ObjectActionTime;
        public TMP_Text LastActionTime;
        public Slider ActionTimeSlider;
        public Button InteractButton;
        public ScrollView ScrollView;
        public RectTransform ScrollViewContentTransform;
    }
}