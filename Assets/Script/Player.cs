using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject Fish_Object;
    public GameObject Range;
    bool flg = false;

    private void Start()
    {
        //Range = GameObject.Find("range");
    }

    // Update is called once per frame
    void Update () {
        Vector3 mouse = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.transform.position = hit.collider.gameObject.transform.position;
                if (hit.collider.gameObject.tag == "sakana")
                {
                    flg = true;
                    Fish_Object = hit.collider.gameObject;
                }
            }
            
        }
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
        if (flg)
        {
            this.gameObject.transform.position = Fish_Object.gameObject.transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "syougaibutu")
        {
            Destroy(this.gameObject);
        }
    }
}

