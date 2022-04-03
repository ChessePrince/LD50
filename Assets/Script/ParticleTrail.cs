using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrail : MonoBehaviour
{
    public GameObject trail;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;

    private Transform fatherTransform;
    private void Start()
    {
        fatherTransform = GetComponentInParent<Transform>();
    }
    private void Update()
    {
        if (fatherTransform.hasChanged)
        {
            StartTheTrail();
        }
    }
    public void StartTheTrail()
    {
        if (timeBtwSpawn <= 0)
        {
            Instantiate(trail, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
