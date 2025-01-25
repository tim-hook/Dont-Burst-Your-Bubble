using System.Collections;
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

    [SerializeField]public bool m_Dead = false;
    [Tooltip("Default is 1.0f")]
    [SerializeField] private float m_DeathAnimationTimer = 1.0f;

    [SerializeField] private Animator m_Animator;

    private Advanced_Player_Movement m_Advanced_Player_Movement;


    private bool m_DirtyBool = false;

    private BoxCollider2D m_Collider;

    private void Awake()
    {
        m_CurrentHealth = m_MaxHealth;
        m_Collider = GetComponent<BoxCollider2D>(); 
        m_Advanced_Player_Movement = GetComponent<Advanced_Player_Movement>();

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

        if (m_Dead && !m_DirtyBool)
        {
            StartCoroutine(DeathAnimation());
        }

    }


    public void AddHeath(float health)
    {
        m_CurrentHealth += health;
    }

    public void RemoveHeath(float health)
    {
        m_CurrentHealth -= health;
    }

    private IEnumerator DeathAnimation()
    {
        m_DirtyBool = true;

        if (m_Collider)
        {
            m_Collider.enabled = false;
        }

        if (m_Advanced_Player_Movement)
        {
            m_Advanced_Player_Movement.m_MoveSpeed = 0.0f;
        }

        m_Animator.SetBool("is dead?", true);

        yield return new WaitForSeconds(m_DeathAnimationTimer);

        if (!gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
