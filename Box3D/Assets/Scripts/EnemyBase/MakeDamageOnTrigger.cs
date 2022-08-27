using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour {
    public int DamageValue = 1;
    public EnemyHealth EnemyHealth;

    //private void OnTriggerEnter(Collider other) {
    //    if (other.attachedRigidbody) {
    //        if (other.attachedRigidbody.GetComponent<EnemyHealth>()) {
    //            EnemyHealth.TakeDamage(DamageValue);
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<EnemyHealth>()) {
            EnemyHealth.TakeDamage(DamageValue);
        }
    }

    //private void OnTriggerEnter(Collider other) {
    //    if (other.attachedRigidbody) {
    //        if (other.attachedRigidbody.CompareTag("Player")) {
    //            if (other.attachedRigidbody.GetComponent<PlayerHealth>()) {
    //                other.attachedRigidbody.GetComponent<PlayerHealth>().TakeDamage(DamageValue);
    //            }
    //        }
    //    }
    //}
}
