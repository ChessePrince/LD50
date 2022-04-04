using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Rigidbody2D rb;
    public int vel;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move(1);
    }
    void Move(int dir)
    {
        //compRB.velocity = dir * transform.up * Time.deltaTime * vel;
        rb.velocity = new Vector3(0, vel, 0);
    }
}
