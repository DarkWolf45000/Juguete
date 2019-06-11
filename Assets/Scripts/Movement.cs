using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject sword;
    private bool getsword=true;
    public GameObject helmet;
    public float speed = 5f;
    public Rigidbody2D rb;
    private int cantj = 0;
    private Transform pt;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        pt = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)){ 

            Vector3 movement = new Vector3(1f,0f,0f);
            pt.position += movement * Time.deltaTime*  speed;
            
        }

        if(Input.GetKey(KeyCode.A)){

            Vector3 movement = new Vector3(-1f, 0f, 0f);
            pt.position += movement * Time.deltaTime * speed;

        }

        if (Input.GetKeyDown(KeyCode.W) && cantj<2)
        {
            cantj += 1;
            Vector2 v2 = new Vector2(0f, 5f);
            rb.AddForce(v2, ForceMode2D.Impulse);
        }

    }

    private void OnCollisionEnter2D(Collision2D col)

    {

        var otherObj = col.collider;
        var cgo = otherObj.gameObject;
        var player = col.otherCollider.gameObject;
        if (otherObj.tag == "Sword" && getsword)
        {
            getsword = false;
            Debug.Log("Collisding with" + col.collider.gameObject.name);
            cgo.transform.parent = player.transform;

        } else if (otherObj.tag == "Helmet")
        {
            Debug.Log("Collisding with" + col.collider.gameObject.name);
            cgo.transform.parent = player.transform;
            Vector2 v2 = new Vector2(player.transform.position.x, player.transform.position.y);
            cgo.transform.position = v2;
        } else if (otherObj.tag =="Ground")
        {
            cantj = 0;

        }

    }
    /*
    void OnTriggerEnter(Collider otherObject)

    {

        print("Just entered the trigger defined by the object " + otherObject.gameObject.name);

    }


    void OnTriggerExit(Collider otherObject)

    {

        print("Just exited the trigger defined by the object " + otherObject.gameObject.name);

    }
    */

}
