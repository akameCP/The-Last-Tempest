using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class boss_rot : MonoBehaviour
{
    public Transform merfmiyönü;
    Vector3 dirctionT;
    public GameObject characterrs;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        dirctionT = merfmiyönü.position - transform.position;
        float angle = Mathf.Atan2(dirctionT.y, dirctionT.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        Vector2 characterpos = characterrs.transform.position;
        Vector2 dir = (Vector2)transform.position;
        facemause();

    }
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    void facemause()
    {
        transform.right = dirctionT;


    }
}
