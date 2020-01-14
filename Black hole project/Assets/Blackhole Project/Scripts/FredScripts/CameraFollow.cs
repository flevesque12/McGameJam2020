using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform m_Player;
    Vector3 m_Newpos;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        
        
    }

    private void LateUpdate()
    {

        m_Newpos = new Vector3(m_Player.transform.position.x, m_Player.transform.position.y, -10f);
        transform.position = m_Newpos;
    }
}
