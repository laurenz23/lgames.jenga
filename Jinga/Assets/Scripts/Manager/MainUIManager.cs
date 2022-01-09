using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LGAMES.Jinga
{
    public class MainUIManager : MonoBehaviour
    {

        [ContextMenu("Display Message OnClick")]
        public void DisplayMessageOnClick() {
            Debug.Log("Game Started!", this);
        }

    }
}
