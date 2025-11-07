using QFramework.Player.NewPlayerAutoGrab._Data;
using QFramework.Player.NewPlayerGrab._Data;
using QFramework.Player.PlayerSelf.Data;
using UnityEngine;
using UnityEngine.Serialization;

public class DataManager: MonoBehaviour
{
    #region Singleton

        private static DataManager _instance;

        public static DataManager Instance
        {
            get { return _instance; }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

    #endregion
    
    public PlayerMove_Data moveData;
    public PlayerJump_Data jumpData;
    public PlayerDash_Data dashData;
    public Dash_0_Data dash_0_Data;
    public Dash_1_Data dash_1_Data;
    public AutoGarb_Data autoGrabData;
    [FormerlySerializedAs("cloneCircleHit_Data")] public Circle_Data circleData;
    [FormerlySerializedAs("newAutoGarbData")] [FormerlySerializedAs("newGarb_Data")] public AutoGarb_Data  autoGarbData;
    [FormerlySerializedAs("newPlayerGrabData")] public NewGrab_Data newGrabData;
    public PlayerSelf_Data playerSelf_Data;
}



