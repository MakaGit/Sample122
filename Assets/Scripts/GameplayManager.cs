using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Subject _mainSub;
    [SerializeField] private Subject _leftSub;
    [SerializeField] private Subject _rightSub;

    private bool test;

    private Queue<IEnumerator> Scenario = new Queue<IEnumerator>();

    private void Awake()
    {
        Scenario.Enqueue(_mainSub.Step("Наконец-то вы начали делать игру!", _mainSub.duration, _mainSub.endPosition, _mainSub.startPosition));
        Scenario.Enqueue(_mainSub.Step("Я уже думала, гнить мне в этой вселенной без дела!", _mainSub.duration, _mainSub.endPosition, _mainSub.startPosition));
        Scenario.Enqueue(_leftSub.Step("Кто это говорит?", _leftSub.duration, _leftSub.endPosition, _leftSub.startPosition));
        Scenario.Enqueue(_mainSub.Step("О, персонажи появляются… Все как по-настоящему!", _mainSub.duration, _mainSub.endPosition, _mainSub.startPosition));
        Scenario.Enqueue(_leftSub.Step("Что это за звуки? Они у меня в голове?", _leftSub.duration, _leftSub.endPosition, _leftSub.startPosition));
        Scenario.Enqueue(_rightSub.Step("Ты тоже это слышишь?", _rightSub.duration, _rightSub.endPosition, _rightSub.startPosition));
        Scenario.Enqueue(_rightSub.Step("Какой-то писклявый голос…", _rightSub.duration, _rightSub.endPosition, _rightSub.startPosition));
        Scenario.Enqueue(_leftSub.Step("Где мы? И почему мы похожи на блеклые простыни?!", _leftSub.duration, _leftSub.endPosition, _leftSub.startPosition));
        Scenario.Enqueue(_mainSub.Step("Поздравляю! Мы в прототипе! Но вам еще рано обдумывать, хорошо это или плохо.", _mainSub.duration, _mainSub.endPosition, _mainSub.startPosition));
        Scenario.Enqueue(_mainSub.Step("У вас это из памяти вытянут и сделают вас послушными куклами. Надеюсь, что красивыми. Ну, бывайте. Мне пора за кулисы.", _mainSub.duration, _mainSub.endPosition, _mainSub.startPosition));
        Scenario.Enqueue(_mainSub.Step("Да начнется игра!", _mainSub.duration, _mainSub.endPosition, _mainSub.startPosition));
    }

    private void Start()
    {
        StartCoroutine(ProcessNotifications());


        //StartCoroutine(_leftSub.Step("Test", _leftSub.duration, _leftSub.endPosition, _leftSub.startPosition));
        //StartCoroutine(_rightSub.Step("Test", _rightSub.duration, _rightSub.endPosition, _rightSub.startPosition));
        //StartCoroutine(_mainSub.Step("Test", _mainSub.duration, _mainSub.endPosition, _mainSub.startPosition));
    }

    IEnumerator ProcessNotifications()
    {
        while (true)
        {
            while (Scenario.Count > 0)
            {
                yield return StartCoroutine(Scenario.Dequeue());
            }
            yield return null;
        }
    }
}
