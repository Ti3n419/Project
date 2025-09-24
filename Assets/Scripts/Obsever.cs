using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsever : TI3NMono
{
    private static Obsever instance;
    public static Obsever Instance => instance;

    private Dictionary<string, List<Action>> _listeners = new Dictionary<string, List<Action>>();

    protected override void Awake()
    {
        base.Awake();
        if (Obsever.instance != null) return;
        Obsever.instance = this;
    }
    public bool AddListener(string key, Action value)
    {
        List<Action> actions = new List<Action>();
        if (_listeners.ContainsKey(key))
        {
            actions = _listeners[key];
        }
        else
        {
            _listeners.TryAdd(key, actions);
        }
        _listeners[key].Add(value);
        return true;
    }
    public void Notify(string key)
    {
        if (_listeners.ContainsKey(key))
        {
            foreach (Action action in _listeners[key])
            {
                try
                {
                    action?.Invoke();
                }
                catch (Exception e)
                {
                    Debug.LogWarning("Invoke action fail! error: " + e.ToString());
                }
            }
            return;
        }
        Debug.LogErrorFormat("Listener {0} not exist", key);
    }
}
