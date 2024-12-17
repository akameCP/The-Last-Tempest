using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class zone1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    int enemyCounter = 15;
    public GameObject enemyObject;
    int weapontype;
    int currentenemycounter = 0;
    GameObject spawnEnemys;
    character_1 character1;
    List<GameObject> enemiesMultiple = new List<GameObject>();
    // Update is called once per frame
    void Update()
    {
        spawnEnemy();

      
            
        

    }
    
   
  
    
    void spawnEnemy()
    {
        if(currentenemycounter == 0)
        {
            
            while (currentenemycounter < enemyCounter)
            {
                float min = -90, max = 90;

                float randomPosx = Random.Range(min, max);
                float randomPosy = Random.Range(min, max);

                

                spawnEnemys = Instantiate(enemyObject, new Vector3(transform.position.x + randomPosx, transform.position.y + randomPosy), Quaternion.identity);
                currentenemycounter++;




                if (spawnEnemys != null)
                {
                    enemiesMultiple.Add(spawnEnemys);
                }
                
                

            }
        }
        foreach (GameObject enemy in enemiesMultiple)
        {
            if (enemy != null)
            {
                character_1 enemyCharacter = enemy.GetComponent<character_1>();
                if (enemyCharacter != null)
                {
                    if (weapontype == 0)
                    {
                        enemyCharacter.setWeaponEater(0); 
                    }
                    else if (weapontype == 1)
                    {
                        enemyCharacter.setWeaponEater(1); 
                    }
                }
            }
        }







    }
    public void characterdied()
    {
        currentenemycounter--;
    }
    public void setWeapontype(int weapontypeset)
    {
        weapontype = weapontypeset;
    }
    /*
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, zone);
    }
    */
    
}
