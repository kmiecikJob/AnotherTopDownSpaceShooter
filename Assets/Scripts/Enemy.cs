using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy
{
    void GetHit();
    void ResetPosition();

    void Attack();
}
