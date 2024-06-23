using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        protected virtual void Start()
        {
            animator = GetComponent<Animator>();
        }
    }
}
