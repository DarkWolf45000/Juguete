
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    // Update is called once per frame

    void LateUpdate()  
    {
        Vector3 dp = target.position + offset;
   
        transform.position = dp;
    }
}
