using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Gravity : MonoBehaviour
{
    public float speed = 0.5f;
    private Transform target;

    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("BlackHole").GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BlackHole")
        {
            Destroy(gameObject);
        }
    }



}
