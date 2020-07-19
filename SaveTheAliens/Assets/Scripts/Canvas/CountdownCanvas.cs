using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownCanvas : MonoBehaviour
{

  public static bool IsPlaying = false;

  public TMPro.TextMeshProUGUI counterText;
  public AudioSource threeSound;
  public AudioSource twoSound;
  public AudioSource oneSound;
  public AudioSource goSound;

  public void Start(){
    Time.timeScale = 0;
    IsPlaying = true;
  }

  public void Clean()
  {
    counterText.text = "";
    gameObject.SetActive(false);
    IsPlaying = false;
  }
  public void Count3()
  {
    counterText.text = "3";
    threeSound.Play();
  }
  public void Count2()
  {
    counterText.text = "2";
    twoSound.Play();
  }
  public void Count1()
  {
    counterText.text = "1";
    oneSound.Play();
  }
  public void GO()
  {
    counterText.text = "GO!";
    goSound.Play();
    Time.timeScale = 1;
  }

  
}
