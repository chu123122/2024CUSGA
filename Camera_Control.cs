using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using QFramework;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Camera_Control : MonoBehaviour, ICanRegisterEvent, ICanGetModel
{
    private PlayerSelf_Model _playerSelfModel;
    private Dash_0_Model _dash0Model;
    private CinemachineConfiner _cinemachineConfiner2D;
    private CinemachineVirtualCamera _virtualCamera;
    private GameObject bond;

    private void Awake()
    {
        _playerSelfModel = this.GetModel<PlayerSelf_Model>();
        _dash0Model = this.GetModel<Dash_0_Model>();
        _cinemachineConfiner2D = this.GetComponent<CinemachineConfiner>();
        _virtualCamera = this.GetComponent<CinemachineVirtualCamera>();
        bond = GameObject.FindWithTag("Bond");
        _cinemachineConfiner2D.m_BoundingShape2D = bond.GetComponent<CompositeCollider2D>();
        this.RegisterEvent<PLayerDead_Event>(e =>
        {
            Debug.Log("PLayerDead_Event");
            Time.captureDeltaTime = 0;
            StartCoroutine(WatForSpawn(e.RestartPosition));
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
    }

    IEnumerator WatForSpawn(Vector3 restartPosition)
    {
        PlayerSingleton.Instance.gameObject1.SetActive(false);
        yield return new WaitForSeconds(1f);
        PlayerSingleton.Instance.gameObject1.SetActive(true);
        PlayerSingleton.Instance.transform1.position = restartPosition;
        PlayerSingleton.Instance.lineRenderer.enabled = false;
        _playerSelfModel.IsDashing = false;
        _playerSelfModel.IsGarbiing = false;
        _playerSelfModel.IsJumping = false;
        PlayerMove_Appcontroll.CanMove = true;
        //_dash0Model.InState = false;
        PlayerSingleton.Instance.rigidbody2D.gravityScale = this.GetModel<PlayerSelf_Model>().OrginGravityScale;

    }

    public float minSize = 5f;
    public float maxSize = 30f;
    public float sizeChangeSpeed = 1f;

    private void Update()
    {
        if (bond == null)
            bond = GameObject.FindWithTag("Bond");
        if (bond.GetComponent<CompositeCollider2D>() != null)
            _cinemachineConfiner2D.m_BoundingShape2D = bond.GetComponent<CompositeCollider2D>();

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float newSize = _virtualCamera.m_Lens.OrthographicSize - scrollInput * sizeChangeSpeed * Time.deltaTime;
        newSize = Mathf.Clamp(newSize, minSize, maxSize);
        _virtualCamera.m_Lens.OrthographicSize = newSize;

    }
    
   
  

public IArchitecture GetArchitecture()
    {
        return GameObjects_App.Interface;
    }
}
