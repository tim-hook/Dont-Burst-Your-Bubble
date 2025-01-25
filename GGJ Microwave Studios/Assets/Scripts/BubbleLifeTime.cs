using System.Collections;
using Unity.Burst;
using Unity.VisualScripting;
using UnityEngine;
[BurstCompile]
// TODO: MAKE DEATH ANIMATION FOR PROJECTILE
public class BubbleLifeTime : MonoBehaviour
{
    [Header("Options:")]
    [Tooltip("Default is 2.0f")]
    [SerializeField] private float m_Lifetime = 2.0f;

    [Tooltip("Default is 1.0f")]
    [SerializeField] private float m_DeathAnimationTime = 0.5f;

    [Tooltip("Default is 1.0f")]
    [SerializeField] private float m_Speed = 1.0f;

    [Tooltip("Default is 1.0f")]
    [SerializeField] private float m_Damage = 1.0f;

     private Pointer_Aiming m_Aiming;

    private bool m_BubblePopped = false;

    private Animator m_Animator;
    private ParticleSystem m_particleSystem;
    private AudioManagerScript m_AudioManagerScript;

    private Vector2 m_BulletNormal;

    private Health m_Hit;

    private bool m_Damaged =false;

    private void Awake()
    {

        m_Aiming = GameObject.FindWithTag("Player").GetComponentInChildren<Pointer_Aiming>();
        m_particleSystem = GetComponent<ParticleSystem>();
        m_AudioManagerScript = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>();
        // Needs Death Animation
        m_Animator = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(Timer());
        m_BulletNormal = m_Aiming.m_NormalDirection;
    }

    private void Update()
    {
       
        if (!m_BubblePopped)
        {
            Vector2 newPos = (Vector2)transform.position + m_BulletNormal * Time.deltaTime * m_Speed;

            transform.position = newPos;
        }
        
        
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(m_Lifetime);
        StartCoroutine(DeathAnimation());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(DeathAnimation());

        if (!m_Damaged)
        {
            if (m_Hit = collision.gameObject.GetComponent<Health>())
            {
                m_Hit.RemoveHeath(m_Damage);
            }
        }
    
    }

    private IEnumerator DeathAnimation()
    {
        if (!m_BubblePopped)
        {
            m_BubblePopped = true;
            Destroy(m_particleSystem);

            // Needs Death Animation
             m_Animator.SetBool("Dead?", true);

            m_AudioManagerScript.PlaySound("BubblePopSFX");

            // Change this depending on animation length
            yield return new WaitForSeconds(m_DeathAnimationTime);
            Destroy(gameObject);
        }
        
    }
}
