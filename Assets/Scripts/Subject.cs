using System.Collections;
using System.Collections.Generic;
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
    //private Vector3 endPositionloc;
    //private Vector3 startPositionloc;
    public Vector3 endPosition;
    public Vector3 startPosition;
    private bool _flag;

    private void Awake()
    {

        //startPosition = transform.position;
        //endPosition = transform.InverseTransformPoint(transform.);
        //endPosition = transform.position;

        _image = GetComponent<Image>();

        _image.DOFade(0.0f, 0.0f);
        _text.DOFade(0.0f, 0.0f);
        _imageChild.DOFade(0.0f, 0.0f);

    }
    private void Start()
    {

        //var Seq = DOTween.Sequence();

        //    Seq.Append(transform.DOMove(endPosition, duration, false));
        //    Seq.Join(_image.DOFade(1.0f, duration));
        //    Seq.Join(_imageChild.DOFade(1.0f, duration));
        //    Seq.Join(_text.DOFade(1.0f, duration));
        //    Seq.AppendInterval(1.0f);

        //    Seq.Append(transform.DOMove(startPosition, duration, false));
        //    Seq.Join(_image.DOFade(0.0f, duration));
        //    Seq.Join(_imageChild.DOFade(0.0f, duration));
        //    Seq.Join(_text.DOFade(0.0f, duration));
        //    Seq.AppendInterval(1.0f);

    }

    public IEnumerator Step(string str, float duration, Vector3 endPosition, Vector3 startPosition)
    {
        _text.text = str;

        var Seq = DOTween.Sequence();

        Seq.Append(transform.DOLocalMoveX(endPosition.x, duration, false));
        Seq.Join(_image.DOFade(1.0f, duration));
        Seq.Join(_imageChild.DOFade(1.0f, duration));
        Seq.Join(_text.DOFade(1.0f, duration));

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        Seq.Append(transform.DOLocalMoveX(startPosition.x, duration, false));
        Seq.Join(_image.DOFade(0.0f, duration));
        Seq.Join(_imageChild.DOFade(0.0f, duration));
        Seq.Join(_text.DOFade(0.0f, duration));

        yield return null;

    }
}
