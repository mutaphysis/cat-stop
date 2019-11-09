using System.Collections;
using System.Collections.Generic;
using GameLogic;
using UnityEngine;

/// <summary>
/// Controls character and placement of cats
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private CatStacker _catStacker = default;
    
    [Header("--- internal prefab references ------")]
    [SerializeField] private float _placementPeriod = 2;

    [SerializeField] private Animator _animator = default;

    [SerializeField] private float _limitMouseRange = 5f;

    [SerializeField] private Transform _handTransform = default;

    [SerializeField] private Transform _catSprite = null;

    [SerializeField] private GameObject _catPrefab = null;
    
    void Update()
    {
        PlaceCats();
    }

    private void PlaceCats()
    {
        var normalized = Input.mousePosition.x / Screen.width ;
        normalized = (normalized -0.5f) * _limitMouseRange  + 0.5f;
        
        _animator.SetFloat(_placementPropertyName, normalized);

        var catAge = Time.time - _lastPlacementTime;
        var shouldPlaceCat = catAge > _placementPeriod;
        if (shouldPlaceCat)
        {
            PlaceNewCat();
        }
        
        if(_catSprite)
            _catSprite.transform.localScale = Vector3.one *_catScaleUp.Evaluate(catAge); 
    }

    private void PlaceNewCat()
    {
        _animator.SetBool(_grammingPropertyName, true);
        _lastPlacementTime = Time.time;
        Invoke("ResetGrabbing", 0.2f);
        CreateNewCat();
        //var newCat = _catStacker.GetRandomCat();
        _catStacker.StackCat(newCat, Random.Range(-1f, 1f), Random.Range(0f, 360f));
        
    }

    private void CreateNewCat()
    {
        if(_catSprite)
            DestroyImmediate(_catSprite.gameObject);
        
        var newCat = Instantiate(_catPrefab, _handTransform);
        newCat.transform.localScale= Vector3.zero;
        _catSprite = newCat.transform;
    }

    private void ResetGrabbing()
    {
        _animator.SetBool(_grammingPropertyName, false);
    }
    
    private float _lastPlacementTime;
    private const string _placementPropertyName = "placement";
    private const string _grammingPropertyName = "grabbing";

    
    public AnimationCurve _catScaleUp = default;
}