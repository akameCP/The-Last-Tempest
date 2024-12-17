using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class öyleesine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float hız;
    float movex;
    float movey;
    Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");
       

        
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(movex * hız * Time.deltaTime * 10f, movey * hız * Time.deltaTime * 10f);
    }
}
