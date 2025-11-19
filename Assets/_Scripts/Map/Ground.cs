using Unity.Mathematics;
using UnityEngine;

public class Ground : MonoBehaviour
{
    void FixedUpdate()
    {
        float camPosX = Camera.main.transform.position.x;
        
        if(math.abs(camPosX - transform.position.x) > 8f)
        {
            transform.position = new Vector3(camPosX, transform.position.y, transform.position.z);
        }
    }
}
