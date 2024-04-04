using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class World : MonoBehaviour
{
    private List<ISubscriber> _subscribers;
    private const float TICK_RATE = 0f;
    private float _nextTick;

    private bool _ready = false;
    // Start is called before the first frame update
    void Start()
    {
        _subscribers = new List<ISubscriber>();
        _ready = true;
    }
    public void Subscribe(ISubscriber subscriber)
    {
        if(_subscribers.Contains(subscriber)) return;
        _subscribers.Add(subscriber);
    }
    public void UnSubscribe(ISubscriber subscriber)
    {
        if(_subscribers.Contains(subscriber))
        {
            _subscribers.Remove(subscriber);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(! _ready) return;
        if(Time.time > _nextTick)
        {
            foreach(ISubscriber subscriber in _subscribers)
            {
                subscriber.Notify();
            }
            _nextTick = Time.time + TICK_RATE;
        }
    }
}
