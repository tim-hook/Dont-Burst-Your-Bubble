using System.Collections;
using Unity.Burst;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
    [SerializeField] public GameObject m_GoldPickUPPrefab;
    [SerializeField] public GameObject m_BlueSlimes;

    private Advanced_Player_Movement m_Advanced_Player_Movement;

    bool MiniBossSpawnedMinions = false;

    private bool m_DirtyBool = false;

    private BoxCollider2D m_Collider;

    private void Awake()
    {
        m_CurrentHealth = m_MaxHealth;
        m_Collider = GetComponent<BoxCollider2D>(); 
        m_Advanced_Player_Movement = GetComponent<Advanced_Player_Movement>();
        if (gameObject.CompareTag("Enemy") || gameObject.CompareTag("Boss") || gameObject.CompareTag("MiniBoss"))
        {
            m_Animator = GetComponentInChildren<Animator>();
        }
        else
        {
            m_Animator = GetComponent<Animator>();
        }
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

        if (gameObject.CompareTag("MiniBoss"))
        {
            if (m_CurrentHealth <= m_MaxHealth / 2 && MiniBossSpawnedMinions == false)
            {
                MiniBossSpawnedMinions = true;
                Instantiate(m_BlueSlimes, new Vector3(41.36f, -12.8f, 0), Quaternion.EulerRotation(0, 0, 0));
                Instantiate(m_BlueSlimes, new Vector3(45.0f, -12.8f, 0), Quaternion.EulerRotation(0, 0, 0));

            }
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
        else
        {
            GetComponent<NavMeshAgent>().speed = 0;
        }

        m_Animator.SetBool("Dead?", true);

        yield return new WaitForSeconds(m_DeathAnimationTimer);

        if (!gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Boss"))
            {
                SceneManager.LoadScene("Win Screen");
            }

            if (gameObject.CompareTag("MiniBoss"))
            {
                for (int i = 0; i < 5; i++)
                {
                    Instantiate(m_GoldPickUPPrefab, transform.position, Quaternion.EulerRotation(0, 0, 0));
                }
            }
            else
            {
                Instantiate(m_GoldPickUPPrefab, transform.position, Quaternion.EulerRotation(0, 0, 0));
            }
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}
