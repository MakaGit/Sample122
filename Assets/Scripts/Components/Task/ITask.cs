using System;

public interface ITask
{
    void Start();
    ITask Subscribe(Action completeCallback);
    void Stop();
}
