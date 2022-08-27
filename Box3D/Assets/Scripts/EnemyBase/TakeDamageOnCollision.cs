using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    //public EnemyHealth EnemyHealth;
    public PlayerHealth PlayerHealth;

    private void OnCollisionEnter(Collision collision) {
        if (collision.rigidbody) {
            if (collision.rigidbody.GetComponent<EnemyHealth>()) {
                PlayerHealth.TakeDamage(1);
            }
        }
    }

    //private void OnCollisionEnter(Collision collision) {
    //    if (collision.gameObject.GetComponentInParent<Gloves>()) {
    //        PlayerHealth.TakeDamage(1);
    //    }
    //}
}
