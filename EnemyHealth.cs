using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int CurHealth = 100; 
	public float healthBarLength;
    public bool Is_Attacked = false;
    float time = 0.65f;
    public TheGold TheGold;
    public RedBottle RedElixir;
    public GameObject blood_effect;
    public Shoes Shoes;
    public Cloth Cloth;

	//public int count_enemy = 0;//怪物死亡數量
	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width / 2;
        Is_Attacked = false;
        Cloth = Resources.Load<GameObject>("Equippment/Cloth").transform.GetComponent<Cloth>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Is_Attacked) time -= Time.deltaTime;
        if (time < 0) { Is_Attacked = false; time = 0.65f; }
		if(CurHealth <= 0){
			GameObject.FindWithTag("Player").GetComponent<PlayerAttack>().target.Remove(gameObject);
			Destroy(this.gameObject);
			//count_enemy++;
            //根据随机数值为生成不同的物品
            int Rnd = Random.Range(0,1); 
            switch(Rnd)
            {
                case 0: 
                //生成金币
                Instantiate(TheGold, this.transform.position, Quaternion.identity);
                break;
                case 1:
                //生成血瓶
                Instantiate(RedElixir, this.transform.position, Quaternion.identity);
				break;
            }
            Instantiate(Cloth, this.transform.position, Quaternion.identity);
            //switch (Rnd)
            //{
            //    case 0:
            //        Instantiate(Shoes, this.transform.position, Quaternion.identity);
            //        break;
            //    case 1:
            //        Instantiate(Cloth, this.transform.position, Quaternion.identity);
            //        break;
            //}
		}
	}
	void OnGUI(){
		//GUI.Box (new Rect (10,40,healthBarLength,20), CurHealth + "/" + maxHealth);
	}
	public void addjustCurrentHealth(int adj){
		CurHealth += adj;
		if (CurHealth < 0)CurHealth = 0;
		if (CurHealth > maxHealth)CurHealth = maxHealth;
		if (maxHealth < 1)maxHealth = 1;
		healthBarLength = (Screen.width / 2) * (CurHealth / (float)maxHealth); 
	}
    public void Injured(int dps)
    {
        Is_Attacked = true;
        CurHealth -= dps;
        Instantiate(blood_effect,this.gameObject.transform.position,Quaternion.identity);
    }
    //
	/*void OnCollisionEnter(){
		CurHealth--;
	}*/
}
