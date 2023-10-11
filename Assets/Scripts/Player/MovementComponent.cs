using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementComponent : MonoBehaviour
{
    [SerializeField] private float m_Velocity;
    private Rigidbody2D m_RIgidBody;
    private bool m_IsJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        m_RIgidBody = GetComponent<Rigidbody2D>();
        GameManager.instance.InputEventManager.Register(Constants.PLAYER_MOVE, Move);
        GameManager.instance.InputEventManager.Register(Constants.PLAYER_JUMP, Jump);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(object[] param)
    {
        DirectionType direction = (DirectionType)param[0];

        Vector2 moveDir = Vector2.zero;

        switch (direction)
        {
            case DirectionType.Still:
                moveDir = Vector2.zero;
                break;
            case DirectionType.Right:
                moveDir = Vector2.right;
                break;
            case DirectionType.Left:
                moveDir = Vector2.left;
                break;
        }

        transform.Translate(moveDir * m_Velocity * Time.deltaTime);
    }

    public void Jump(object[] param)
    {
        m_RIgidBody.AddForce(Vector2.up, ForceMode2D.Impulse);
        m_IsJumping = true;
    }
}
