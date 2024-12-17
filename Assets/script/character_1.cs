using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
//using static UnityEditor.FilePathAttribute;


public class character_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        currentheal = can;
     


    }
    public int can = 100;
    int currentheal;
    public Transform player;
    public float speed;
    public float stopdistance;
    Rigidbody2D rb;
    float rotation;
    public bool ileri = true;
    Vector3 direction;
    Vector3 bloodDir;
    public GameObject damagePopUp2;
    public GameObject damagePopUp;
    public GameObject blood;
    public float distancerange;
    public int weapontype = 0;
    SpriteRenderer spriteblood;
    GameObject bloodeffect;

    void Update()
    {

        

        if(currentheal <= 0)
        {
            GameObject zoneObject = GameObject.Find("zone1");
            Destroy(gameObject);
            zone1 zoneInstance = zoneObject.GetComponent<zone1>();
            if(zoneInstance != null )
            {
                zoneInstance.characterdied();
            }
            else
            {
                Debug.Log("error");
            }
            GameObject item1 = GameObject.Find("itemcontroller");
            itemcontroller item1instance = item1.GetComponent<itemcontroller>();

            item1instance.addherthofthedarkness();
           
            
            
        }

        
        float distance = Vector3.Distance(transform.position, player.position);
        bloodDir = (player.position - transform.position).normalized;

        if (distance >= stopdistance && distancerange > distance && ileri == true)
        {
            direction = (player.position - transform.position).normalized;




        }

        else
        {
            rb.velocity *= 0;
        }
        if (player.position.x - transform.position.x > 0)
        {
            rotation = 0;

        }
        else if (player.position.x - transform.position.x < 0)
        {
            rotation = 180;
        }
        transform.rotation = Quaternion.Euler(0, rotation, 0);

        


    }

    private void FixedUpdate()
    {
        

        if(ileri == true)
        {
            rb.velocity = direction * speed * Time.fixedDeltaTime;

        }
        

    }
    

    
    public void TakeDamage(int damage)
    {
        float min = -2, max = 2;
        float randomPosx = Random.Range(min , max);
        float randomPosy = Random.Range(min, max);
        float randomCrit = Random.Range(1, 11);


        if (weapontype == 0)
        {
            spriteblood.color = new Color(255, 255, 255, 255);
        }
        else if (weapontype == 1)
        {
            spriteblood.color = new Color(0, 0, 0, 255);
        }

        float rotz = Mathf.Atan2(bloodDir.y, bloodDir.x) * Mathf.Rad2Deg;
        bloodeffect = Instantiate(blood, transform.position, Quaternion.Euler(0f,0f,rotz+180+(8*randomPosx)));
        Destroy(bloodeffect, 0.3f);

        


        GameObject popUpEffect2 = Instantiate(damagePopUp2, new Vector3(transform.position.x + randomPosx, transform.position.y + randomPosy), Quaternion.identity);
        Destroy(popUpEffect2, 0.5f);

        currentheal -= damage;
        if(randomCrit >= 8)
        {
            
            currentheal -= damage;
            GameObject popUpEffect = Instantiate(damagePopUp, new Vector3(transform.position.x + randomPosx, transform.position.y + randomPosy), Quaternion.identity);
            Destroy(popUpEffect, 0.5f);
            
            
            Debug.Log(" crit hittt");
        }

        


        


    }
    
    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        spriteblood = blood.transform.Find("blood_effect").GetComponent<SpriteRenderer>();
    }
    
 
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, distancerange);
    }
    
    public void setWeaponEater(int type)
    {
        weapontype = type;
        
    }

    
    
}
