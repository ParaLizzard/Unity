using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody rb;
    int count = 0;
    private Renderer objectRenderer;
    [SerializeField]float x = 1f;
    [SerializeField]float y = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    

    // Update is called once per frame
    void Update()
    {
         float hor = Input.GetAxis("Horizontal") * x;
        float ver = Input.GetAxis("Vertical") * y;
        Vector3 movement = new Vector3(hor, 0, ver) * Time.deltaTime;
        transform.Translate(movement, Space.World);
        if(Time.time > 3){
            rb.useGravity = true;
            
        }
    }

    private void OnCollisionEnter(Collision other) {
        MeshRenderer rend = other.gameObject.GetComponent<MeshRenderer>();
        count++;
        rend.material.color = Color.blue;
        Debug.ClearDeveloperConsole();
        Debug.Log($"You bimped into object {count} times");
    }
    
}
