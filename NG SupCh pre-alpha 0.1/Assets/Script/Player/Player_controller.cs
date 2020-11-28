using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_controller : MonoBehaviour
{
    /*
    private ServiceManager _serviceManager;
    */
    [SerializeField] private int _maxHp;
    private int _currentHp;
    Movement_controller _playerMovement;
    Vector2 _startPosition;
    void Start()
    {
        _playerMovement = GetComponent<Movement_controller>();
        _currentHp = _maxHp;
        _startPosition = transform.position;
        /* тут я здався
        _serviceManager = FindObjectOfType<ServiceManager>();
        */
    }

    public void ChangeHp(int value)
    {
        _currentHp -= value;
        if(_currentHp > _maxHp)
        {
            _currentHp = _maxHp;
        }
        else if(_currentHp <=0) 
        {
            OnDeath();
        }
        Debug.Log("value - " + value);
        Debug.Log("Current HP - " + _currentHp);

    }


    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
