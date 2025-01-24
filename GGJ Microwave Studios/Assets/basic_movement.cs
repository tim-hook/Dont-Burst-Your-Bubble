using UnityEngine;

public class basic_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private float playerSpeed = 1.0f;

    [SerializeField] private float playerMaxSpeed;

    //awake to find components
    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");

        rb = player.GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = playerDirection * (playerSpeed * playerMaxSpeed) * Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        playerDirection.x = Input.GetAxis("Horizontal");
        playerDirection.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
