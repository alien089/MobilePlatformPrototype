using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float m_DpadSenseX;
    [SerializeField] private float m_DpadSenseY;
    private DirectionType m_DirectionTypes = DirectionType.Still;
    private Vector3 m_TouchStartPosition;
    private Vector3 m_TouchEndPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        Vector3 touchPosition = GetWorldSpacePosition(touch.position);

        if (touch.phase == TouchPhase.Began)
        {
            m_TouchStartPosition = touchPosition;
        }
        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            m_TouchEndPosition = touchPosition;
            GameManager.instance.InputEventManager.TriggerEvent(Constants.PLAYER_MOVE, CalculateDirection(m_TouchStartPosition, m_TouchEndPosition));
        }
    }

    private Vector3 GetWorldSpacePosition(Vector2 touchPosition)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(touchPosition);
        return position;
    }

    public DirectionType CalculateDirection(Vector3 startPosition, Vector3 endPosition)
    {
        DirectionType directionType;

        float x = endPosition.x - startPosition.x;
        float y = endPosition.y - startPosition.y;

        if (Mathf.Abs(x) <= m_DpadSenseX && Mathf.Abs(y) <= m_DpadSenseY)
            directionType = DirectionType.Still;
        else if (Mathf.Abs(x) > Mathf.Abs(y))
            // | = - "assegnazione" | ? - "se vero" | : - "se falso" |
            directionType = x > 0 ? DirectionType.Right : DirectionType.Left;
        else
            directionType = y > 0 ? DirectionType.Up : DirectionType.Down;

        return directionType;
    }

    public void Jump()
    {
        GameManager.instance.InputEventManager.TriggerEvent(Constants.PLAYER_JUMP);
    }
}
