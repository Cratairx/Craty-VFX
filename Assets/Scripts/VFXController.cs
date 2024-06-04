using UnityEngine;

public class VFXController : MonoBehaviour
{
    // Array of VFX prefabs
    public GameObject[] vfxPrefabs;

    // Direction in which the VFX will move
    public Vector3 moveDirection = new Vector3(1, 0, 0);

    // Speed of the VFX movement
    public float speed = 5f;

    // Duration after which the VFX will be destroyed
    public float lifeTime = 5f;

    void Update()
    {
        // Check for number key presses to spawn corresponding VFX
        for (int i = 0; i < vfxPrefabs.Length && i < 9; i++)
        {
            if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha1 + i)))
            {
                SpawnVFX(i);
            }
        }
    }

    void SpawnVFX(int index)
    {
        if (index >= 0 && index < vfxPrefabs.Length)
        {
            // Instantiate the selected VFX prefab at the current position and rotation
            GameObject vfxInstance = Instantiate(vfxPrefabs[index], transform.position, transform.rotation);

            // Start moving the VFX in the specified direction
            VFXMover mover = vfxInstance.AddComponent<VFXMover>();
            mover.Initialize(moveDirection, speed, lifeTime);
        }
        else
        {
            Debug.LogWarning("VFX index out of range.");
        }
    }
}

public class VFXMover : MonoBehaviour
{
    private Vector3 direction;
    private float speed;
    private float lifeTime;
    private float elapsedTime = 0f;

    // Initialize the mover with direction, speed, and lifetime
    public void Initialize(Vector3 direction, float speed, float lifeTime)
    {
        this.direction = direction.normalized; // Ensure direction is normalized
        this.speed = speed;
        this.lifeTime = lifeTime;
    }

    void Update()
    {
        // Move the VFX in the specified direction
        transform.position += direction * speed * Time.deltaTime;

        // Track the elapsed time
        elapsedTime += Time.deltaTime;

        // Destroy the VFX after its lifetime has passed
        if (elapsedTime >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
