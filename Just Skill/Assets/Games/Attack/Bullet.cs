using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject explostion;
    public LayerMask enemyMask;

    //stats
    public bool useGravity;


    //Damage
    public int explosionDamage;
    public float explosionRange;

    //LifeTime
    public int maxCollisions;
    public float maxLifeTime;
    public float destroyDelay;
    private bool alreadyExplosing = false;


    //Parameters
    private int collisions;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }
    public void Setup()
    {
        //setBulletProperties
        rb.useGravity = useGravity;
    }
    // Update is called once per frame
    void Update()
    {
        if (collisions >= maxCollisions) Explode();

        maxLifeTime -= Time.deltaTime;
        if (maxLifeTime <= 0) Explode();
    }
    public void Explode()
    {
        if (alreadyExplosing) return;
        alreadyExplosing = true;
        if (explostion != null) Instantiate(explostion, transform.position, Quaternion.identity);

        //Check for ennemy
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, enemyMask);
        for(int i =0;i < enemies.Length; i++)
        {
            //Do smthg on enemies
            enemies[i].GetComponent<Life>().takeDommage(explosionDamage);
        }
        Invoke("DestroyBullet", destroyDelay);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisions++;
        if (collision.collider.CompareTag("Enemy")) Explode();
    }


    //DEBUG
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
