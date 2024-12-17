using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_rotate : MonoBehaviour
{
    public Transform player;
    public Transform yer;
    //bool sol = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, 3f);

        transform.position = yer.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
       

    }
}
