using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float spawnOffset = 6f;
    public float shootCooldown = 0.5f; // seconds between shots

    private float lastShotTime = -Mathf.Infinity; // allows shooting immediately on start

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Time.time < lastShotTime + shootCooldown)
                return; // still on cooldown

            lastShotTime = Time.time;

            if (projectilePrefab == null)
            {
                Debug.LogWarning("projectilePrefab n'est pas défini dans l'Inspector.");
                return;
            }

            Vector2 spawnPos = transform.position + transform.up * spawnOffset;
            GameObject projGO = Instantiate(projectilePrefab, spawnPos, transform.rotation);

            Projectile p = projGO.GetComponent<Projectile>();
            if (p != null)
            {
                p.moveSpeed = projectileSpeed;
            }
            else
            {
                Debug.LogWarning("Le prefab n'a pas de composant Projectile attaché.");
            }
        }
    }
}
