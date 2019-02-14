﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Add this script to an object that shall be able to fire projectiles.
 * The spawnpoint can be specified in the inspector, should probably be set to the gameobject's.
 */
public class FireProjectileScript : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform spawnpoint;
    public int speed = 10;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        if (Controller.GetHairTriggerDown())
        {
            FireProjectile();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FireProjectile()
    {
        Rigidbody fireball;
        Vector3 adjustment = Vector3.forward;
        // Instantiate fireball at the spawnpoint position, adjusted by a Vector3
        fireball = Instantiate(projectile, spawnpoint.position + adjustment,
            spawnpoint.rotation);
        fireball.velocity = spawnpoint.TransformDirection(Vector3.forward * speed);
    }
}
