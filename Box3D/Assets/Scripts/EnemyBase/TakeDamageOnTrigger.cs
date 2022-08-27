using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    public EnemyHealth EnemyHealth;

    private void OnTriggerEnter(Collider other) {
        if (other.attachedRigidbody) {
            if (other.attachedRigidbody.GetComponent<Gloves>()) {
                EnemyHealth.TakeDamage(1);
            }
        }
    }
}
