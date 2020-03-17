using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class ContentsPanel : MonoBehaviour
{
    public void OnChapter1ButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnBackButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.MainMenuPanel);
    }

}
