using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider otherObject)

    {

        print("Just entered the trigger defined by the object " + otherObject.gameObject.name);

    }


    void OnTriggerExit(Collider otherObject)

    {

        print("Just exited the trigger defined by the object " + otherObject.gameObject.name);

    }

}
