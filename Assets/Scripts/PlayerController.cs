using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private int score = 0;
    public int health = 5;

    // movement and rotation
    public float speed;
    Rigidbody rb;
    Vector3 forceDirection;
    Vector3 rotationDirection;

    void Start() => rb = GetComponent<Rigidbody>();

	void FixedUpdate()
    {
            // movement
            forceDirection.x = Input.GetAxis("Horizontal");
            forceDirection.z = Input.GetAxis("Vertical");
            rb.AddForce(forceDirection * speed * Time.deltaTime);

            // rotation
            rotationDirection.x = Input.GetAxis("Vertical");
            rotationDirection.z = -Input.GetAxis("Horizontal");
            transform.Rotate(rotationDirection * (speed * 3) * Time.deltaTime);
    }

	void Update()
	{
        if(health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }

	void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Pickup":
                score++;
                Destroy(other.gameObject);
                Debug.Log($"Score: {score}");
                break;
            case "Trap":
                health--;
                Debug.Log($"Health: {health}");
                break;
            case "Goal":
                Debug.Log("You win!");
                break;
        }
    }
}
