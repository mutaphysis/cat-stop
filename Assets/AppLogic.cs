﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppLogic : MonoBehaviour
{

    [SerializeField] private GameObject _titleGroup= default;

    [SerializeField] private GameObject _gameGroup = default;
    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case States.Title:
                if(Input.GetMouseButtonDown(0))
                    SetState(States.InGame);
                break;
            
            case States.InGame:
                if(Input.GetMouseButtonDown(0))
                    SetState(States.Title);
                break;
        }
    }


    public void SetState(States newState)
    {
        if (newState == _state)
            return;

        
        switch (newState)
        {
            case States.Title:
                _titleGroup.SetActive(true);
                _gameGroup.SetActive(false);
                break;
            
            case States.InGame:
                _titleGroup.SetActive(false);
                _gameGroup.SetActive(true);
                break;
        }
        _state = newState;
    }

    public States _state = States.Title;
    public enum States
    {
        Title,
        InGame,
    }
}
