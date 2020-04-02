using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TaskManager
{
    public ITask CurrentTask
    {
        get
        {
            return _currentTask;
        }
    }

    private ITask _currentTask;
    private List<ITask> _tasks = new List<ITask>();


    public void AddTask(MonoBehaviour owner, IEnumerator taskAction, Action callback)
    {
        var task = Task.Create(owner, taskAction).Subscribe(callback);

        ProcessingAddedTask(task);
    }

    public void Break()
    {
        if (_currentTask != null)
        {
            _currentTask.Stop();
        }
    }

    public void Restore()
    {
        TaskQueueProcessing();
    }

    public void Clear()
    {
        Break();

        _tasks.Clear();
    }

    private void ProcessingAddedTask(ITask task)
    {
        _tasks.Add(task);

        if (_currentTask == null)
        {
            _currentTask = GetNextTask();

            if (_currentTask != null)
            {
                _currentTask.Subscribe(TaskQueueProcessing).Start();
            }
        }
    }

    private void TaskQueueProcessing()
    {
        _currentTask = GetNextTask();

        if (_currentTask != null)
        {
            _currentTask.Subscribe(TaskQueueProcessing).Start();
        }
    }

    private ITask GetNextTask()
    {
        if (_tasks.Count > 0)
        {
            var returnValue = _tasks[0]; _tasks.RemoveAt(0);

            return returnValue;
        }
        else
        {
            return null;
        }
    }
}
