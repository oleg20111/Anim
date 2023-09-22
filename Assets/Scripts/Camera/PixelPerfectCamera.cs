using UnityEngine;

namespace Vivat
{
    public class PixelPerfectCamera:MonoBehaviour
    {
        public int referenceHeight = 1280;
        public float pixelsPerUnit = 100;

        void OnValidate()
        {
            updateCameraSize();
        }

        void updateCameraSize()
        {
            float refOrthoSize = (referenceHeight / pixelsPerUnit) * 0.5f;
            GetComponent<Camera>().orthographicSize = refOrthoSize;
        }
    }
}