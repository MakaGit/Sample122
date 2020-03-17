using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterCompletePanel : MonoBehaviour
{
    public void OnExitToMainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
        //UserInterfaceManager.Instance.EnablePanel(UIPanelType.MainMenuPanel);
    }
}
