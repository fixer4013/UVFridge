using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator[] _ObjectsWithAnimations;
    public bool _Open;
    public void GetAnimations(GameObject clone)
    {
        _ObjectsWithAnimations = clone.GetComponentsInChildren<Animator>();
    }

    // Update is called once per frame
    public void ChangeBool(bool open)
    {
        _Open = open;
    }
    void Update()
    {
        for(int i = 0; i < _ObjectsWithAnimations.Length; i++)
        {
            _ObjectsWithAnimations[i].SetBool("Open", _Open);
        }
    }
}
