﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public ParticleSystem fire;
    public ParticleSystem explosion;
    public float timeout = 5.0f;
    private float time = 0.0f;
    AudioSource explosionAudio;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= timeout)
        {
            Destroy(gameObject);
        }
        else
        {
            ParticleSystem fireClone = Instantiate(fire, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        explosionAudio.Play();
        
        Destroy(gameObject);
    }
}
