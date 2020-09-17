using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class TimerControll : MonoBehaviour {
	public Text timerText;
 
	public float totalTime;
	int seconds;
 
	// Use this for initialization
	void Start () {

    }
 
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("ahan");
        if(other.gameObject.tag == "player")
        {
            totalTime -= Time.deltaTime;
            seconds = (int)totalTime;
            timerText.text = seconds.ToString();
            if(totalTime <= 0)
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);

            }
        }
    }
   private void OnTriggerExit(Collider other)
    {
        //Debug.Log("unnti");
        totalTime = 10;
    }
}