using System.Collections;
using System.Collections.Generic;
using GameLogic;
using UnityEngine;

public class StackPeak : MonoBehaviour
{
    /// <summary>
    /// Reference to a transform that is moved towards to top of stack
    /// </summary>
    [SerializeField] private Transform _stackTopTransform = default;
    
    [SerializeField] private CatStacker _stacker= default;
    
    [SerializeField]
    private Vector3 _offset = default;


    private void Start()
    {
        _stacker.StackHeightChange += HeightChangedHandler;
    }

    private void Update()
    {
        _stackTopTransform.transform.position =
            Vector3.SmoothDamp(
                _stackTopTransform.transform.position, 
                _targetPos + _offset, 
                ref _vel, 
                1);
    }

    
    private void HeightChangedHandler(Vector3 pos)
    {
        _targetPos = pos;
    }

    private Vector3 _targetPos;
    private Vector3 _vel;

}
