using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlelr : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    [SerializeField]
    private Animator animator;
    private string currentAnimation = "";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Player Velocity = " + controller.velocity.magnitude);
        if (controller.velocity.magnitude > 0)
        {
            ChangeAnimation("Walking");
        } 
        else
        {
            ChangeAnimation("Idle");
        }
    }

    public  void CheckAnimation()
    {
        
    }

    public void ChangeAnimation(string animationName, float crossfadeTime = 0.2f)
    {
        if (currentAnimation != animationName)
        {
            currentAnimation = animationName;
            animator.CrossFade(animationName, crossfadeTime);
        }
    }
}
