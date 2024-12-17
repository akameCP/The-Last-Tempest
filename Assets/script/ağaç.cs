using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ağaç : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    public Transform player;
    public Transform treepoint;
    bool arttır = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(treepoint.position.y < player.position.y && arttır == true)
        {
            spriteRenderer.sortingOrder += 30;
            arttır = false;
        }
        if (treepoint.position.y > player.position.y && arttır == false)
        {
            spriteRenderer.sortingOrder -= 30;
            arttır = true;
        }

    }
}
