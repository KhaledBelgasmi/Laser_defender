using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject enemyLaser;
    [SerializeField] float projectileSpeed = 10f;
    [Header ("Visual FX")]
    [SerializeField] GameObject enemyExplosion;
    [SerializeField] float durationOfExplosion;
    [Header ("Sound FX")]
    [SerializeField] AudioClip enemyExplosionSound;
    [SerializeField] AudioClip enemyShotSound;
    [SerializeField] [Range (0, 1)] float soundFXVolume = 1;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
        
    {
        CountDownAndShoot();
        Debug.Log(shotCounter);
    }

    private void CountDownAndShoot()
    {        
        shotCounter -= Time.deltaTime;
        //assume 60FPS, 0.016 secs per frame. shotCounter - 0.016 as a maximum i.e. 0.016 is the 
        //max that will be deducted. Need to reach zero or below to fire. 
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(enemyLaser, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(enemyShotSound, Camera.main.transform.position, soundFXVolume);
    }
    
    // This handles what happens when something collides with the enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);        
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    // separate method for death allows multiple hits to be accounted for in gameplay
    private void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(enemyExplosion, transform.position, transform.rotation) as GameObject;
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(enemyExplosionSound, Camera.main.transform.position, soundFXVolume);
    }
}
