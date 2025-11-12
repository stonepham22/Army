using UnityEngine;


/// <summary>
/// Manages the infinite looping effect of the background.
/// 
/// This script monitors the distance between the camera and the background. When the camera 
/// moves too far away from the background, it shifts the background position to create the 
/// illusion of an infinite scrolling background scene.
/// 
/// How it works:
/// - Calculate the distance between the camera's X position and the background's X position
/// - If the distance exceeds the limit (_maxDistance), shift the background position
/// - Repeat this process to create an infinite background effect
/// </summary>
public class Background : MonoBehaviour
{

    // The width is calculated based on the size of the sprite used as the background
    [SerializeField] private const float _backgroundWidth = 36f;

    
    // The maximum allowed distance between the camera and the background on the X-axis.
    [SerializeField] private const float _maxDistance = _backgroundWidth * 2 - 1;
    
    // The amount by which the background will shift its position when the camera exceeds the maximum distance.
    [SerializeField] private const float _shiftAmount = _backgroundWidth * 3;

    void FixedUpdate()
    {
        Loop();
    }


    /// <summary>
    /// Checks the distance between the camera and the background.
    /// If the distance exceeds the maximum allowed distance, it shifts the background position
    /// </summary>
    void Loop()
    {
        // Get the current X position of the background
        float backgroundPositionX = transform.position.x;

        // Calculate the distance between the camera and the background on the X-axis
        float cameraBackgroundDistance = Camera.main.transform.position.x - backgroundPositionX;
        
        // Shift the background position if the camera is too far to the right or left
        if (cameraBackgroundDistance > _maxDistance)
        {
            UpdateBackgroundPosition(backgroundPositionX + _shiftAmount);
        }

        // Shift the background position if the camera is too far to the left
        else if (cameraBackgroundDistance < -(_maxDistance))
        {
            UpdateBackgroundPosition(backgroundPositionX - _shiftAmount);
        }
    }
    

    /// <summary>
    /// Updates the background's position to the new X coordinate.
    /// </summary>
    /// <param name="newX">
    /// Represents the new X position that the background will shift to
    /// </param>
    void UpdateBackgroundPosition(float newX)
    {
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    /// <summary>
    /// Calculates the actual width of the sprite used as background.
    /// </summary>
    /// <returns>The width of the sprite, or 0 if no sprite is found.</returns>
    float GetSpriteWidth()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && sr.sprite != null)
        {
            return sr.sprite.bounds.size.x;
        }
        return 0f;
    }
}
