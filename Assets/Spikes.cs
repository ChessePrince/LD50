using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Rigidbody2D compRB;
    public float vel;

    private void Awake()
    {
        compRB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Move(1);
    }
    private void Update()
    {
        //Move(1);
    }
    void Move(int dir)
    {
        compRB.velocity = dir * transform.up * Time.deltaTime * vel;
    }
}
