
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float smoothspeed = 20f;
    public Vector3 offset;
    public Vector3 speed = Vector3.zero;
    // Update is called once per frame

    void LateUpdate()  
    {
        Vector3 dp = target.position + offset;
        //Vector3 smoothedposition = Vector3.SmoothDamp(target.position,dp,ref speed, smoothspeed,Time.deltaTime);
        //Vector3 smoothedposition = Vector3.Lerp(target.position,dp,smoothspeed);
   
        transform.position = dp;
    }
}
