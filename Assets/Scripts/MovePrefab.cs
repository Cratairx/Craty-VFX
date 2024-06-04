using UnityEngine;

public class MovePrefab : MonoBehaviour
{
    public float speed = 5f; 

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
