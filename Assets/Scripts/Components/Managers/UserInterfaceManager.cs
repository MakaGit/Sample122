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
    GameplayPanel = 4
}

public class UserInterfaceManager : MonoBehaviour
{
    public static UserInterfaceManager Instance = null;

    [SerializeField] private CanvasGroup _canvas;

    [SerializeField] private MainMenuPanel _mainMenuPanel = null;
    [SerializeField] private ContentsPanel _contentsPanel = null;
    [SerializeField] private ChapterCompletePanel _chapterCompletePanel = null;
    [SerializeField] private GameplayPanel _gameplayPanel = null;


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
        yield return StartCoroutine(change(panelType));
        Seq.Append(DOTweenModuleUI.DOFade(can, 1.0f, duration));
    }

    private IEnumerator change(UIPanelType panelType)
    {
        _mainMenuPanel.gameObject.SetActive(panelType == UIPanelType.MainMenuPanel);
        _contentsPanel.gameObject.SetActive(panelType == UIPanelType.ContentsPanel);
        _chapterCompletePanel.gameObject.SetActive(panelType == UIPanelType.ChapterCompletePanel);
        _gameplayPanel.gameObject.SetActive(panelType == UIPanelType.GameplayPanel);

        yield break;
    }

}
