using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;





public class mob : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rb;
    int range = 5;



    public Transform MainCharacterDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        
        
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Direction()
    {
        direction = new Vector2(MainCharacterDir.position.x - transform.position.x, MainCharacterDir.position.y - transform.position.y);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,range);
        
    }
}
