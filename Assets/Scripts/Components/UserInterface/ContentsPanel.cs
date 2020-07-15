using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class ContentsPanel : MonoBehaviour
{
    [SerializeField] private Button Chapter1 = null;
    [SerializeField] private Button Chapter2 = null;
    [SerializeField] private Button Chapter3 = null;
    [SerializeField] private Button Chapter4 = null;
    [SerializeField] private Button Chapter5 = null;
    [SerializeField] private Button Chapter6 = null;

    private void OnEnable()
    {
        Chapter1.interactable = false;
        Chapter2.interactable = false;
        Chapter3.interactable = false;
        Chapter4.interactable = false;
        Chapter5.interactable = false;
        Chapter6.interactable = false;

        int unlockedChapter = SaveManager.Instance.LoadUnlockedChapter();

        switch (unlockedChapter)
        {
            case 1:
                Chapter1.interactable = true;
                break;
            case 2:
                Chapter1.interactable = true;
                Chapter2.interactable = true;
                break;
            case 3:
                Chapter1.interactable = true;
                Chapter2.interactable = true;
                Chapter3.interactable = true;
                break;
            default:
                Debug.Log("incorrect scene save");
                break;
        }
    }
    public void OnChapter1ButtonClick()
    {
        SaveManager.Instance.Restart();
        SceneManager.LoadScene(1);
    }
    public void OnChapter2ButtonClick()
    {
        SaveManager.Instance.DeleteChapterProgress();
        SceneManager.LoadScene(2);
    }
    public void OnChapter3ButtonClick()
    {
        SaveManager.Instance.DeleteChapterProgress();
        SceneManager.LoadScene(3);
    }

    public void OnBackButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.MainMenuPanel);
    }

}
