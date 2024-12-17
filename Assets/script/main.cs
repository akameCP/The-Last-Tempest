using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    // Start is called before the first frame update
    

    float directionX;
    public float directionY;
    public float hýz;
    Rigidbody2D rb;
    public GameObject imlec;
    Vector2 directionn;
    float rotation;
    public GameObject sword;
    Renderer or;
    public GameObject gun;
    int weaponType = 0;
    public int heal = 100;
    public GameObject hp_bar;
    public Slider hp_bar_slider;
    public GameObject skill_usable;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        or = GetComponent<Renderer>();
        
    }

    void Start()
    {
        gun.SetActive(false);
        sword.SetActive(true);
        hp_bar_slider.value = 100;

    }

    private void FixedUpdate()
    {

        
        if (skill_usable != null)
        {
            skill_usable.transform.position = new Vector3(transform.position.x, transform.position.y + 9);
        }




        rb.velocity = new Vector3(hýz * Time.deltaTime*10 * directionX, hýz * directionY * 10 * Time.deltaTime);

        float rotz = Mathf.Atan2(directionn.y, directionn.x) * Mathf.Rad2Deg;
        imlec.transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        if (rotz < -90 || rotz > 90)
        {
            if (transform.eulerAngles.y == 0)
            {
                imlec.transform.localRotation = Quaternion.Euler(180, 0, -rotz);
            }
            else if (transform.eulerAngles.y == 180)
            {
                imlec.transform.localRotation = Quaternion.Euler(180, 180, -rotz);
            }
        }

        
        
    }
    void Update()
    {
        //silah tabanca

        if (hp_bar != null)
        {
            hp_bar.transform.position = new Vector2(transform.position.x,transform.position.y + 6);
        }
        
        

        if (Input.GetMouseButtonDown(1) && weaponType == 0)
        {
            gunAttack();
            weaponType = 1;
          
        }else if(Input.GetMouseButtonDown(1) && weaponType == 1)
        {
            swordAttack();
            weaponType = 0;
          
        }

        // HARAKET

        directionX =  Input.GetAxis("Horizontal");
        directionY = Input.GetAxis("Vertical");

        // YÖN (sað , sol)

       
        // ÝÖMLECÝN YÖNÜ

        Vector2 mausepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        directionn = mausepos - (Vector2)imlec.transform.position;
        directionn.Normalize();

        //imlecyön();

        if (mausepos.x - transform.position.x > 0)
        {
            rotation = 0;

        }
        else if (mausepos.x - transform.position.x < 0)
        {
            rotation = 180;
        }
        transform.rotation = Quaternion.Euler(0, rotation, 0);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }
    //silah türü



    //

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")|| collision.gameObject.CompareTag("bullet"))
        {
            if (heal <= 0)
            {
                SceneManager.LoadScene("Death_scene");

            }
            else
            {
                heal -= 4;
                hp_bar_slider.value = heal;
            }
        }
    }






    void imlecyön()
    {
        imlec.transform.right = directionn;

    }
    private void gunAttack()
    {
        gun.SetActive(true);
        sword.SetActive(false);
        
     
    }
    private void swordAttack()
    {
        gun.SetActive(false);
        sword.SetActive(true);

       
    }
    public void takedamage()
    {
        heal -= 1;
        
    }
    
   

}
