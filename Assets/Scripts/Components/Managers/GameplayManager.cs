using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Subject _mainSub;
    [SerializeField] private Subject _leftSub;
    [SerializeField] private Subject _rightSub;

    public Queue<IEnumerator> Scenario = new Queue<IEnumerator>();

    private void Awake()
    {

        Scenario.Enqueue(_mainSub.MovingToTheScreen("Наконец-то вы начали делать игру!"));
        Scenario.Enqueue(_mainSub.TextStep("Я уже думала, гнить мне в этой вселенной без дела!"));
        Scenario.Enqueue(_mainSub.MovingOffTheScreen());
        Scenario.Enqueue(_leftSub.Step("Кто это говорит?"));
        Scenario.Enqueue(_mainSub.Step("О, персонажи появляются… Все как по-настоящему!"));
        Scenario.Enqueue(_leftSub.Step("Что это за звуки? Они у меня в голове?"));
        Scenario.Enqueue(_rightSub.MovingToTheScreen("Ты тоже это слышишь?"));
        Scenario.Enqueue(_rightSub.TextStep("Какой-то писклявый голос…"));
        Scenario.Enqueue(_rightSub.MovingOffTheScreen());
        Scenario.Enqueue(_leftSub.Step("Где мы? И почему мы похожи на блеклые простыни?!"));
        Scenario.Enqueue(_mainSub.MovingToTheScreen("Поздравляю! Мы в прототипе! Но вам еще рано обдумывать, хорошо это или плохо."));
        Scenario.Enqueue(_mainSub.TextStep("У вас это из памяти вытянут и сделают вас послушными куклами. Надеюсь, что красивыми. Ну, бывайте. Мне пора за кулисы."));
        Scenario.Enqueue(_mainSub.TextStep("Да начнется игра!"));
        Scenario.Enqueue(_mainSub.MovingOffTheScreen());

    }

    private void Start()
    {
        StartCoroutine(ProcessNotifications());
    }

    IEnumerator ProcessNotifications()
    {
        while (true)
        {
            while (Scenario.Count > 0)
            {
                yield return StartCoroutine(Scenario.Dequeue());        
            }
            UserInterfaceManager.Instance.EnablePanel(UIPanelType.ChapterCompletePanel);
            yield return null;
        }
    }

    //public IEnumerator startScen(Queue queue,)
    //{
    //    StartCoroutine(ProcessNotifications());
    //}
}
