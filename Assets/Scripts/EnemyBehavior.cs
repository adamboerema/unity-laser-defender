﻿using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    public float health = 150;

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