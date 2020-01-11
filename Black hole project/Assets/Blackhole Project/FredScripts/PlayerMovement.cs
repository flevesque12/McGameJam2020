using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Range(0,20)]
    public float m_Speed = 3.0f;
    [Range(0, 180)]
    public float m_RotateSpeed = 180f;

    private Rigidbody2D m_Rb;
    private float m_ThrustInput;
    private float m_TurnInput;
    
    //Vector3 m_EulerAngleVelocity;
    #endregion


    // Start is called before the first frame update
    void Start(){        
        m_Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //get our rotation
        Quaternion _rot = transform.rotation;

        float z = _rot.eulerAngles.z;

        z -= Input.GetAxisRaw("Horizontal") * m_RotateSpeed * Time.deltaTime;

        //recreate quaternion
        _rot = Quaternion.Euler(0.0f, 0.0f, z);

        //apply rotation to our ship
        transform.rotation = _rot;


        //move ship
        Vector3 _pos = transform.position;

        Vector3 _vel = new Vector3(0f, Input.GetAxisRaw("Vertical") * m_Speed * Time.deltaTime, 0f);

        _pos += _rot * _vel;

        transform.position = _pos;
    }

    private void FixedUpdate()
    {
        //m_Rb.AddRelativeForce(Vector2.up * m_ThrustInput,ForceMode2D.Force);
        //m_Rb.AddTorque(-m_TurnInput);
        //Quaternion _deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        //m_Rb.MoveRotation(_deltaRotation);
        //m_Rb.velocity = Vector2.up;
    }
}
