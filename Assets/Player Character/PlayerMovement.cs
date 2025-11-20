using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    public Vector3 movementDirection;

    [SerializeField] float jumpForce = 5f;
    [SerializeField] float fallMultiplier = 2f;
    [SerializeField] public LayerMask groundLayer;

    bool isSwitching = false;

    Rigidbody rb;
    bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Escape) && !isSwitching)
        {
            //SceneManager.UnloadSceneAsync("MainScene");
            //SceneManager.LoadScene("Inventory", LoadSceneMode.Additive);
            //StartCoroutine(SwitchToInventory());
        }

            movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.position += movementDirection * movementSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    /*IEnumerator SwitchToInventory()
    {
        isSwitching = true;

        // 1. Neue Szene additive laden
        AsyncOperation loadOp = SceneManager.LoadSceneAsync("Inventory", LoadSceneMode.Additive);
        yield return loadOp;

        // 2. Neue Szene aktiv setzen
        Scene inventoryScene = SceneManager.GetSceneByName("Inventory");
        SceneManager.SetActiveScene(inventoryScene);

        // 3. Alte Szene entladen
        AsyncOperation unloadOp = SceneManager.UnloadSceneAsync("MainScene");
        yield return unloadOp;

        isSwitching = false;
    }*/

    private void FixedUpdate()
    {
        CheckGrounded();

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector3 (rb.linearVelocity.x, 0, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void CheckGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }
}
