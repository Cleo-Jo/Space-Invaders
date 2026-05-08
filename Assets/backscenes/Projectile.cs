using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed *  Time.deltaTime, Space.World);

    }
}
