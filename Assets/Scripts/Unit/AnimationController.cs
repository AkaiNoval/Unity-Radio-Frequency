using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private UnitStats unitStats;
    [SerializeField] private UnitStateController stateController;
    RuntimeAnimatorController previousRAC;
    CurrentState previouseState;
    [SerializeField] bool isDeathAnimationTriggered;
    private void Start()
    {
        // Set the initial animator controller during start
        SetAnimatorController();
    }
    private void Update()
    {
        // Check if the animator controller needs to be switched
        if (unitStats.Weapon == null) return;
        SwitchAnimatorController();
        SwitchAnimationClip();
    }
    private void SetAnimatorController()
    {
        // Store the initial runtime animator controller
        previousRAC = unitStats.Weapon.runtimeAnimController;
        // Assign the initial runtime animator controller to the animator
        animator.runtimeAnimatorController = previousRAC;
    }
    private void SwitchAnimatorController()
    {
        // Check if the runtime animator controller has changed
        if (previousRAC != unitStats.Weapon.runtimeAnimController)
        {
            // Update the runtime animator controller
            previousRAC = unitStats.Weapon.runtimeAnimController;
            // Assign the new runtime animator controller to the animator
            animator.runtimeAnimatorController = previousRAC;
        }
    }
    private void SwitchAnimationClip()
    {
        if (unitStats.IsDead() && isDeathAnimationTriggered == false)
        {
            isDeathAnimationTriggered = true;
            animator.SetTrigger("Death");
            return;
        }
        if (previouseState == stateController.currentState) return;
        previouseState = stateController.currentState;
        switch (stateController.currentState)
        {
            case CurrentState.Idle:
                animator.SetTrigger("Idle");
                break;
            case CurrentState.Moving:
                animator.SetTrigger("Moving");
                break;
            case CurrentState.RangedAttack:
                // Handle RangedAttack case
                break;
            case CurrentState.CloseAttack:
                animator.SetTrigger("MeleeAttack");
                break;
            case CurrentState.Support:
                // Handle Support case
                break;
            case CurrentState.UsingActiveAbility:
                animator.SetTrigger("ActiveAbility");
                break;
            case CurrentState.UsingPassiveAbility:
                animator.SetTrigger("PassiveAbility");
                break;
            case CurrentState.Null:
                animator.SetTrigger("Death");
                break;
            default:
                // Handle default case
                break;
        }     
    }
    public void TriggerActiveAbility()
    {
        unitStats.ActiveAbility.ApplyActiveAbility(stateController);
    }
    public void TriggerPassiveAbility()
    {
        unitStats.PassiveAbility.ApplyPassiveAbility(stateController);
    }
    public void ChangeToActiveAbilityState()
    {
        stateController.currentState = CurrentState.UsingActiveAbility;
    }
    public void ChangeToIdleState()
    {
        stateController.currentState = CurrentState.Idle;
    }

    public void TriggerMeleeAttack()
    {
        // Call the DealDamage method in the MeleeAttack state
        stateController.StateMeleeAttack.DealDamage(stateController, unitStats.Weapon.CanMultipleDamage);
    }



}

