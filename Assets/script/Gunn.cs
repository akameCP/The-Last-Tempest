using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
     Animator animator;
     




    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("gunTrigger",true);
           
        }

    }
    public void gunStopAttack()
    {
        animator.SetBool("gunTrigger", false);
       

    }
    

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
}
