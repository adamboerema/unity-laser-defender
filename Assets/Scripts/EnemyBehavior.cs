using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    public GameObject projectile;
    public float health = 150;
    public float projectileSpeed = 5;
    public float shotsPerSeconds = 0.5f;

    void Update()
    {
        float probability = Time.deltaTime * shotsPerSeconds;
        if(Random.value < probability)
        {
            Fire();
        }
    }

    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0, -1f, 0);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        missile.rigidbody2D.velocity = new Vector2(0, -projectileSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider);
        Projectile missile = collider.gameObject.GetComponent<Projectile>();

        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            Debug.Log("Hit by a projectile");
        }
    }
}
