using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sakana : MonoBehaviour {

    // 変化量
    private float dx;

    public GameObject Player;
    void Start()
    {
        dx = Random.Range(10, 50);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        Player = GameObject.Find("player");
    }

    void Update()
    {
        // dxは任意の値
        //this.transform.position += new Vector3(0, 0, dx * Time.deltaTime);
        this.transform.Translate(Vector3.forward * Time.deltaTime * dx);
    }
    private void OnTriggerStay(Collider other)
    { 
        if(other.gameObject.tag == "player")
        {
            //Debug.Log("ouhu");
            if( Input.GetKey(KeyCode.A)){
                transform.Rotate(new Vector3(0, -1, 0));
            }else if (Input.GetKey(KeyCode.D)){
                transform.Rotate(new Vector3(0, 1, 0));
            }
        }
        if (other.gameObject.tag == "syougaibutu")
        {
            if (other.gameObject.tag == "syougaibutu")
            {
                Destroy(this.gameObject);
            }
        }
        if(other.gameObject.tag == "sakana")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
