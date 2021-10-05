using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform launchPosition;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsInvoking("fireBullet"))
            {
                InvokeRepeating("fireBullet",0f, 0.1f);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("fireBullet");
        }
    }

    void fireBullet()
    {
        //Creates GameObject instance from a prefab
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;

        //Set bullet's position to launcher position
        bullet.transform.position = launchPosition.position;

        //Bullet fires in the same direction space marine is facing
        bullet.GetComponent<Rigidbody>().velocity = transform.parent.forward * 100;

        audioSource.PlayOneShot(SoundManager.Instance.gunFire);
    }
}
