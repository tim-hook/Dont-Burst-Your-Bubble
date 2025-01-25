using System.Collections;
using UnityEngine;

public class BubbleBlower : MonoBehaviour
{
    [Header("Options:")]
    [Tooltip("This should be the prefab of the attack")]
    [SerializeField] private GameObject m_BubblePrefab;

    [Tooltip("This should be the transform of the player pointer")]
    [SerializeField] private Transform m_PointerTransform;
    [Tooltip("Default is 0.3f")]
    [SerializeField] private float m_CoolDownTime = 0.3f;

     private bool m_Attcking = false;
   private bool m_Cooldown = false;



    private void FixedUpdate()
    {
        if (m_Attcking && !m_Cooldown)
        {
            StartCoroutine(SpawnBullet());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_Attcking = true;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            m_Attcking = false;
        }
     
    }

    private IEnumerator SpawnBullet()
    {
        if (!m_Cooldown )
        {
            m_Cooldown = true;
       
            Instantiate(m_BubblePrefab, m_PointerTransform.position, transform.rotation);

            yield return new WaitForSeconds(m_CoolDownTime);
            m_Cooldown = false;
        }

       
        
    }
}
