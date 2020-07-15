using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterCompletePanel : MonoBehaviour
{
    [SerializeField] private Button NextCapterButton = null;

    private int sceneId = 0;
    public void OnExitToMainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnNextChapterButtonClick()
    {
        SceneManager.LoadScene(sceneId);
    }

    private void OnEnable()
    {
        sceneId = SaveManager.Instance.GetCurrentScene();

        if (sceneId <= 2)
        {
            sceneId++;
        }
        else
        {
            NextCapterButton.interactable = false;
        }
    }
}
