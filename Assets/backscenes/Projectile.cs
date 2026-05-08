using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float moveSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed *  Time.deltaTime, Space.World);

       /* if (transform.position.y > Camera.main.orthographicSize + 1f)
        {
            Destroy(gameObject);
        }*/

    }
}
