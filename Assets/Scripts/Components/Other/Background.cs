using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Background : MonoBehaviour
{
    [SerializeField] private Image image = null;
    private Vector3 middlePosition;
    private Vector3 leftPosition;
    private Vector3 rightPosition;

    private void OnEnable()
    {
        ChangePositions();
    }
    private void ChangePositions()
    {
        leftPosition.x = (image.preferredWidth / 2) - Screen.width / 2;
        rightPosition.x = -(image.preferredWidth / 2) + Screen.width / 2;
    }

    public IEnumerator MovingToMiddlePosition()
    {
        transform.DOLocalMoveX(middlePosition.x, 0.5f, false);
        yield break;
    }

    public IEnumerator MovingToLeftPosition()
    {
        transform.DOLocalMoveX(leftPosition.x, 0.5f, false);
        yield break;
    }

    public IEnumerator MovingToRightPosition()
    {
        transform.DOLocalMoveX(rightPosition.x, 0.5f, false);
        yield break;
    }

    public IEnumerator ChangeBackground(int index)
    {
        var Seq = DOTween.Sequence();
        Seq.Append(image.DOFade(0.0f, 1.0f));

        yield return Seq.WaitForCompletion(true);

        image.sprite = SettingsManager.Instance.Backgrounds[index];
        ChangePositions();
        Seq.Join(image.DOFade(1.0f, 1.0f));

        yield return Seq.WaitForCompletion(true);
    }

    public IEnumerator Fade()
    {
        var Seq = DOTween.Sequence();
        Seq.Append(image.DOFade(0.0f, 1.0f));
        yield return Seq.WaitForCompletion(true);
    }

    public IEnumerator UnFade()
    {
        var Seq = DOTween.Sequence();
        Seq.Append(image.DOFade(1.0f, 1.0f));
        yield return Seq.WaitForCompletion(true);
    }
}
