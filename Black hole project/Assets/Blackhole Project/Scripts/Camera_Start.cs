using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Start : MonoBehaviour
{
    #region VARIABLES
    public float speed = 2f;
    private Transform target;
    public GameObject Player;
    public GameObject Intro_camera;
    public GameObject Earth;

    #endregion

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Intro_Camera_target").GetComponent<Transform>();
    }

    // Objects Move toward Blackhole
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Player and Earth appear, First Cam Disapear
        if (col.gameObject.tag == "Intro_Camera_target")
        {
            Debug.Log("CamInPLace");
            Player.SetActive(true);
            Earth.SetActive(true);
            Intro_camera.SetActive(false);     
        }

    }

}

