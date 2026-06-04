using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Transform visual;

    public float moveSpeed;

    private float wallCooldown = 0f;
    private const float WallCooldownTime = 0.5f;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        GameObject go = new GameObject("ColliderVisual");
        go.transform.SetParent(transform);

        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.GetBuiltinResource<Sprite>("Sprites/Square.png");
        sr.color = new Color(0f, 1f, 0f, 0.3f);

        visual = go.transform;

        UpdateColliderFromChildren();
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        visual.localPosition = new Vector3(boxCollider.offset.x, boxCollider.offset.y, 0f);
        visual.localScale = new Vector3(boxCollider.size.x, boxCollider.size.y, 1f);

        if (wallCooldown > 0f)
            wallCooldown -= Time.deltaTime;
    }

    void UpdateColliderFromChildren()
    {
        if (transform.childCount == 0) return;

        float minX = float.MaxValue;
        float maxX = float.MinValue;

        foreach (Transform child in transform)
        {
            if (child.name == "ColliderVisual") continue;

            float worldX = child.position.x;
            if (worldX < minX) minX = worldX;
            if (worldX > maxX) maxX = worldX;
        }

        float localMinX = transform.InverseTransformPoint(new Vector3(minX, 0, 0)).x;
        float localMaxX = transform.InverseTransformPoint(new Vector3(maxX, 0, 0)).x;

        float centerX = (localMinX + localMaxX) / 2f;
        float width = localMaxX - localMinX;

        Vector2 offset = boxCollider.offset;
        offset.x = centerX;
        boxCollider.offset = offset;

        Vector2 size = boxCollider.size;
        size.x = width;
        boxCollider.size = size;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundery" && wallCooldown <= 0f)
        {
            wallCooldown = WallCooldownTime;

            transform.position = new Vector3(
                transform.position.x,
                transform.position.y - 1f,
                transform.position.z
            );

            moveSpeed *= -1;
        }
    }
}