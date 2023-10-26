using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{
    Vector3 start;

    [SerializeField]Vector3 direction;

    [SerializeField][Range(0, 1)] float factor = 0;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update() { 
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSin = Mathf.Sin(cycles * tau);
        factor = (rawSin + 1f) / 2f; 
        Vector3 offset = direction * factor;
        transform.position = start + offset;
    }
}
