using UnityEngine;

public class BubbleBlower : MonoBehaviour
{
    [Header("Options:")]
    [Tooltip("This should be the prefab of the attack")]
    [SerializeField] private GameObject m_BubblePrefab;

    [Tooltip("This should be the transform of the player pointer")]
    [SerializeField] private Transform m_PointerTransform;

    private Pointer_Aiming m_Aiming;

    private bool m_Attcking = false;

    private void Awake()
    {
        m_Aiming = GetComponent<Pointer_Aiming>(); 
        
    }

    private void FixedUpdate()
    {


        if (m_Attcking)
        {
            Instantiate(m_BubblePrefab,m_PointerTransform.position, transform.rotation);
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
}
