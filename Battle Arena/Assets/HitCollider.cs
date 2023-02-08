using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    public string punchName;
    public float damage;

    public Fighter owner;

    private void OnTriggerEnter(Collider other)
    {
        Fighter somebody = other.GetComponent<Fighter>();
        if (owner.attacking)
        {
            if(somebody != null && somebody != owner)
            {
                somebody.Hurt(damage);
            }
        }
    }
}
