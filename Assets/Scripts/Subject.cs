using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class Subject : MonoBehaviour
{   
    [SerializeField] public float duration = 1.0f;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _imageChild;
    private Image _image;
    public Vector3 endPosition;
    public Vector3 startPosition;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.DOFade(0.0f, 0.0f);
        _text.DOFade(0.0f, 0.0f);
        _imageChild.DOFade(0.0f, 0.0f);

    }

    public IEnumerator MovingToTheScreen(string str)
    {
        _text.text = str;
        var Seq = DOTween.Sequence();

        Seq.Append(transform.DOLocalMoveX(endPosition.x, duration, false));
        Seq.Join(_image.DOFade(1.0f, duration));
        Seq.Join(_imageChild.DOFade(1.0f, duration));
        Seq.Join(_text.DOFade(1.0f, duration));
        Seq.WaitForCompletion();

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

    }

    public IEnumerator MovingOffTheScreen()
    {
        var Seq = DOTween.Sequence();

        Seq.Append(transform.DOLocalMoveX(startPosition.x, duration, false));
        Seq.Join(_image.DOFade(0.0f, duration));
        Seq.Join(_imageChild.DOFade(0.0f, duration));
        Seq.Join(_text.DOFade(0.0f, duration));
        

        yield return  Seq.WaitForCompletion(true);

    }

    public IEnumerator Step(string str)
    {
        yield return StartCoroutine(MovingToTheScreen(str));
        yield return StartCoroutine(MovingOffTheScreen());
        yield break;
    }
}
