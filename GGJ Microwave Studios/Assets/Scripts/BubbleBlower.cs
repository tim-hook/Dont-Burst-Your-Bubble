using System.Collections;
using Unity.Burst;
using UnityEngine;

//TODO: MAKE UI FOR CHARGE METER
// MAYBE ZOOM CAMERA WHEN CHARGING

[BurstCompile]
public class BubbleBlower : MonoBehaviour
{
    [Header("Options:")]
    [Tooltip("This should be the prefab of the attack")]
    [SerializeField] private GameObject m_BubblePrefab;

    [Tooltip("This should be the transform of the player pointer")]
    [SerializeField] private Transform m_PointerTransform;
    [Tooltip("Default is 0.3f")]
    [SerializeField] private float m_CoolDownTime = 0.3f;

    [Tooltip("Default is 100.0f")]
    [SerializeField] public float m_MaxCharge = 100.0f;

    [Tooltip("Should Reset at a full charge")]
    [SerializeField] private float m_CurrentCharge = 0;

    [Tooltip("Default is 50.0f")]
    [SerializeField] private float m_ChargeSpeed = 50.0f;

     private bool m_FullyCharged = false;
     private bool m_Charging = false;
     private bool m_Cooldown = false;

    [SerializeField] private CameraShake m_CameraShake;



    private void FixedUpdate()
    {
        if (m_Charging)
        {
            m_CurrentCharge += m_ChargeSpeed * Time.fixedDeltaTime;
        }
        else
        {
            m_CurrentCharge -= m_ChargeSpeed * Time.fixedDeltaTime;
        }


        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (m_CurrentCharge >= m_MaxCharge)
        {
            m_CurrentCharge = m_MaxCharge;
            m_FullyCharged = true;
        }
        else if (m_CurrentCharge < m_MaxCharge)
        {
            m_FullyCharged = false ;
        }

        if ( m_CurrentCharge < 0.0f)
        {
            m_CurrentCharge = 0.0f;
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_Charging = true;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            m_Charging = false;

            if (m_FullyCharged && !m_Cooldown)
            {
                StartCoroutine(SpawnBullet());
            }
        }
     
    }

    private IEnumerator SpawnBullet()
    {
        if (!m_Cooldown )
        {
            m_Cooldown = true;
       
            StartCoroutine(m_CameraShake.Shake(0.1f,0.01f));
            Instantiate(m_BubblePrefab, m_PointerTransform.position, transform.rotation);
            m_CurrentCharge = 0.0f;

            yield return new WaitForSeconds(m_CoolDownTime);
            m_Cooldown = false;
        }
    }
}
