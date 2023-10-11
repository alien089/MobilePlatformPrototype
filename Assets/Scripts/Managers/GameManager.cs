using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private EventManager m_GameEventManager = Factory.CreateEventManager();
    private EventManager m_InputEventManager = Factory.CreateEventManager();
    private UIManager m_UIManager;
    private CheckPointManager m_CheckPointManager;
    private InputManager m_InputManager;
    public EventManager GameEventManager { get => m_GameEventManager; }
    public EventManager InputEventManager { get => m_InputEventManager; }
    public UIManager UIManager { get => m_UIManager; }
    public CheckPointManager CheckPointManager { get => m_CheckPointManager; }
    public InputManager InputManager { get => m_InputManager; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CheckGameOver()
    {

    }

    public void Reload()
    {
        
    }
}
