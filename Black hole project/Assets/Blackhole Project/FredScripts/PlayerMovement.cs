using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0,20)]
    public float m_Speed;

    private Rigidbody2D m_Rb;

    private Vector2 m_PlayerThrustMovementVector;
    private Vector2 m_MovementVector;

    private bool m_CanMove = true;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerThrustMovementVector = new Vector2(0.0f, 1.0f);
        m_Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            m_Rb.AddForce(m_PlayerThrustMovementVector, ForceMode2D.Force);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            m_Rb.AddForce(Vector2.zero);
        }
    }

   

    public void PlayerRotation()
    {

    }

    public void HandleInput()
    {
        m_MovementVector.x = Input.GetAxisRaw("Horizontal") * m_Speed;
    }
}
