using UnityEngine;

public class Background : MonoBehaviour
{

    [SerializeField] private const float _backgroundWidth = 36f;

    [SerializeField] private const float _maxDistance = _backgroundWidth * 2 - 1;

    [SerializeField] private const float _shiftAmount = _backgroundWidth * 3;

    void FixedUpdate()
    {
        Loop();
    }


    void Loop()
    {
        float backgroundPositionX = transform.position.x;

        float cameraBackgroundDistance = Camera.main.transform.position.x - backgroundPositionX;

        if (cameraBackgroundDistance > _maxDistance)
        {
            UpdateBackgroundPosition(backgroundPositionX + _shiftAmount);
        }

        else if (cameraBackgroundDistance < -(_maxDistance))
        {
            UpdateBackgroundPosition(backgroundPositionX - _shiftAmount);
        }
    }


    void UpdateBackgroundPosition(float newX)
    {
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

}

