using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooter")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingVolume = 1f;
    [Header("Explosion")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] [Range(0f,1f)] float explosionVolume = 1f;

    static AudioPlayer instance;
    
    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip,shootingVolume);
    }
    public void PlayExplosionClip()
    {
        PlayClip(explosionClip,explosionVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
         if(clip != null)
        {
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip,
                                        cameraPosition,
                                        volume);
        }
    }
}
