using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPanel : MonoBehaviour
{
    [SerializeField] GameObject warningPanel = null;
    [SerializeField] Button RestartButton = null;
    [SerializeField] Button StartButton = null;
    [SerializeField] Button ContinueButton = null;
    public void OnContentsButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.ContentsPanel);
    }

    public void OnRestartButtonClick()
    {
        warningPanel.SetActive(true);        
    }

    public void WarningPanelButtonRestrtClick()
    {
        SaveManager.Instance.Restart();

        SceneManager.LoadScene(1);
    }

    public void WarningPanelButtonExitClick()
    {
        warningPanel.SetActive(false);
    }

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Progress"))
        {
            RestartButton.interactable = true;
            ContinueButton.gameObject.SetActive(true);
            StartButton.gameObject.SetActive(false);
        }
        else
        {
            RestartButton.interactable = false;
            ContinueButton.gameObject.SetActive(false);
            StartButton.gameObject.SetActive(true);
        }
    }

    public void OnContinueButtonClick()
    {
        SceneManager.LoadScene(SaveManager.Instance.LoadUnlockedChapter());
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }
    public void OnSettingsButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.SettingsPanel);
    }
    public void OnFeedbackButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.FeedbackPanel);
    }

    public void OnAchievementsButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.AchievementsPanel);
    }
}
