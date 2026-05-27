using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f; // vitesse � appliquer si vous voulez override la valeur du prefab
    public float spawnOffset = 6f; // d�callage devant le vaisseau

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (projectilePrefab == null)
            {
                Debug.LogWarning("projectilePrefab n'est pas d�fini dans l'Inspector.");
                return;
            }

            // Calculer la position de spawn (devant le vaisseau)
            Vector2 spawnPos = transform.position + transform.up * spawnOffset;

            // Instancier le prefab (on conserve la rotation du vaisseau pour orienter le projectile)
            GameObject projGO = Instantiate(projectilePrefab, spawnPos, transform.rotation);
            //projGO.AddComponent<Projectile>();

            // R�cup�rer le composant Projectile sur l'instance cr��e
            Projectile p = projGO.GetComponent<Projectile>();
            p.moveSpeed = projectileSpeed;
            if (p != null)
            {
                // Optionnel : d�finir la vitesse depuis ce script
                p.moveSpeed = projectileSpeed;
            }
            else
            {
                Debug.LogWarning("Le prefab n'a pas de composant Projectile attach�.");
            }
        }
    }
}
