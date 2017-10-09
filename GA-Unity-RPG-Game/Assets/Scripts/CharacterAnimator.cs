using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour {

    const float locomationAnimationSmoothTime = .1f;

    NavMeshAgent agent;
    Animator animator;

	
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
	}

	
	void Update () {

        float sppedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", sppedPercent, locomationAnimationSmoothTime, Time.deltaTime);
	
	}
}