using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimatorController : MonoBehaviour
{

    [SerializeField] private InputActionProperty triggerAction;
    [SerializeField] private InputActionProperty gripAction;

    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    private void Update()
    {
        float tiggerValue =triggerAction.action.ReadValue<float>();
        float gripvalue =gripAction.action.ReadValue<float>();

        anim.SetFloat("Trigger", tiggerValue);
        anim.SetFloat("Grip", gripvalue);
        


    }
}
