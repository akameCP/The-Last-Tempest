using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eaterBurst : MonoBehaviour
{
 
    public GameObject eaterSword;
    k�l�� K�l��;
    bool eatertrigger=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void eaterSkillUse(bool �npFalse)
    {
        
         K�l��.eaterdamagecount(�npFalse);

        

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
            K�l�� = eaterSword.GetComponent<k�l��>();
            
        }
    }

}
