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

    void Awake ()
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

        if (col.gameObject.tag == "Gravity_attraction3")
        {
            speed = speed + 0.3f;
        }

        if (col.gameObject.tag == "Gravity_attraction2")
        {
            speed = speed + 0.5f;
        }
    
        // Gravity slowed and reduce object
        if (col.gameObject.tag == "Gravity_attraction")
        {
            speed = 0.9f;
            Anim.SetBool("IsReducing", true);
            GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(BufferingCollider());

        }

        // Blackhole teleport object (pool)
        if (col.gameObject.tag == "BlackHole")
        {
            switch (Random.Range(0, 4))
            {
                case 0: transform.position = new Vector3(Random.Range(-90.0f,-80.0f), Random.Range(-50.0f, 60.0f), 0); break;
                case 1: transform.position = new Vector3(Random.Range(-50.0f, 45.0f), Random.Range(55.0f, 65.0f), 0); break;
                case 3: transform.position = new Vector3(Random.Range(45.0f, 60.0f), Random.Range(-20.0f, 60.0f), 0); break;
                case 4: transform.position = new Vector3(Random.Range(20.0f, -60.0f), Random.Range(-60.0f, -70.0f), 0); break;
            }
        }

        IEnumerator BufferingCollider()
        {
            yield return new WaitForSeconds(0.5f);
            GetComponent<CircleCollider2D>().enabled = true;
            Anim.SetBool("IsReducing", false);
        }

    }
}
