using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum UIPanelType
{
    Undefined = 0,

    MainMenuPanel = 1,
    ContentsPanel = 2,
    ChapterCompletePanel = 3,
    GameplayPanel = 4,
    PausePanel = 5,
    SettingsPanel = 6,
    HelpPanel = 7,
    SharePanel = 8,
    FeedbackPanel = 9,
    AchievementsPanel = 10
}

public class UserInterfaceManager : MonoBehaviour
{
    public static UserInterfaceManager Instance = null;

    [SerializeField] private CanvasGroup _canvas;

    [SerializeField] private MainMenuPanel _mainMenuPanel = null;
    [SerializeField] private ContentsPanel _contentsPanel = null;
    [SerializeField] private ChapterCompletePanel _chapterCompletePanel = null;
    [SerializeField] private GameplayPanel _gameplayPanel = null;
    [SerializeField] private PausePanel _pausePanel = null;
    [SerializeField] private SettingsPanel _settingsPanel = null;
    [SerializeField] private HelpPanel _helpPanel = null;
    [SerializeField] private SharePanel _sharePanel = null;
    [SerializeField] private FeedbackPanel _feedbackPanel = null;
    [SerializeField] private AchievementsPanel _achievementsPanel = null;


    public void EnablePanel(UIPanelType panelType)
    {
        StartCoroutine(fade(_canvas, 0.0f, 1.0f, panelType));
    }

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator fade(CanvasGroup can, float alpha, float duration, UIPanelType panelType)
    {
        var Seq = DOTween.Sequence();
        Seq.Append(DOTweenModuleUI.DOFade(can, alpha, duration));
        yield return Seq.WaitForCompletion(true);
        ChangePanelType(panelType);
        Seq.Join(DOTweenModuleUI.DOFade(can, 1.0f, duration));
        yield return Seq.WaitForCompletion(true);
    }

    //private IEnumerator change(UIPanelType panelType)
    //{
    //    _mainMenuPanel.gameObject.SetActive(panelType == UIPanelType.MainMenuPanel);
    //    _contentsPanel.gameObject.SetActive(panelType == UIPanelType.ContentsPanel);
    //    _chapterCompletePanel.gameObject.SetActive(panelType == UIPanelType.ChapterCompletePanel);
    //    _gameplayPanel.gameObject.SetActive(panelType == UIPanelType.GameplayPanel);
    //    _pausePanel.gameObject.SetActive(panelType == UIPanelType.PausePanel);

    //    yield break;
    //}

    private void ChangePanelType (UIPanelType panelType)
    {
        _mainMenuPanel.gameObject.SetActive(panelType == UIPanelType.MainMenuPanel);
        _contentsPanel.gameObject.SetActive(panelType == UIPanelType.ContentsPanel);
        _chapterCompletePanel.gameObject.SetActive(panelType == UIPanelType.ChapterCompletePanel);
        _gameplayPanel.gameObject.SetActive(panelType == UIPanelType.GameplayPanel);
        _pausePanel.gameObject.SetActive(panelType == UIPanelType.PausePanel);
        _settingsPanel.gameObject.SetActive(panelType == UIPanelType.SettingsPanel);
        _helpPanel.gameObject.SetActive(panelType == UIPanelType.HelpPanel);
        _sharePanel.gameObject.SetActive(panelType == UIPanelType.SharePanel);
        _feedbackPanel.gameObject.SetActive(panelType == UIPanelType.FeedbackPanel);
        _achievementsPanel.gameObject.SetActive(panelType == UIPanelType.AchievementsPanel);
    }
}
