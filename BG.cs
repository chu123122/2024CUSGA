using UnityEngine;

namespace C_
{
    public class BG:MonoBehaviour
    {
        [SerializeField] private Vector2 parallaxEffectMultiplier;

        private Transform _cameraTransform;
        private Vector2 _lastCameraPosition;
        private float _textureUnitSizeX;
        private void Start()
        {
            if (Camera.main != null) _cameraTransform = Camera.main.transform;
            _lastCameraPosition = _cameraTransform.position;
            // Sprite sprite =GetComponent<SpriteRenderer>().sprite;
            // Texture2D texture = sprite.texture;
            // _textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        }

        private void LateUpdate()
        {
            
            Vector2 deltaMovement = (Vector2)_cameraTransform.position - _lastCameraPosition;
            Vector3 targetPosition = transform.position + new Vector3(deltaMovement.x * parallaxEffectMultiplier.x,
                deltaMovement.y * parallaxEffectMultiplier.y);
            if((targetPosition-transform.position).magnitude<=1f)
                transform.position = targetPosition;
            _lastCameraPosition = _cameraTransform.position;
            
             
        }
    }
}