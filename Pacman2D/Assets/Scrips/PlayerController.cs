using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int points = 0;
    bool canBeAttacked = false;

    public bool CanBeAttacked
    {
        get { return canBeAttacked; }
        private set { }
    }

    public void AddPoint()
    {
        points++;
    }

    public void IsAttack()
    {
        canBeAttacked = true;

        StartCoroutine(WaitAttack());
    }

    IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(5f);

        canBeAttacked = false;
    }

}
