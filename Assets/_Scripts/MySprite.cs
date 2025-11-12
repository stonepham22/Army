using UnityEngine;

public class MySprite : MonoBehaviour
{
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
