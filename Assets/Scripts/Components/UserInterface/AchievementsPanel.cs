using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class AchievementsPanel : MonoBehaviour
{
    [SerializeField] GameObject achievementPanel = null;
    [SerializeField] CanvasGroup canvasGroup = null;
    [SerializeField] Image achievementImage = null;
    [SerializeField] TMP_Text achievementText = null;

    [SerializeField] List<Node> nodes = null;

    private void OnEnable()
    {
        achievementPanel.SetActive(false);

        for (int i = 0; i < nodes.Count; i++)
        {
            if (PlayerPrefs.HasKey("Node" + (1 + i)))
            {
                nodes[i].gameObject.SetActive(true);
            }
            else
            {
                nodes[i].gameObject.SetActive(false);
            }
        }
    }

    public void OnBackButtonClick()
    {
        UserInterfaceManager.Instance.EnablePanel(UIPanelType.MainMenuPanel);
    }

    public void ShowPanel(string text, Image image, Vector3 vector3)
    {
        StartCoroutine(Show(text, image, vector3));
    }

    public IEnumerator Show(string text, Image image, Vector3 vector3)
    {
        var Seq = DOTween.Sequence();
        Seq.Append(canvasGroup.DOFade(0.0f, 0.5f));

        yield return Seq.WaitForCompletion();

        achievementPanel.SetActive(true);
        achievementImage.sprite = image.sprite;
        achievementText.text = text;
        Seq.Join(canvasGroup.DOFade(1.0f, 0.5f));

        yield break;
    }
}
