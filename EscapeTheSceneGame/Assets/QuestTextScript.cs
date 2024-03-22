using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTextScript : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void FadeIn()
    {
        anim.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        anim.SetTrigger("FadeOut");
    }
}
