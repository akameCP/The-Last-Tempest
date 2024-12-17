using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eaterBurst : MonoBehaviour
{
 
    public GameObject eaterSword;
    kýlýç Kýlýç;
    bool eatertrigger=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void eaterSkillUse(bool ýnpFalse)
    {
        
         Kýlýç.eaterdamagecount(ýnpFalse);

        

    }
    
    public void eaterSkilltrigger()
    {

        
        eatertrigger = true;

        

    }
    public bool getEater()
    {
        return eatertrigger;
    }
    

    
    
    private void Awake()
    {
        if (eaterSword != null)
        {
            Kýlýç = eaterSword.GetComponent<kýlýç>();
            
        }
    }

}
