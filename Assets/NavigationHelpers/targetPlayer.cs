using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetPlayer : MonoBehaviour
{
    public GameObject avatar; //navmesh avatar
    private UnityEngine.AI.NavMeshAgent _agent; // navmesh agent
    private BaseEnemy _thisEnemy;
    private Player _targetPlayer; //targeting player
    private GameObject _targetAvatar; //player's navmesh avatar

    void Start()
    {
        //avatar agent go to sprite location
        avatar.transform.position = new Vector3(transform.position.x,
                                                avatar.transform.position.y,
                                                transform.position.z);
        
        CheckTarget();
        _agent = avatar.GetComponent<UnityEngine.AI.NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _thisEnemy = GetComponent<BaseEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTarget();

        if (_targetAvatar)
        {
            //do not move when attacking
            if (!_thisEnemy.isAttacking()){
                _agent.enabled = true;
                //make agent go to target player avatar mesh
                _agent.SetDestination(_targetAvatar.transform.position);
            }   
            else{_agent.enabled = false;}
        }
        //move enemy sprite to follow its navmesh agent
        transform.position = new Vector3(avatar.transform.position.x, 
                                            transform.position.y, 
                                            avatar.transform.position.z);
        
    }

    private void CheckTarget()
    {
        if (GetComponent<BaseEnemy>().getTargetPlayer())
        {
            _targetPlayer = GetComponent<BaseEnemy>().getTargetPlayer().GetComponent<Player>();
            _targetAvatar = GetComponent<BaseEnemy>().getTargetPlayer().GetComponent<NavHelper>().avatar;
        }
        else
        {
            _targetAvatar = null;
        }
    }
    public void ResetTarget()
    {
        _targetPlayer = null;
        _targetAvatar = null;
        _agent.enabled = false;
    }
}
