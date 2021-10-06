using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public Gun gun;

    void OnTriggerEnter(Collider other)
    {
        //When player collides with power up;
        //set gun to Upgraded mode 
        //destroy itself
        gun.UpgradedGun();
        Destroy(gameObject);
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.powerUpPickup);
    }
}
