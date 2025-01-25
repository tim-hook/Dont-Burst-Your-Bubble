using Unity.Burst;
using Unity.VisualScripting;
using UnityEngine;

[BurstCompile]
public class Health : MonoBehaviour
{
    [Header("Options:")]
    [Tooltip("Starts as maxhealth")]
     public float m_CurrentHealth = 0.0f;
    [Tooltip("Default is 1.0f")]
    [SerializeField] public float m_MaxHealth = 1.0f;

    [SerializeField ]public bool m_Dead = false;


    private void Awake()
    {
        m_CurrentHealth = m_MaxHealth;
    }

    private void Update()
    {
        if (m_CurrentHealth <= 0.0f)
        {
            m_CurrentHealth = 0.0f;
            m_Dead = true;
        }

        if (m_CurrentHealth > m_MaxHealth)
        {
            m_CurrentHealth = m_MaxHealth;
        }
    }


    private void AddHeath(float health)
    {
        m_CurrentHealth += health;
    }

    private void RemoveHeath(float health)
    {
        m_CurrentHealth -= health;
    }


}
