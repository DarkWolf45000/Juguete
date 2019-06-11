using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
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
            this.lookRight(this.gameObject);
            Vector3 movement = new Vector3(1f,0f,0f);
            pt.position += movement * Time.deltaTime*  speed;
            
        }

        if(Input.GetKey(KeyCode.A)){
            this.lookLeft(this.gameObject);
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


        if (otherObj.tag == "Sword")
        {
            Debug.Log("Collisding with" + col.collider.gameObject.name);
            this.activar(cgo, player, "Sword");
            

        } else if (otherObj.tag == "Helmet")
        {
            Debug.Log("Collisding with" + col.collider.gameObject.name);
            this.activar(cgo, player, "Helmet");
           
            
        } else if (otherObj.tag =="Ground")
        {
            cantj = 0;

        }else if (otherObj.tag == "Shield")
        {
            this.activar(cgo, player, "Shield");

        }

    }

    private void activar(GameObject cgo, GameObject player, string tag)
    {
        GameObject.Destroy(cgo);
            for (int i=0; i<player.transform.childCount; i++)
            {
                Transform son = player.transform.GetChild(i);
                if (son.tag==tag)
                {
                    son.gameObject.SetActive(true);
                }
            }
    }


    private void lookRight(GameObject player)
    {
        for (int i = 0; i < player.transform.childCount; i++)
        {
            Transform son = player.transform.GetChild(i);
            SpriteRenderer sr = son.GetComponent<SpriteRenderer>();
            if (son.tag == "Sword")
            {
                Quaternion rotz = son.transform.rotation;
                if (son.localEulerAngles.z < 48)
                {
                    son.transform.rotation = Quaternion.Euler(son.localEulerAngles.x, son.localEulerAngles.y, son.localEulerAngles.z * -1);
                    son.transform.position = new Vector2(son.transform.position.x + 0.3f, son.transform.position.y);
                }
            }
            else if (son.tag == "Shield")
            {
                if (!sr.flipX) { son.transform.position = new Vector2(son.transform.position.x + 0.9f, son.transform.position.y); }
                sr.flipX = true;
            }
            else
            {
                sr.flipX = true;
            }
        }

        
    }

    private void lookLeft(GameObject player)
    {
        for (int i = 0; i < player.transform.childCount; i++)
        {
            Transform son = player.transform.GetChild(i);
            SpriteRenderer sr = son.GetComponent<SpriteRenderer>();
            if (son.tag == "Sword")
            {
                Quaternion rotz = son.transform.rotation;
                if (son.localEulerAngles.z > 48)
                {
                    son.transform.rotation= Quaternion.Euler(son.localEulerAngles.x,son.localEulerAngles.y, son.localEulerAngles.z*-1);
                    son.transform.position = new Vector2(son.transform.position.x - 0.3f, son.transform.position.y);
                }
                
            }
            else if (son.tag == "Shield")
            {
                if (sr.flipX) { son.transform.position = new Vector2(son.transform.position.x - 0.9f, son.transform.position.y); }
                sr.flipX = false;
            }
            else
            {
                sr.flipX = false;
            }
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
