using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using UnityEditor;

public class PlayerInGround_AppControl : MonoBehaviour, IController,ICanSendEvent
{
    private PlayerSelf_Model _playerSelfModel;
    private void Awake()
    {
        _playerSelfModel=this.GetModel<PlayerSelf_Model>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FixtedObjects")) _playerSelfModel.InGround = true;
        if(collision.gameObject.layer ==LayerMask.NameToLayer("Ground"))_playerSelfModel.LayIsGround = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("FixtedObjects"))
        {
            _playerSelfModel.InGround = true;
            _playerSelfModel.DashMount = 1;
            _playerSelfModel.GrabMount = 1;
        }
        if(collision.gameObject.layer ==LayerMask.NameToLayer("Ground"))_playerSelfModel.LayIsGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("FixtedObjects"))
        {
            _playerSelfModel.InGround = false;
        }
        if(collision.gameObject.layer ==LayerMask.NameToLayer("Ground"))_playerSelfModel.LayIsGround = false;
    }
    public IArchitecture GetArchitecture()
    {
        return GameObjects_App.Interface;
    }

}
