using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class expManager : MonoBehaviour
{
    // Start is called before the first frame update
    int[] levelArray = new int[10] { 10, 30,50, 80, 100, 140, 180, 230, 260 ,300};
    int level = 1;
    int exp = 0;
    good goods;
    public expBarScript expBar;
    damageManager dam;
    public Text expText;
    
    void Start()
    {
        goods = GameObject.Find("guy").GetComponent<good>();
        expBar.SetMaxExp(levelArray[0]);
        dam = GameObject.Find("damage manager").GetComponent<damageManager>();
        expText.text = (level).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addExp(int add)
    {
        exp += add ;
        expBar.setExp(exp);
        if(exp>= levelArray[level-1])
        {
            
            if (level < 10)
            {
                level++;
                expText.text = (level).ToString();
                expBar.SetMaxExp(levelArray[level]-1);
                exp = 0;

                goods.changeBar(500 - goods.health);
                dam.damMult(level);
            }
        }
    }
}
