using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSeconds : MonoBehaviour
{
    public float PeriodBetweenFirstAndSecondAnimation = 1.5f;
    public float PeriodBetweenSecondAndThirdAnimation = 1.5f;
    public float PeriodBetweenThirdAndFourthAnimation = 1.5f;

    public Animator EnemyAnimator;

    public EnemyHealth EnemyHealth;

    public AudioSource HitSound;

    public float InvulnerableBlockingTime;

    private IEnumerator coroutine;

    private float _timer;

    public string FirstTrigger = "Attack";
    public string SecondTrigger = "Blocking";
    public string ThirdTrigger = "Attack";

    private void Update() {
        _timer += Time.deltaTime;
        if(_timer > PeriodBetweenFirstAndSecondAnimation + PeriodBetweenSecondAndThirdAnimation + PeriodBetweenThirdAndFourthAnimation) {
            _timer = 0;
            coroutine = EnemyMoveset();
            StartCoroutine(coroutine);
        }
    }

    public IEnumerator EnemyMoveset() {
        EnemyHealth.StopInvulnerable();
        HitSound.Play();
        EnemyAnimator.SetTrigger(FirstTrigger);
        yield return new WaitForSeconds(PeriodBetweenFirstAndSecondAnimation);
        EnemyHealth.StopInvulnerable();
        HitSound.Play();
        EnemyAnimator.SetTrigger(SecondTrigger);
        yield return new WaitForSeconds(PeriodBetweenSecondAndThirdAnimation);
        EnemyHealth.StartInvulnerable();
        EnemyAnimator.SetTrigger(ThirdTrigger);
        //HitSound.Play();
        yield return new WaitForSeconds(PeriodBetweenThirdAndFourthAnimation);
        EnemyHealth.StopInvulnerable();
        HitSound.Play();
        EnemyAnimator.SetTrigger(SecondTrigger);
        yield return new WaitForSeconds(PeriodBetweenSecondAndThirdAnimation);
        EnemyHealth.StartInvulnerable();
        EnemyAnimator.SetTrigger(ThirdTrigger);
        //HitSound.Play();
        yield return new WaitForSeconds(PeriodBetweenThirdAndFourthAnimation);
    }

    void EnemyBlocking() {
        EnemyHealth.StartInvulnerable();
        EnemyAnimator.SetTrigger(SecondTrigger);
        Invoke("StopInvulnerable", InvulnerableBlockingTime);
    }

    public void StopInvulnerable() {
        EnemyHealth.StopInvulnerable();
    }

    public void StartCoroutine() {
        StartCoroutine(coroutine);
    }

    public void StopCoroutine() {
        StopCoroutine(coroutine);
    }

    private void PlayHit() {
        HitSound.Play();
    }
}
