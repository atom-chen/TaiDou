using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;

namespace UIEngine
{

    public class UITools : MonoBehaviour
    {
        public delegate void VoidDelegate();
        public VoidDelegate onClick;
        //按钮响应
        public static void AddClick(Button button, VoidDelegate onClick )
        {
            if (button == null) { return; }
            button.onClick = new Button.ButtonClickedEvent();
            button.onClick.AddListener(() =>
            {
                onClick();
            });
        }
       
    }

}
