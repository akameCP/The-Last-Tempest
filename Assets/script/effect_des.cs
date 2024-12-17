using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect_des : MonoBehaviour
{
    public GameObject burst_effect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            //GetComponent<main>().takedamage();
            GameObject burst = Instantiate(burst_effect, collision.gameObject.transform.position, transform.rotation);
            Destroy(burst, 0.5f);
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
