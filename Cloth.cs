using UnityEngine;
using System.Collections;

public class Cloth : MonoBehaviour {


    void OnTriggerEnter(Collider col)
    {
        //获取标签
        if (col.tag == "Player")
        {
            GameObject.Find("inventory").transform.GetComponent<Inventory>().AddItem(1);
            Destroy(this.gameObject);
            
        }
    }
}
