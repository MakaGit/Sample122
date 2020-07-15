﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharePanel : MonoBehaviour
{
    public void OnBackButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.SettingsPanel);
    }
    public void InGameOnBackButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.PausePanel);
    }
}
