using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.Collections;
using UnityEngine;

public class castle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform layerpos;

    public SpriteRenderer[] castlee ;
    public Transform player;
    bool cýkýþ = false;
    // Update is called once per frame
    void Update()
    {
        

        if (player.position.y - layerpos.transform.position.y > 0 && cýkýþ == false)
        {
            foreach (var castleee in castlee)
            {
                
                castleee.sortingOrder += 30;

            }
            cýkýþ = true;
        }

        if (player.position.y - layerpos.transform.position.y < 0 && cýkýþ == true)
        {
            {
                foreach (var castleee in castlee)
                {
                    castleee.sortingOrder -= 30;

                }
                cýkýþ = false;
            }

         }

    }
    private void Awake()
    {
        
        
    }
}
