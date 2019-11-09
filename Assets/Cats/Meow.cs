using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meow : MonoBehaviour
{
    [Header("--- internal prefab references ----")] [SerializeField]
    private AudioSource _audioSource = default;

    [SerializeField] private AudioClip[] _meowSoundClips = default;
    [SerializeField] private float _minPause = 3;
    [SerializeField] private float _maxPause = 10;

    private void Awake()
    {
        _audioSource.clip = _meowSoundClips[Random.Range(0, _meowSoundClips.Length)];
    }

    void Update()
    {
        if (Time.time > _nextMeowTime)
        {
            _audioSource.Play();
            _audioSource.loop = false;
            _nextMeowTime = Time.time + Random.Range(_minPause, _maxPause);
        }
    }

    private float _nextMeowTime;
}
