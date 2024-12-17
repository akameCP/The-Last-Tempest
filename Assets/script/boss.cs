
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class boss : MonoBehaviour
{
    public Transform[] transforms;
    // Start is called before the first frame update
    void Start()
    {
        countdowntp = timetotp;
        walkingtime = walkingtimew;
        bosscan = can;
        bosscanimage_slider.value = can;


        // TimeOfLastTeleport = System.DateTime.Now;
    }
    public int can=520;
    public GameObject loc;
    public GameObject playr;
    // public DateTime TimeOfLastTeleport;
    bool characterL = true;
    // bool sagabakar = true;
    float sonrakibekleme;
    public float beklemesüresi;
    public float countdowntp, timetotp;
    Rigidbody2D rb;
    public float speed;
    public float walkingtime, walkingtimew;
    public GameObject clock;
    bool slime = false;
    public float slimetime, slimetimew;
    public GameObject sllime;
    public float bulletspeed;
    public Transform mermirot;
    public Transform shotpoint;
    public GameObject lights;
    public GameObject lightcharge;
    public float thunderspeed;
    int attackk;
    // bool attk = true;
    public GameObject alanalev;
    public GameObject alanaleveffect;
    public float alevbulletspeed;
    public Transform randomrottt;
    public Slider bosscanimage_slider;
    public GameObject bosscanimage;
    int bosscan=520;
    public GameObject cloc;
    SpriteRenderer spriterenderer;
    public SpriteRenderer clockkkk;
    Vector3 bloodDir;
    public GameObject blood;
    GameObject bloodeffect;
    


    // private bool teleporting = false;

    // Update is called once per frame
    /*
        int teleport_min = 1;
        int teleport_max = 10;
        int RandomTeleport;
    */


    private void FixedUpdate()
    {
        //   rb.velocity = new Vector3();
    }

    public void loadend1()
    {
        SceneManager.LoadScene("final_scene");
    }

    void Update()
    {
        if (bosscanimage != null)
        {
            bosscanimage.transform.position = new Vector2(transform.position.x, transform.position.y + 6);
        }

        




        bloodDir = (playr.transform.position - transform.position).normalized;







        countdowntp -= Time.deltaTime;
        if (countdowntp <= 0 && can <= 500)
        {
            countdowntp = timetotp;
            teleport();

        }
        walkingtime -= Time.deltaTime;
        if (walkingtime <= 0 && can <= 500)
        {
            GameObject clckkk = Instantiate(clock, transform.position + new Vector3(0f, 0.07f, 0f), Quaternion.identity);
            Destroy(clckkk, 0.45f);
            walkingtime = walkingtimew;
        }
        slimetime -= Time.deltaTime;
        if (slimetime <= 0 && can <= 500)
        {
            slimetime = slimetimew;
        }
        // attackk = Random.Range(0, 3);




        if (slimetime == 4)
        {
            attackk = Random.Range(1, 4);

            
            /*
            for(int i= 0; i < 1; i++)
            {

            }
            */

        }
        Debug.Log(attackk);
        if (slimetime == 4)
        {
            
            if (slime == true && attackk == 1)
            {
                clockkkk.color = new Color(1, 0, 0, 1);
                clockk();
                StartCoroutine(slimeattack());
                slime = false;

            }
            else if (slime == true && attackk == 2)
            {
                clockkkk.color = new Color(133, 0, 255, 255);
                clockk();
                StartCoroutine(lightt());
                slime = false;

            }
            else if (slime == true && attackk == 3)
            {
                clockkkk.color = new Color(0, 155, 155, 155);
                clockk();
                StartCoroutine(alanalevv());
                slime = false;
            }
            else
            {
                clockk();
            }
            

        }

        /*
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(lightt());
        }
        */





        Vector2 playerpos = playr.transform.position;

        Vector2 dir = (Vector2)transform.position;

        if (playerpos.x - dir.x < 0 && characterL == true)
        {
            flipboss();
        }
        else if (playerpos.x - dir.x > 0 && characterL == false)
        {
            flipboss();
        }





        if (can <= 0)
        {
            loadend1();

        }


        /*
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(alanalevv());
        }
        */


    }
    IEnumerator slimeattack()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 5; i++)
        {

            for (int a = 0; a < 5; a++)
            {


                GameObject slimeattack = Instantiate(sllime, shotpoint.position, mermirot.rotation);
                slimeattack.GetComponent<Rigidbody2D>().AddForce(slimeattack.transform.right * bulletspeed);
                Destroy(slimeattack, 10f);
                yield return new WaitForSeconds(0.05f);

            }
            yield return new WaitForSeconds(0.35f);
        }






    }
    IEnumerator lightt()
    {
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < 23; i++)
        {

            float ranges = Random.Range(100.0f, -100.0f);
            GameObject lighting = Instantiate(lights, playr.transform.position + new Vector3(ranges, 80f, 0f), lights.transform.rotation);
            lighting.GetComponent<Rigidbody2D>().AddForce(lighting.transform.right * thunderspeed);

            Destroy(lighting, 10f);
            yield return new WaitForSeconds(0.14f);
        }
    }
    IEnumerator alanalevv()
    {

        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 42; i++)
        {


            // float randomrot = Random.Range(1.1f, -1.1f);         
            // randomrottt.Rotate(0f, 0f, randomrot);
            GameObject alevvv = Instantiate(alanalev, transform.position, randomrottt.transform.rotation);
            alevvv.GetComponent<Rigidbody2D>().AddForce(alevvv.transform.right * alevbulletspeed);
            Destroy(alevvv, 10f);
            yield return new WaitForSeconds(0.06f);

        }



    }

    
    private void teleport()
    {


        float step = speed * Time.deltaTime;
        float initalpos = Random.Range(-54, 54);
        if (initalpos <= 36 && initalpos >= 0)
        {
            initalpos = 20;
        }
        else if (initalpos >= -36 && initalpos <= 0)
        {
            initalpos = -20;
        }
        float initalposy = Random.Range(50, -50);
        //Vector3 pmoviedir = new Vector3(initalpos, initalposy, 0f);
        // Vector3 moviedirr = (Vector3)pmoviedir - new Vector3(0,0,0);
        transform.position = new Vector3(loc.transform.position.x + initalpos, loc.transform.position.y + initalposy, 0);
        //  rb.velocity = new Vector3(initalpos, initalposy, 0f);
        //transform.Translate(new Vector3(initalpos, initalposy, 0f));
        // transform.position = Vector3.MoveTowards(transform.position, pmoviedir,step);
        //transform.position = Vector3.MoveTowards(transform.position, pmoviedir, step);
        slime = true;

    }


    void tme()
    {
        int i = 0;
        i++;
        print(i);

    }
    void flipboss()
    {
        transform.Rotate(0f, 180f, 0f);
        characterL = !characterL;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    void clockk()
    {
        //clockkkk.color = new Color(1,0,0,1);
        GameObject clockkk = Instantiate(cloc, transform.position, Quaternion.identity);
        Destroy(clockkk, 0.5f);
    }
    public void takedamage()
    {
        
        float min = -2, max = 2;
        float randomPosx = Random.Range(min, max);
        float randomPosy = Random.Range(min, max);
        float rotz = Mathf.Atan2(bloodDir.y, bloodDir.x) * Mathf.Rad2Deg;
        bloodeffect = Instantiate(blood, transform.position, Quaternion.Euler(0f, 0f, rotz  + (8 * randomPosx)+180));
        Destroy(bloodeffect, 0.3f);




        can -= 13;
        bosscanimage_slider.value = can;
    }



}




