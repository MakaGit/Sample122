using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    public void OnBackButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.MainMenuPanel);
    }
    public void OnHelpButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.HelpPanel);
    }
    public void OnShareButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.SharePanel);
    }
}
