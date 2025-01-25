using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [Header("Options:")]
    [Tooltip("Default is 1.0f")]
    [SerializeField] private float m_Damage = 1.0f;

    [Tooltip("Default is 1.0f")]
    [SerializeField] private float m_AttackCooldown = 1.0f;

    private Health m_Hit;

    private bool m_HitCooldown = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!m_HitCooldown)
        {
            StartCoroutine(HitCooldown(collision));

        }
    }


    private IEnumerator HitCooldown(Collision2D collision)
    {
        m_HitCooldown = true;

        if (m_Hit = collision.gameObject.GetComponent<Health>())
        {
            m_Hit.RemoveHeath(m_Damage);
        }
        yield return new WaitForSeconds(m_AttackCooldown);
        m_HitCooldown = false;
    }
}
