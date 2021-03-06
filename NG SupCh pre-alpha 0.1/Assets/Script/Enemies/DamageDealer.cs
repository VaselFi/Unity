﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _timeDelay;
    private Player_controller _player;
    private DateTime _lastEncounter;
    private void OnTriggerEnter2D(Collider2D info)
    {
        if ((DateTime.Now - _lastEncounter).TotalSeconds < _timeDelay / 2)
            return;
        _lastEncounter = DateTime.Now;
        _player = info.GetComponent<Player_controller>();
        if (_player != null)

            _player.ChangeHp(_damage);
    }

    void OnTriggerExit2D(Collider2D info)
    {
        if(_player == info.GetComponent<Player_controller>())
        _player = null;
    }

    private void update()
    {
        if(_player != null && (DateTime.Now - _lastEncounter).TotalSeconds > _timeDelay)
        {
            _player.ChangeHp(-_damage);
            _lastEncounter = DateTime.Now;
        }
    }
}
