using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayPanel : MonoBehaviour
{
    public void OnMenuButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.PausePanel);
    }

}
