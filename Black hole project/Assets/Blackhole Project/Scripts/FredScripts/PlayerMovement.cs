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
    public GameObject Fireblast;
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

        //get z angle
        float z = _rot.eulerAngles.z;
        
        z -= Input.GetAxisRaw("Horizontal") * m_RotateSpeed * Time.deltaTime;

        //recreate quaternion
        _rot = Quaternion.Euler(0.0f, 0.0f, z);

        //apply rotation to our ship
        transform.rotation = _rot;

        //move ship
        Vector3 _pos = transform.position;
        if (Input.GetButton("Submit"))
        {
            Vector3 _vel = new Vector3(0f, m_Speed * Time.deltaTime, 0f);
            _pos += _rot * _vel;
            Fireblast.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetButtonUp("Submit"))
        {
            Fireblast.GetComponent<SpriteRenderer>().enabled = false;
        }


                transform.position = _pos;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ContactPoint2D[] contact = collision.contacts;

        /*
        foreach(ContactPoint2D c in collision.contacts)
        {
            //Vector2 _pos = new Vector2(transform.position.x, transform.position.y);
            //Vector2 _direction = (_pos - c.point).normalized;
            //transform.Translate(-_direction);
            print(c.collider.name + " hit " + c.otherCollider.name);
            Debug.DrawRay(c.point, c.normal, Color.red);
        }*/

        if(collision.gameObject.tag == "Meteor" || collision.gameObject.tag == "Planet")
        {
           Vector2 _distance = transform.position - collision.transform.position;
            transform.position = new Vector2(transform.position.x + _distance.x, transform.position.y + _distance.y);
            //useless change
        }

        //Debug.Log("Colliding");
    }

    public IEnumerator Knockback()
    {
        yield return 0;
    }

}
