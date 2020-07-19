using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

    public string otherObject = "Ball";
    public AudioSource ropeCutSound;
    public AudioSource alienSavedSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == otherObject)
        {
            DestroyBall();
            // Destroy(other.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == otherObject)
        {
            Destroy(other.gameObject);
        }
    }

    void DestroyBall(){
      GameObject elasticRopeGameObj = GameObject.FindGameObjectWithTag("Chain");
      ElasticRope rope = elasticRopeGameObj.GetComponent<ElasticRope>();
      GameObject ball = rope.endPoint;
      rope.DisconnectRope();
      ropeCutSound.Play();
      alienSavedSound.Play();
      Destroy(ball);
      Destroy(rope);

      TransporterLevelGM.instance.checkWinCondition();

    }


}
