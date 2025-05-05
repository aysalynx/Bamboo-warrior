using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraResizer : MonoBehaviour
{
    public float targetWidth = 1920f;
    public float targetHeight = 1080f;

    void Start()
    {
        Camera cam = GetComponent<Camera>();
        float screenAspect = (float)Screen.width / Screen.height;
        float targetAspect = targetWidth / targetHeight;

        if (screenAspect >= targetAspect)
        {
            
            float scale = targetAspect / screenAspect;
            Rect rect = cam.rect;
            rect.width = scale;
            rect.x = (1.0f - scale) / 2.0f;
            cam.rect = rect;
        }
        else
        {
            
            float scale = screenAspect / targetAspect;
            Rect rect = cam.rect;
            rect.height = scale;
            rect.y = (1.0f - scale) / 2.0f;
            cam.rect = rect;
        }
    }
}
