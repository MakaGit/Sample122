using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _tipsText;

    public void OnEnable()
    {
        int randomTipIndex = Random.Range(0, SettingsManager.Instance.Tips.Count);
        _tipsText.text = SettingsManager.Instance.Tips[randomTipIndex];
    }
    public void OnExitButtonClick()
    {
        SceneManager.LoadScene(0);
    }
    public void OnBackButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.GameplayPanel);
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
