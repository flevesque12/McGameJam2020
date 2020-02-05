using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Options : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }

}

