using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Management : MonoBehaviour {
    public Image PlayerHealthBar;
    public Image EnemyHealthBar;

    public PlayerHealth PlayerHealth;
    public EnemyHealth EnemyHealth;

    public GameObject Enemy;
    public GameObject Buttons;

    public Text TimerText;
    public float TimeStart = 10f;

    [Header("Enemy chance to stay")]
    [SerializeField] private float minChance;
    [SerializeField] private float maxChance;
    [SerializeField] private float ChanceThreshold;
    [SerializeField] private float chance;
    private bool _isChanceUsed = false;

    private bool _isSecondRound = false;

    [Header("Round Results")]
    public GameObject FirstRound;
    public GameObject SecondRound;

    public GameObject Winning;
    public GameObject Lose;

    public AudioSource WinSound;
    public AudioSource DefeatSound;
    public AudioSource GongSound;


    // Start is called before the first frame update
    void Start() {
        DisplayHealth();
        TimerText.text = TimeStart.ToString();
        ChanceToStay();
        GongSound.Play();
    }

    // Update is called once per frame
    void Update() {
        DisplayHealth();

        if (PlayerHealth.Health == 0 || EnemyHealth.Health == 0) {

            FindObjectOfType<SetTriggerEveryNSeconds>().StopCoroutine();
            Enemy.GetComponent<SetTriggerEveryNSeconds>().enabled = false;

            if (TimeStart > 0) {
                TimerText.enabled = true;
                TimeStart -= Time.deltaTime;
                TimerText.text = Mathf.Round(TimeStart).ToString();

                if (EnemyHealth.Health == 0) {
                    Enemy.GetComponent<Animator>().SetBool("isDefeat", true);

                    if (chance > ChanceThreshold && _isChanceUsed == false) {
                        if (TimeStart < 4.5f) {
                            Enemy.GetComponent<SetTriggerEveryNSeconds>().enabled = true;
                            Enemy.GetComponent<Animator>().SetBool("isDefeat", false);
                            TimerText.enabled = false;
                            FindObjectOfType<SetTriggerEveryNSeconds>().StartCoroutine();
                            EnemyHealth.Health = 5;
                            TimeStart = 10f;
                            _isChanceUsed = true;
                        }
                    } else {
                        //смена на второй уровень, противник не встал, победа в 1м раунде
                        if (TimeStart <= 0) {
                            WinSound.Play();
                            TimerText.enabled = false;
                            Winning.SetActive(true);
                            if (_isSecondRound == false) {
                                _isSecondRound = true;
                                Invoke("StartSecondRound", 5f);
                            }
                        }
                    }
                } else if (PlayerHealth.Health == 0) {
                    FindObjectOfType<Gloves>().enabled = false;
                    //экран проигрыша в 1м раунде
                    if (TimeStart <= 0) {
                        DefeatSound.Play();
                        TimerText.enabled = false;
                        Lose.SetActive(true);
                        if (_isSecondRound == false) {
                            _isSecondRound = true;
                            Invoke("StartSecondRound", 5f);
                        }
                    }
                }
            } else if (TimeStart == 0f) { //смена на второй уровень
                if (EnemyHealth.Health == 0) {
                    //противник пал после шанса встать
                    Enemy.GetComponent<Animator>().SetBool("isDefeat", true);
                    if (TimeStart <= 0) {
                        WinSound.Play();
                        TimerText.enabled = false;
                        Winning.SetActive(true);
                        if (_isSecondRound == false) {
                            _isSecondRound = true;
                            Invoke("StartSecondRound", 5f);
                        }
                    }
                } else if (PlayerHealth.Health == 0) {
                    FindObjectOfType<Gloves>().enabled = false;
                    //экран проигрыша во 2м раунде
                    if (TimeStart <= 0) {
                        DefeatSound.Play();
                        TimerText.enabled = false;
                        Lose.SetActive(true);
                    }
                }
            }
        }
    }

    void DisplayHealth() {
        PlayerHealthBar.fillAmount = (float)PlayerHealth.Health * 0.1f;
        EnemyHealthBar.fillAmount = (float)EnemyHealth.Health * 0.1f;
    }

    public void ChanceToStay() {
        chance = Random.Range(minChance, maxChance);
    }

    public void StartSecondRound() {
        //_isSecondRound = isSecondRound;
        Enemy.GetComponent<Animator>().SetBool("isDefeat", false);
        Enemy.GetComponent<SetTriggerEveryNSeconds>().enabled = true;
        FindObjectOfType<SetTriggerEveryNSeconds>().StartCoroutine();
        FindObjectOfType<Gloves>().enabled = true;
        FirstRound.SetActive(false);
        SecondRound.SetActive(true);
        Winning.SetActive(false);
        Lose.SetActive(false);
        TimeStart = 10f;
        PlayerHealth.Health = 10;
        EnemyHealth.Health = 10;
        _isChanceUsed = false;
        TimerText.enabled = false;
    }
}
