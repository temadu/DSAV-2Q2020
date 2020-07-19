using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TransporterLevelGM : MonoBehaviour
{

  public const int PLAYERS_COUNT = 2;

  public static TransporterLevelGM instance;
  // public Rigidbody2D playerOne;

  public GameObject countdown;
  public GameObject centerScreenMessage;
  private TextMeshProUGUI centerScreenMessageText;
  public int nextLevel;
  public AudioSource endLevelSound;

  public bool isQuitting = false;


  void Awake()
  {
    instance = this;

  }
  void Start()
  {
    this.centerScreenMessageText = centerScreenMessage.GetComponent<TextMeshProUGUI>();
    this.centerScreenMessage.SetActive(false);
    this.centerScreenMessageText.SetText("");

    isQuitting = false;

    // this.countdown.SetActive(false);
    // this.Reset();
    // this.StartCountdown();

  }

  public void Reset()
  {
    // this.playerOne.transform.position = new Vector2(-4f, 0f);
    // this.playerOne.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
    // this.playerOne.velocity = Vector2.zero;
    // this.playerOne.angularVelocity = 0f;

    // this.StartCountdown();
    StartCoroutine("ResetLevel");
  }

  IEnumerator ResetLevel()
  {
    Time.timeScale = 0.3f;
    this.centerScreenMessageText.SetText("You Lost");
    this.centerScreenMessage.SetActive(true);
    float timePause = Time.realtimeSinceStartup + 3f;

    while (Time.realtimeSinceStartup < timePause)
    {
      yield return 0;
    }
    Time.timeScale = 1;
    this.centerScreenMessage.SetActive(false);
    this.centerScreenMessageText.SetText("");
    isQuitting = true;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

  }

  IEnumerator NextLevel() {
    Time.timeScale = 0.3f;
    this.centerScreenMessageText.SetText("Level Complete!\nAll aliens are safe!");
    this.centerScreenMessage.SetActive(true);
    float timePause = Time.realtimeSinceStartup + 3f;

    while (Time.realtimeSinceStartup < timePause)
    {
      yield return 0;
    }
    Time.timeScale = 1;
    this.centerScreenMessage.SetActive(false);
    this.centerScreenMessageText.SetText("");
    isQuitting = true;
    SceneManager.LoadScene(nextLevel);
  }

  public void GoToMenu()
  {
    isQuitting = true;
    SceneManager.LoadScene(0);
  }

  // public void StartCountdown()
  // {

  //   this.countdown.SetActive(true);
  //   StartCoroutine("StartDelay");

  // }

  IEnumerator StartDelay()
  {

    Time.timeScale = 0;
    float timePause = Time.realtimeSinceStartup + 3.5f;

    while (Time.realtimeSinceStartup < timePause)
    {
      yield return 0;
    }
    this.countdown.SetActive(false);
    Time.timeScale = 1;
  }

  public void checkWinCondition(){
    Debug.Log("Checking win");
    Debug.Log(GameObject.FindGameObjectsWithTag("Ball").Length);
    if(GameObject.FindGameObjectsWithTag("Ball").Length == 1){
      endLevelSound.Play();
      StartCoroutine("NextLevel");
    }
  }

  void OnApplicationQuit(){
    isQuitting = true;
  }

}
