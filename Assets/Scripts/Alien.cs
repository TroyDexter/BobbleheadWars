using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.Events;

public class Alien : MonoBehaviour
{
    public Transform target;
    public float navigationUpdate;
    public UnityEvent OnDestroy;

    private float navigationTime = 0;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //Store NavMeshAgent data in variable agent
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {
            navigationTime += Time.deltaTime;

            if (navigationTime > navigationUpdate)
            {
                agent.destination = target.position;
                navigationTime = 0;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Die();

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath);
    }

    public void Die()
    {
        //Notifies all listeners about the death
        OnDestroy.Invoke();
        OnDestroy.RemoveAllListeners();
        Destroy(gameObject);
    }
}
