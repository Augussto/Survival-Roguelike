using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerActions : MonoBehaviour
{
    private StarterAssetsInputs _input;
    private FirstPersonController _firstPersonController;
    [SerializeField]private Animator animator;
    //Animations Names
    private string Idle = "Idle", 
        Walk = "Walk",
        Attack01 = "Attack01", 
        Attack02 = "Attack02";
    private string currentAnimationState;
    private float attackCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _firstPersonController = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimations();
    }
    private void ChangeAnimationState(string newState)
    {
        // STOP THE SAME ANIMATION FROM INTERRUPTING WITH ITSELF //
        if (currentAnimationState == newState) return;

        // PLAY THE ANIMATION //
        currentAnimationState = newState;
        animator.CrossFadeInFixedTime(currentAnimationState, 0.2f);
    }
    private void SetAnimations()
    {
        if (!_input.attack)
        {
            if (_input.move.x == 0 && _input.move.y == 0)
            { ChangeAnimationState(Idle); }
            else
            { ChangeAnimationState(Walk); }
        }
    }

    public IEnumerator attackAnimations()
    {
        Debug.Log("Corrutina Ataque");
        if (attackCount == 0)
        {
            ChangeAnimationState(Attack01);
            attackCount++;
        }
        else
        {
            ChangeAnimationState(Attack02);
            attackCount = 0;
        }

        yield return new WaitForSeconds(0.3f);
        _input.attack = false;
        _firstPersonController.doingAnimation = false;
    }
}

