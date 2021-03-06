﻿using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class Subject : MonoBehaviour
{   
    [SerializeField] public float duration = 1.0f;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _textName;
    [SerializeField] private Image _imageChild;
    private Image _image;
    public Vector3 endPosition;
    public Vector3 startPosition;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.DOFade(0.0f, 0.0f);
        _text.DOFade(0.0f, 0.0f);
        _textName.DOFade(0.0f, 0.0f);
        _imageChild.DOFade(0.0f, 0.0f);

    }

    public IEnumerator EmptyMovingToTheScreen()
    {
        var Seq = DOTween.Sequence();

        Seq.Append(transform.DOLocalMoveX(endPosition.x, duration, false));
        Seq.Join(_image.DOFade(1.0f, duration));
        yield return Seq.WaitForCompletion();

    }

    public IEnumerator MovingToTheScreen(string str)
    {
        _text.text = str;
        var Seq = DOTween.Sequence();

        Seq.Append(transform.DOLocalMoveX(endPosition.x, duration, false));
        Seq.Join(_image.DOFade(1.0f, duration));
        Seq.Join(_imageChild.DOFade(1.0f, duration));
        Seq.Join(_text.DOFade(1.0f, duration));
        Seq.Join(_textName.DOFade(1.0f, duration));

        yield return Seq.WaitForCompletion();

    }

    public IEnumerator MovingOffTheScreen()
    {
        var Seq = DOTween.Sequence();

        Seq.Append(transform.DOLocalMoveX(startPosition.x, duration, false));
        Seq.Join(_image.DOFade(0.0f, duration));
        Seq.Join(_imageChild.DOFade(0.0f, duration));
        Seq.Join(_text.DOFade(0.0f, duration));
        Seq.Join(_textName.DOFade(0.0f, duration));


        yield return  Seq.WaitForCompletion(true);

    }

    public IEnumerator FadeText()
    {
        var Seq = DOTween.Sequence();

        Seq.Append(_imageChild.DOFade(0.0f, duration));
        Seq.Join(_text.DOFade(0.0f, duration));
        Seq.Join(_textName.DOFade(0.0f, duration));

        yield return Seq.WaitForCompletion(true);
    }

    public IEnumerator ChangeText(string str)
    {
        _text.text = str;
        var Seq = DOTween.Sequence();

        Seq.Join(_imageChild.DOFade(1.0f, duration));
        Seq.Join(_text.DOFade(1.0f, duration));
        Seq.Join(_textName.DOFade(1.0f, duration));
        yield return Seq.WaitForCompletion();

    }

    public IEnumerator Step(string str)
    {
        yield return StartCoroutine(MovingToTheScreen(str));
        yield return StartCoroutine(MovingOffTheScreen());
        yield break;
    }

    public IEnumerator TextStep(string str)
    {
        yield return StartCoroutine(FadeText());
        yield return StartCoroutine(ChangeText(str));
        yield break;
    }
    public void ChangeCharacter(int index)
    {
        _image.sprite = SettingsManager.Instance.Characters[index];
    }
    
    public void ChangeName(string name)
    {
        _textName.text = name + ":";
    }
}
