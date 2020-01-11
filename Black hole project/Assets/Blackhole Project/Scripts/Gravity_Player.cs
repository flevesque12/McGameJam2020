using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Player : MonoBehaviour
{
    #region VARIABLES
    public float speed = 0.5f;
    private Transform target;
    Animator Anim;
    Animator Explosion_Anim;
    //ShieldHP
    #endregion

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("BlackHole").GetComponent<Transform>();
        Anim = GetComponent<Animator>();
        Explosion_Anim = GameObject.FindGameObjectWithTag("Explosion").GetComponent<Animator>();
    }

   
    void Update()
    {
        // Objects Move toward Blackhole
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Explosion Game OVER
        /*if(ShieldHP == 0)
            {
               GetComponent<SpriteRenderer>().enabled = false;
               Explosion_Anim.SetBool("IsExploding", true);

            }
       */
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Black hole Game Over
        if (col.gameObject.tag == "Gravity_attraction")
        {
            speed = 0.2f;
            Debug.Log("Gravity_attraction");
            Anim.SetBool("IsReducing", true);
            GetComponent<PlayerMovement>().enabled = false;
        }

        if (col.gameObject.tag == "Gravity_attraction2")
        {
            speed = speed + 1;
        }

        // Blackhole destroy object
        if (col.gameObject.tag == "BlackHole")
        {
            Destroy(gameObject);
        }

        // Collision with Planet
        if (col.gameObject.tag == "Planet")
        {
           
        }

        // Collision with Meteor
        if (col.gameObject.tag == "Meteor")
        {

        }

    }

}
