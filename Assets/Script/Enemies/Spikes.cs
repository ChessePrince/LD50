using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Rigidbody2D rb;
    public float vel;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        //Move(1);
    }
    private void FixedUpdate()
    {
        Move(1);
    }
    void Move(int dir)
    {
        //compRB.velocity = dir * transform.up * Time.deltaTime * vel;
        rb.velocity = new Vector3(0, 2, 0);
    }
}
