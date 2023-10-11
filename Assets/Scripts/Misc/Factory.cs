using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public static EventManager CreateEventManager()
    {
        return new EventManager();
    }
}
