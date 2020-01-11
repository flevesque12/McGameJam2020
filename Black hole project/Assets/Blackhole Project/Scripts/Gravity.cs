using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    #region VARIABLES
    public float speed = 0.5f;
    private Transform target;
    Animator Anim;
    #endregion

    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("BlackHole").GetComponent<Transform>();
        Anim = GetComponent<Animator>();
    }

    // Objects Move toward Blackhole
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Gravity slowed and reduce object
        if (col.gameObject.tag == "Gravity_attraction")
        {
            speed = 0.2f;
            Debug.Log("Gravity_attraction");
            Anim.SetBool("IsReducing", true);
        }
        // Blackhole destroy object
        if (col.gameObject.tag == "BlackHole")
        {
            Destroy(gameObject);
        }
    }



}
