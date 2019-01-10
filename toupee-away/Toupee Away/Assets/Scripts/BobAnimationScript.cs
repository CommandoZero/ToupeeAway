using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobAnimationScript : MonoBehaviour
{

    Animator bobAnimator;
    Animation anim;
    private void Start()
    {
        bobAnimator = gameObject.GetComponent<Animator>();
    }

    public void RunToJumpOne()
    {
       // bobAnimator.SetBool("Run_To_Jump1", aBool);
        bobAnimator.Play("BobJumpOne");
    }

    public void JumpOneToJumpTwo(bool aBool)
    {
        bobAnimator.SetBool("Jump1_To_Jump2", aBool);
    }
    public void JumpOneToJumpThree(bool aBool)
    {
        bobAnimator.SetBool("Jump1_To_Jump3", aBool);
    }
    public void JumpTwoToRun(bool aBool)
    {
        bobAnimator.SetBool("Jump2_To_Run", aBool);
    }
    public void RunToHashtag()
    {
        bobAnimator.Play("BobHash");
    }
    public void HashtagToRun(bool aBool)
    {
        bobAnimator.SetBool("Hashtag_To_Run", aBool);
    }

    public void RunToPickup(bool aBool)
    {
        bobAnimator.SetBool("Run_To_Pickup", aBool);
    }

    public void RunToWhole(bool aBool)
    {
        bobAnimator.SetBool("Run_To_Whole", aBool);
    }

    public void Whole_To_Run(bool aBool)
    {
        bobAnimator.SetBool("Whole_To_Run", aBool);
    }
    public void GameOver()
    {
        bobAnimator.SetBool("GameOver", true);
    }
}
