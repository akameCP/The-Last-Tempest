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
    bool c�k�� = false;
    // Update is called once per frame
    void Update()
    {
        

        if (player.position.y - layerpos.transform.position.y > 0 && c�k�� == false)
        {
            foreach (var castleee in castlee)
            {
                
                castleee.sortingOrder += 30;

            }
            c�k�� = true;
        }

        if (player.position.y - layerpos.transform.position.y < 0 && c�k�� == true)
        {
            {
                foreach (var castleee in castlee)
                {
                    castleee.sortingOrder -= 30;

                }
                c�k�� = false;
            }

         }

    }
    private void Awake()
    {
        
        
    }
}
