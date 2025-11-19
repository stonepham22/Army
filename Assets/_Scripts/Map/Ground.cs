using Unity.Mathematics;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private float _distance = 4f;
    
    void FixedUpdate()
    {
        float camPosX = Camera.main.transform.position.x;
        
        if(math.abs(camPosX - transform.position.x) > _distance)
        {
            transform.position = new Vector3(camPosX, transform.position.y, transform.position.z);
        }
    }
}
