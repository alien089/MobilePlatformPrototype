using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    private Dictionary<string, List<Action<object[]>>> m_EventMap;

    public EventManager()
    {
        m_EventMap = new Dictionary<string, List<Action<object[]>>>();
    }

    public void Register(string eventName, Action<object[]> action)
    {
        if (!CheckPrecondition(eventName, action))
            return;

        if (m_EventMap.ContainsKey(eventName))
            m_EventMap[eventName].Add(action);
        else
        {
            m_EventMap.Add(eventName, new List<Action<object[]>>());
            m_EventMap[eventName].Add(action);
        }
    }

    public void Unregister(string eventName, Action<object[]> action)
    {
        if (!CheckPrecondition(eventName, action))
            return;

        if (m_EventMap.ContainsKey(eventName))
            m_EventMap[eventName].Remove(action);
    }

    public void TriggerEvent(string eventName, params object[] parameters)
    {
        if (m_EventMap.ContainsKey(eventName))
        {
            List<Action<object[]>> actions = m_EventMap[eventName];

            foreach (Action<object[]> action in actions)
                action.Invoke(parameters);
        }
    }

    private bool CheckPrecondition(string eventName, Action<object[]> action)
    {
        if (action == null) return false;
        if (string.IsNullOrEmpty(eventName)) return false;

        return true;
    }
}
