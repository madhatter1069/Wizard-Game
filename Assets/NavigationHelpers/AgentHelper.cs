using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentHelper : MonoBehaviour
{
    public GameObject avatar; //navmesh avatar
    public float planeYOffset;

    private GameObject _targetAvatar; //navmesh target
    private NavMeshAgent _agent; // navmesh agent
    private Player _targetPlayer; //targeting player
    private BaseEnemy _thisEnemy;


    // Start is called before the first frame update
    void Start()
    {
        //init avatar's position
        avatar.transform.position = new Vector3(transform.position.x,0,transform.position.y+planeYOffset);


        CheckTarget();
        _agent = avatar.GetComponent<NavMeshAgent>();
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
            if (!_thisEnemy.isAttacking())
            {
                _agent.enabled = true;
                _agent.SetDestination(_targetAvatar.transform.position);
            }
                
            else
            {
                _agent.enabled = false;
            }
        }

        //update this position in terms of avatar's position
        transform.position = new Vector3(avatar.transform.position.x, avatar.transform.position.z-planeYOffset,0);
       
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

    //helpers
    public void ResetTarget()
    {
        _targetPlayer = null;
        _targetAvatar = null;
        _agent.enabled = false;
    }
}
