# Background.cs Documentation

## 1. Purpose
The `Background` script is used to **create a looping effect** for background sprites in a 2D game.  
As the camera moves, the background tiles are repositioned in a continuous loop to simulate an infinite scrolling environment.

---

## 2. Function Overview
- Automatically checks the distance between the **camera** and each **background object**.
- Ensures that there is always one background to the **left** and one to the **right** of the camera.
- When there is no background on one side of the camera, the farthest background from the opposite side is shifted over to fill the gap.
- Maintains a **seamless scrolling background** without creating or destroying objects at runtime.

---

## 3. Code Structure

### 3.1 Variables and Constants
| Variable | Type | Description |
|-----------|------|-------------|
| `_backgroundWidth` | `float` (const) | The actual width of a single background sprite (in world units). Used as a base value for distance calculations. |
| `_maxDistance` | `float` | The maximum distance between the camera and a background before it needs to be repositioned. Calculated as `_backgroundWidth * 2 - 1`. |
| `_shiftAmount` | `float` | The distance a background moves when repositioned. Calculated as `_backgroundWidth * 3`. |

> 💡 **Note:** These values can be adjusted depending on the sprite size or how you arrange the background tiles.

---

### 3.2 Methods
| Method | Description |
|--------|--------------|
| `FixedUpdate()` | Calls the `Loop()` function on each physics frame to check the camera’s position relative to the background. |
| `Loop()` | Measures the distance between the camera and the background. If it exceeds `_maxDistance`, the background is repositioned forward or backward. |
| `UpdateBackgroundPosition(float newX)` | Updates the background’s X position while keeping its Y and Z coordinates unchanged. |

---

## 4. How It Works

1. The camera moves along with the player or the scene.  
2. The script continuously measures the **horizontal distance** between the camera and the background.  
3. When the camera moves beyond `_maxDistance`, the background is **shifted to the opposite side** by `_shiftAmount`.  
4. This creates an illusion of **infinite scrolling**, where backgrounds are recycled instead of recreated.

### 🔁 Example
Suppose you have three background sprites arranged in sequence: [BG1] [BG2] [BG3].

When the camera moves to the right:
- At the start, the camera is centered around [BG2].
- As the camera reaches [BG3] and moves past a defined distance,  
  `BG1` is shifted to the right by `_shiftAmount`.
- The resulting layout appears as: [BG2] [BG3] [BG1]

The player perceives this as a **never-ending background** that scrolls smoothly.

---

## 5. Technical Notes
- Attach this script to **each background sprite** that participates in the looping system.  
- `_backgroundWidth` should match the actual **world width** of your sprite.  
  - You can obtain this dynamically using `SpriteRenderer.bounds.size.x` if needed.  
- Backgrounds should be aligned precisely along the **X-axis** to avoid visual gaps.  
- The script uses `Camera.main` to reference the main camera.  
  If multiple cameras are used, consider assigning one explicitly.

---

## 6. Future Improvements
- Add **parallax scrolling** by applying different movement multipliers for each background layer.  
- Automatically calculate `_backgroundWidth` from the sprite instead of hardcoding it.  
- Integrate with a `BackgroundManager` to handle multiple layers (sky, mountains, ground, etc.).  
- Implement **object pooling** or optimization for dynamically changing backgrounds across scenes.

---

## 7. Related Components
- Prefab: `BackgroundPrefab`  
- Related scripts: `CameraController`, `ParallaxManager` *(if applicable)*

---

## 8. Author
Author: *Pham Tong Thach*  
Date: *November 12, 2025*  
Unity Version: *6000.0.60f1 LTS*

---

🧠 **Summary:**  
`Background.cs` keeps your 2D world looking **infinite, seamless, and efficient** by continuously repositioning background sprites based on the camera’s position — instead of creating or destroying objects during gameplay.
