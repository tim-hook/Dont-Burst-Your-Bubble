using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleLifeTime : MonoBehaviour
{
    [Header("Options:")]
    [Tooltip("Default is 2.0f")]
    [SerializeField] private float m_Lifetime = 2.0f;

    [Tooltip("Default is 1.0f")]
    [SerializeField] private float m_Speed = 1.0f;

     private Pointer_Aiming m_Aiming;

    Vector2 m_normal;

    private void Awake()
    {

        m_Aiming = GameObject.FindWithTag("Player").GetComponentInChildren<Pointer_Aiming>();
    }

    void Start()
    {
        StartCoroutine(Timer());
        m_normal = m_Aiming.m_NormalDirection;
    }

    private void Update()
    {
       
        Vector2 newPos =  (Vector2)transform.position + m_normal * Time.deltaTime * m_Speed;

        transform.position = newPos;
        
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(m_Lifetime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         Destroy(gameObject);
    }

}
