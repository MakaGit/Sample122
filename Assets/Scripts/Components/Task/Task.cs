using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Task : ITask
{
    private Action _feedback;
    private MonoBehaviour _coroutineHost;
    private Coroutine _coroutine;
    private IEnumerator _taskAction;

    public static Task Create(MonoBehaviour owner, IEnumerator taskAction)
    {
        return new Task(owner ,taskAction);
    }

    public Task(MonoBehaviour owner ,IEnumerator taskAction)
    {
        _coroutineHost = owner; //TaskManager.CoroutineHost;
        _taskAction = taskAction;
    }

    public void Start()
    {
        if (_coroutine == null)
        {
            _coroutine = _coroutineHost.StartCoroutine(RunTask());
        }
    }

    public void Stop()
    {
        if (_coroutine != null)
        {
            _coroutineHost.StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    public ITask Subscribe(Action feedback)
    {
        _feedback += feedback;

        return this;
    }


    private IEnumerator RunTask()
    {
        yield return _taskAction;

        CallSubscribe();
    }

    private void CallSubscribe()
    {
        if (_feedback != null)
        {
            _feedback();
        }
    }
}