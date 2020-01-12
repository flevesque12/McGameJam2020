using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShield : MonoBehaviour
{

    [Range(0, 100)]
    [SerializeField]
    private float m_MaxShield = 100f;

    public float m_CurrentShieldPoint = 0f;

    public Image m_ShieldImgUI = null;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentShieldPoint = m_MaxShield;
        //m_ShieldImgUI = GetComponent<Image>();

        UpdateShieldUI();        
    }
    
    public void UpdateShieldUI()
    {
        float _fillAmount = (float)m_CurrentShieldPoint / (float)m_MaxShield;
        m_ShieldImgUI.fillAmount = _fillAmount;        
    }

    public void TakeDamage(float dmgValue)
    {
        m_CurrentShieldPoint -= dmgValue;
        Mathf.Clamp(m_CurrentShieldPoint, 0, m_MaxShield);

        UpdateShieldUI();

        if (m_CurrentShieldPoint <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        m_CurrentShieldPoint = 0;
        UpdateShieldUI();
    }

   
}
