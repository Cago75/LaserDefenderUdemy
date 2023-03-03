using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed      = 10f;
    [SerializeField] float ProjectileLifetime   = 5f;
    [SerializeField] float firingRate           = 0.5f;
    [Header("AI")]
    [SerializeField] float firingRateVariance   = 0.3f;
    [SerializeField] float minimumFiringRate    = 0.1f;
    [SerializeField] bool  useAI;

    [HideInInspector] public bool isFiring;
    
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;
    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }
 
    void Update()
    {
        Fire();    
    }

    void Fire()
    {     
        if(isFiring && firingCoroutine == null)
        {
            
            firingCoroutine = StartCoroutine(FireContinuously());
        }   
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }


    }

    IEnumerator FireContinuously()
    {
        
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab, 
                                              this.transform.position,
                                              Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, ProjectileLifetime);
            float timeToNextProjectile = UnityEngine.Random.Range(firingRate - firingRateVariance,
                                                      firingRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate,float.MaxValue);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSecondsRealtime(firingRate);
        }
    }
}
