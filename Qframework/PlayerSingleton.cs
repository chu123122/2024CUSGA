using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace QFramework
{
    public class PlayerSingleton:MonoBehaviour
    {
        #region Singleton

            private static  PlayerSingleton _instance;

            public static PlayerSingleton Instance
            {
                get { return _instance; }
            }
            private void Awake()
            {
                if (_instance == null)
                {
                    _instance = this;
                    DontDestroyOnLoad(gameObject1);
                }
                else if (_instance != this)
                {
                    Destroy(gameObject1);
                }
            }

            #endregion
         public  GameObject gameObject1;
        public  Transform transform1;
        public Transform character;
        public new Rigidbody2D rigidbody2D;
        public  LineRenderer lineRenderer;
        public  SpriteRenderer spriteRenderer;
        public CapsuleCollider2D capsuleCollider2D;
        public Animator animator;
        public Material material;
        public Transform Shadow; 
        public GameObject shakeWave;
        public LineRenderer shadowLine;
        public ParticleSystem dustParticle;
        public ParticleSystem jumpDustParticle1;
        public static void Flip(bool right)
        {
            // DustPlay();
            PlayerSingleton.Instance.transform1.rotation = Quaternion.Euler(0, right ? 0 : 180, 0);
            // SpriteRenderer[] spriteRenderers = Instance.gameObject1.GetComponentsInChildren<SpriteRenderer>();
            // foreach (var item in spriteRenderers)
            // {
            //     item.flipX = !right;
            // }
        }

        public static void FlipAll()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            bool right = PlayerSingleton.Instance.transform1.rotation.y == 0;
            if (mousePosition.x > PlayerSingleton.Instance.transform1.position.x)//鼠标方向在人物右侧
            {
                if (!right) Flip(true);
            }
            else//鼠标方向在人物左侧
            {
                if(right)  Flip(false);
            }
        }
        public  float ShakeForce;
        public  void CameraShake(CinemachineImpulseSource cinemachineImpulseSource)
        {
            cinemachineImpulseSource.GenerateImpulseWithForce(ShakeForce);
        }
    }
}