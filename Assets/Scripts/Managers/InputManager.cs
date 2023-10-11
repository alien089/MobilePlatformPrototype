using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float m_DpadSenseX;
    [SerializeField] private float m_DpadSenseY;
    private DirectionType m_DirectionTypes = DirectionType.Still;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetWorldspacePosition(Vector2 touchPosition)
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
}
