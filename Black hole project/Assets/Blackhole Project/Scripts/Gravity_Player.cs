using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gravity_Player : MonoBehaviour
{
    #region VARIABLES
    public float speed = 0.5f;
    private Transform target;
    Animator Anim;
    Animator Explosion_Anim;
    public GameObject GameOver;
    public GameObject Victory;
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
        if(GetComponent<PlayerShield>().m_CurrentShieldPoint == 0)
            {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("Fireblast").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("Shield").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("Explosion").GetComponent<SpriteRenderer>().enabled = true;
            Explosion_Anim.SetBool("IsExploding", true);
            GameOver.SetActive(true);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().enabled = true;
            StartCoroutine(GameOver_Explosion());
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Black hole Reducing and losing control
        if (col.gameObject.tag == "Gravity_attraction")
        {
            speed = 0.2f;
            Anim.SetBool("IsReducing", true);
            GetComponent<PlayerMovement>().enabled = false;
        }

        if (col.gameObject.tag == "Gravity_attraction2")
        {
            speed = speed + 0.5f;
        }

        // Blackhole destroy and GAME OVER
        if (col.gameObject.tag == "BlackHole")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("Fireblast").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("Shield").GetComponent<SpriteRenderer>().enabled = false;
            GameOver.SetActive(true);
            StartCoroutine(ReturnToMenu());
            // Coroutine2

        }

        // Collision with Planet
        if (col.gameObject.tag == "Planet")
        {
            GetComponent<PlayerShield>().TakeDamage(25f);
        }

        // Collision with Meteor
        if (col.gameObject.tag == "Meteor")
        {
            GetComponent<PlayerShield>().TakeDamage(15f);
        }

        // Victory! - Collision with Mothership
        if (col.gameObject.tag == "Mothership")
        {
            GameObject.FindGameObjectWithTag("Mothership").GetComponent<AudioSource>().enabled = true;
            Victory.SetActive(true);
            StartCoroutine(ReturnToMenu());
        }
    }

    IEnumerator GameOver_Explosion()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenuScene");
    }

    IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenuScene");
    }
}
