using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterCompletePanel : MonoBehaviour
{
    public void OnExitToMainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
        //UserInterfaceManager.Instance.EnablePanel(UIPanelType.MainMenuPanel);
    }

    public void OnNextChapterButtonClick()
    {
        int sceneId = SceneManager.GetActiveScene().buildIndex;
        if (sceneId <= 2)
        {
            SceneManager.LoadScene(++sceneId);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        //UserInterfaceManager.Instance.EnablePanel(UIPanelType.MainMenuPanel);
    }
}
