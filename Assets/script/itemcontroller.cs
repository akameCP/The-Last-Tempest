using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;
public class itemcontroller : MonoBehaviour
{
   
    public int hearthofthedarkness = 0;
    public int weapontype =0;
    bool darknessiscurrent =false;
    
    public GameObject item;
    GameObject objDarkness;
    public bool eaterWeapon = true;
    public GameObject enemy;
    public Transform itemcontend;
    public Transform itemcontend2;
    public Transform itemcontend3;
    public Sprite[] itemsWepon;
    public Sprite[] items;
    public GameObject[] weaponsObject;
    GameObject objDarknessSword;
    Button eaterButton, murasamaButton;
    public GameObject mainWeaponParent;
    public GameObject zone1Blood;
    zone1 zoneblood;
    public GameObject eaterburstObj;
    public GameObject[] door;
    
    public Transform player;


    void Start()
    {
        DisableChildrenRecursive(mainWeaponParent.transform);
        murasamaGet();
        

    }
    private void Awake()
    {
        zoneblood = zone1Blood.GetComponent<zone1>();
    }


    void Update()
    {
        if (darknessiscurrent)
        {
            eaterButton.onClick.AddListener(eaterGet);
        }
        
        murasamaButton.onClick.AddListener(murasamaGetOject);

        if(hearthofthedarkness >= 1)
        {
            if(door != null)
            {
                foreach (var lv2 in door)
                {
                    Destroy(lv2);
                }
                
                
            }
            
        }
        




    }
    public void addherthofthedarkness()
    {
        int dropratehearth = Random.Range(0, 1001);

        if (dropratehearth <= 100)
        {
            
            hearthofthedarkness++;
            if(hearthofthedarkness <= 1)
            {
                objDarkness = Instantiate(item, itemcontend);


                Image itemIcon = objDarkness.transform.Find("icon").GetComponent<Image>();
                itemIcon.sprite = items[0];


                

            }
            
            Text itemText = objDarkness.transform.Find("text").GetComponent<Text>();
            itemText.text = hearthofthedarkness.ToString();

            



        }
        if(dropratehearth <= 200)
        {

            if (darknessiscurrent == false)
            {
                eaterWeapon = true;
                objDarknessSword = Instantiate(item, itemcontend2);
                Image itemIcon = objDarknessSword.transform.Find("icon").GetComponent<Image>();
                itemIcon.sprite = itemsWepon[1];
                Text itemText = objDarknessSword.transform.Find("text").GetComponent<Text>();
                itemText.text = ("Eater of the god sword");
                darknessiscurrent = true;
                eaterButton = objDarknessSword.GetComponent<Button>();
            }
            

        }
        
        
    }
    private void murasamaGet()
    {
        GameObject murasama = Instantiate(item, itemcontend2);
        Image itemIcon = murasama.transform.Find("icon").GetComponent<Image>();
        itemIcon.sprite = itemsWepon[0];
        Text itemText = murasama.transform.Find("text").GetComponent<Text>();
        itemText.text = ("Murasama");
        murasamaButton = murasama.GetComponent<Button>();


    }
    
    void eaterGet()
    {
        
        if (eaterWeapon&& weaponsObject.Length > 1)
        {
            weapontype = 1;
            DisableChildrenRecursive(mainWeaponParent.transform);
            weaponsObject[1].SetActive(true);
            zoneblood.setWeapontype(weapontype);
            eaterButton.onClick.RemoveListener(eaterGet);
            eaterBurst eaterburst = eaterburstObj.GetComponent<eaterBurst>();
            eaterburst.eaterSkillUse(true);

        }
    }
    void DisableChildrenRecursive(Transform parent)
    {
        
        foreach (Transform child in parent)
        {
          
            child.gameObject.SetActive(false);

          
            DisableChildrenRecursive(child);
        }
    }
    
    void murasamaGetOject()
    {
        weapontype = 0;
        DisableChildrenRecursive(mainWeaponParent.transform);
        weaponsObject[0].SetActive(true);
        zoneblood.setWeapontype(weapontype);
        murasamaButton.onClick.RemoveListener(murasamaGetOject);
        eaterBurst eaterburst = eaterburstObj.GetComponent<eaterBurst>();
        eaterburst.eaterSkillUse(false);

    }
    
}
