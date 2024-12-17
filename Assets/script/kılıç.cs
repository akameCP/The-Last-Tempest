using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class kılıç : MonoBehaviour
{
    
  
    
    Animator animator;
    public LayerMask enemylayers;
    public LayerMask boss;
    public Transform attackpoint;
    public float attackrange =0.5f;
    public int attackdamage = 10;
    bool stopAttack;
    bool inventoryChecker = true;
    public Transform player;
    public bool eatercounters = false;
    public GameObject eaterSkill;
    GameObject eater;
    eaterBurst eatertrigger;
    bool closeEater=false;
    float TimeDelay_Seconds = 3.0f;
    float Timer = 0;
    public SpriteRenderer skill_usable;
    bool skill_bool = true;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)  ) 
        {
            animator.SetBool("atak", true);

        }
        else 
        {
             animator.SetBool("atak" ,false);
        }
        
        if(stopAttack == true)
        {
            attack();
           
            stopAttack = false;
        }




        if (eatercounters == true && Input.GetKeyDown(KeyCode.E) && (Timer < Time.time))
        {
            eaterskillanim();
            Timer = Time.time + TimeDelay_Seconds;
        }

        







        if (eater != null&&closeEater)
        {
            if (eatertrigger.getEater() == true)
            {
                eaterskillattack();
                closeEater = false;
            }
        }
        

    }
    private void Awake()
    {
        animator = GetComponent<Animator>();    
        
    }
    void stopatack()
    {
       // animator.SetBool("atak" ,false);
        

    }
    void damagecount()
    {
        stopAttack = true;
    }
     
    public void eaterdamagecount(bool eatercount)
    {
        eatercounters = eatercount;
    }

    void attack()
    {
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position,attackrange,enemylayers);
        foreach(Collider2D enemy in hitenemies)
        {
            
            enemy.GetComponent<character_1>().TakeDamage(attackdamage);
            



        }
        Collider2D[] hitenemies_boss = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, boss);
        foreach (Collider2D enemy in hitenemies_boss)
        {

            enemy.GetComponent<boss>().takedamage();
            


        }


    }
    
    public void eaterskillattack()
    {
        
        if(eater != null)
        {
            Collider2D[] hitenemies = Physics2D.OverlapCircleAll(eater.transform.position, 30, enemylayers);
            foreach (Collider2D enemy in hitenemies)
            {
                enemy.GetComponent<character_1>().TakeDamage(100);
                

            }
            Collider2D[] hitenemies_boss = Physics2D.OverlapCircleAll(eater.transform.position, 30, boss);
            foreach (Collider2D enemy in hitenemies_boss)
            {

                enemy.GetComponent<boss>().takedamage();
               



            }


        }
        



    }
    public void eaterskillanim()
    {
        eater = Instantiate(eaterSkill, player.transform.position, Quaternion.identity);
        Destroy(eater, 1);
        if (eater != null)
        {
            eatertrigger = eater.GetComponent<eaterBurst>();
        }
        closeEater = true;

    }
    
    /*
     collider 2d[] hitenemies = pys2d overlap(pos nesne(range)  layer)
    foreach(collider2d[] enemy in hitenemies ){

    }



     */
    private void OnDrawGizmosSelected()
    {
        if(attackpoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
       
    }

    public void inventroyTrue(bool check)
    {
        inventoryChecker = check;
    }

    
}
