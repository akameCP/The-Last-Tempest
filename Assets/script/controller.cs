using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public GameObject[] inventory;
    bool inventoryAct = false;
    public GameObject[] sword;
    k˝l˝Á send›nventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        
        
    }
    // Update is called once per frame
    void Update()
    {
        foreach (var inventorytype in inventory)
        {
            if (Input.GetKeyDown(KeyCode.F) && inventoryAct == false)
            {
                inventory[0].SetActive(true);
                inventory[1].SetActive(true);
                inventory[2].SetActive(true);
                inventoryAct = true;
                foreach (var swordCheck in sword)
                {
                    send›nventory = swordCheck.GetComponent<k˝l˝Á>();
                    send›nventory.inventroyTrue(true);
                }
                

            }
            else if (Input.GetKeyDown(KeyCode.F) && inventoryAct == true)
            {
                inventory[0].SetActive(false);
                inventory[1].SetActive(false);
                inventory[2].SetActive(false);
                inventoryAct = false;
                foreach (var swordCheck in sword)
                {
                    send›nventory = swordCheck.GetComponent<k˝l˝Á>();
                    send›nventory.inventroyTrue(false);
                }
                
            }
        }
        


    }
    
}
