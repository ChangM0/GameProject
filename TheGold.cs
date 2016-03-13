using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TheGold : MonoBehaviour {
    
    public GameObject gold;
    private Text goldText;  //Inventory panel price
    int Rnd = Random.Range(0, 10);
    PlayerHealth playerGold; //金幣數量

    void Start()
    {
        goldText = GameObject.FindGameObjectWithTag("UI").transform.Find("Inventory panel/Price/PriceText").GetComponent<Text>();
        Debug.LogWarning(goldText);
        playerGold = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        goldText.text = playerGold.Gold.ToString();
    }
    //当主角触碰金币时金币数量加10
    void OnTriggerEnter(Collider col)
    {
		//Debug.Log("1");
		//获取标签
        if (col.tag == "Player")
        {
            //碰撞两秒之后自动销毁
            
            playerGold.Gold += 10;
            goldText.text = playerGold.Gold.ToString();
            Destroy(this.gameObject);
        }
    }
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
