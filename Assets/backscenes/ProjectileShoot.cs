using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f; // vitesse à appliquer si vous voulez override la valeur du prefab
    public float spawnOffset = 1f; // décallage devant le vaisseau

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (projectilePrefab == null)
            {
                Debug.LogWarning("projectilePrefab n'est pas défini dans l'Inspector.");
                return;
            }

            // Calculer la position de spawn (devant le vaisseau)
            Vector3 spawnPos = transform.position + transform.up * spawnOffset;

            // Instancier le prefab (on conserve la rotation du vaisseau pour orienter le projectile)
            GameObject projGO = Instantiate(projectilePrefab, spawnPos, transform.rotation);

            // Récupérer le composant Projectile sur l'instance créée
            Projectile p = projGO.GetComponent<Projectile>();
            if (p != null)
            {
                // Optionnel : définir la vitesse depuis ce script
                p.moveSpeed = projectileSpeed;
            }
            else
            {
                Debug.LogWarning("Le prefab n'a pas de composant Projectile attaché.");
            }
        }
    }
}
