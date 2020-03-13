using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Subject _mainSub;
    [SerializeField] private Subject _leftSub;
    [SerializeField] private Subject _rightSub;

    private Queue<IEnumerator> Scenario = new Queue<IEnumerator>();

    private void Start()
    {
        //StartCoroutine(_leftSub.Step("Test", _leftSub.duration, _leftSub.endPosition, _leftSub.startPosition));
        //StartCoroutine(_rightSub.Step("Test", _rightSub.duration, _rightSub.endPosition, _rightSub.startPosition));
        //StartCoroutine(_mainSub.Step("Test", _mainSub.duration, _mainSub.endPosition, _mainSub.startPosition));

    }

}
