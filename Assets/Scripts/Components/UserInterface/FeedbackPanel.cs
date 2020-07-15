using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackPanel : MonoBehaviour
{
    public void OnBackButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.MainMenuPanel);
    }
}
