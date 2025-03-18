using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : GameUnit
{
    [SerializeField] private bool isCanChange = false;

    [SerializeField] private Animator anim;

    public Animator Anim => anim;
}
