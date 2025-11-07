using C_.Qframework.Player.Dash._Model;
using UnityEngine;
using QFramework;
public class PlayerTransPosition_Command : AbstractCommand
{
    private PlayerDash_Model _playerDash_Model;

    private Rigidbody2D _rb;
    private bool _hasFreezeDuration = true;
    private bool _isDashing=true;
    private float _speedModifier;
    private float _time=0;
    public bool IsDashing
    {
        get
        {
            return _isDashing;
        }
        set => _isDashing=value;
    }
    protected override void OnExecute()
    {
        _playerDash_Model =this.GetModel<PlayerDash_Model>();
        GameObject Player =PlayerSingleton.Instance.gameObject1;
        _rb = Player.GetComponent<Rigidbody2D>();
        Transform transform = Player.transform;
        _time += Time.deltaTime;

        if(_playerDash_Model.CanSeeTime) Debug.Log("PlayerDashTime:"+ _time);

        _speedModifier = _playerDash_Model.SpeedCurve.Evaluate(_time);
        if (_isDashing)
        {
            if (_hasFreezeDuration)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    _playerDash_Model.DashPosition
                    ,_playerDash_Model.MoveSpeed * _speedModifier * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, _playerDash_Model.DashPosition) < 0.1f)
            {
                _isDashing = false;
                
                _rb.velocity = Vector2.zero;
                _hasFreezeDuration = false;
            }
        }
       
    }
   
}
