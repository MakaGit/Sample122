using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuPanel : MonoBehaviour
{
    public void OnContentsButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.ContentsPanel);
    }

}
