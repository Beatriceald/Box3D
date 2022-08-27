using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 10;

    public bool Invulnerable = false;

    public UnityEvent EventOnTakeDamage;
    public UnityEvent EventOnDefeat;

    private void Start() {
        //HealthBar.fillAmount = (float)Health * 0.1f;
    }

    private void Update() {
        //HealthBar.fillAmount = (float)Health * 0.1f;
    }


    public void TakeDamage(int damageValue) {
        if (Invulnerable == false) {
            Health -= damageValue;
            if (Health <= 0) {
                Health = 0;
                Defeat();
            }
            Invulnerable = true;
            Invoke("StopInvulnerable", 1f);
            EventOnTakeDamage.Invoke();
        }
    }

    public void StartInvulnerable() {
        Invulnerable = true;
    }

    public void StopInvulnerable() {
        Invulnerable = false;
    }

    public void Defeat() {
        EventOnDefeat.Invoke();
    }
}
