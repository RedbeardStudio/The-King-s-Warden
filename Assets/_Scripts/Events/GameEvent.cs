using System;
using UnityEngine;


/*Base class for all Game Events
*/
public class GameEvent<T>
{
    private event Action<T> listeners;

    public void Subscribe(Action<T> listener)
    {
        listeners += listener;
    }

    public void Unsubscribe(Action<T> listener)
    {
        listeners -= listener;
    }


    public void Raise(T data)
    {
        listeners?.Invoke(data);
    }
}
