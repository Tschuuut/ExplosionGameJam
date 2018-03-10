﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplodingBomb : Bomb {
    public override void Explode() {
        Vector2 ballPosition = GameManager.Ball.transform.position;

        Vector2 direction = (ballPosition - (Vector2)transform.position).normalized * -1;

        float distance = Vector2.Distance(ballPosition, transform.position);

        GameManager.Ball.AddForce(direction * (1 / distance * force));

        GameManager.SoundManager.Explosion();
        animator.SetTrigger("Explode");
    }

    public override void Reset() {
        animator.SetTrigger("Reset");
    }
}
