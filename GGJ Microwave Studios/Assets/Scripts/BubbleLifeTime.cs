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


    void Start()
    {
        StartCoroutine(Timer());
    }

    private void Update()
    {
       
        transform.position += transform.up * Time.deltaTime * m_Speed;
        
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
