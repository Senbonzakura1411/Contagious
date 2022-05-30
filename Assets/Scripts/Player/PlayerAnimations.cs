using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] public Animator anim;


    public float x;
    public float y;


    private void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //SetAnimations();
    }

   /* void SetAnimations ()
    {
        anim.SetFloat("x", x);
        anim.SetFloat("y", y);
    }*/

}
