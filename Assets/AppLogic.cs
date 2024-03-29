﻿using System;
using System.Collections;
using System.Collections.Generic;
using GameLogic;
using UnityEngine;

public class AppLogic : MonoBehaviour
{

    [SerializeField] private GameObject _titleGroup= default;

    [SerializeField] private GameObject _gameGroup = default;

    [SerializeField] private CatStacker _catStacker = default;

    private void Awake()
    {
        SetState(States.Title);    // Hide game scene
    }


    void Update()
    {
        switch (_state)
        {
            case States.Title:
                if(Input.GetMouseButtonDown(0))
                    SetState(States.InGame);
                break;

            case States.InGame:
                if (Input.GetMouseButtonDown(0))
                {
                    _catStacker.PlaceFinalBear();
                    SetState(States.Title);
                }
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
                _catStacker.Clear();
                break;
        }
        _state = newState;
    }

    public States _state = States.Unknown;
    public enum States
    {
        Unknown,
        Title,
        InGame,
    }
}
