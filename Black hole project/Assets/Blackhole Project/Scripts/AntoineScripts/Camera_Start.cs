using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Start : MonoBehaviour
{
    #region VARIABLES
    public float speed = 0.01f;
    private Transform target;
    public GameObject Player;
    public GameObject Intro_camera;
    public GameObject Earth;
    public GameObject Player_Camera;

    #endregion

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Intro_Camera_target").GetComponent<Transform>();
    }

    // Objects Move toward Blackhole
    void Update()
    {
        StartCoroutine(CheckTheMothership());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Player and Earth appear, First Cam Disapear
        if (col.gameObject.tag == "Intro_Camera_target")
        {
            StartCoroutine(CheckTheEarth());
        }
    }

    // for the player to see the mothership then travelling camera
    IEnumerator CheckTheMothership()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    // for the player to see the Earth then Start
    IEnumerator CheckTheEarth()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("CamInPLace");
        Player.SetActive(true);
        Player_Camera.SetActive(true);
        Earth.SetActive(true);
        Intro_camera.SetActive(false);
    }



}

