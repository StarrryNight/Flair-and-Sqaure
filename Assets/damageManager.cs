using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class damageManager : MonoBehaviour
{
    GameObject text;
   public Canvas canvas;
    public int beamDamage;
    public int normalDamage;
    public int fireballDamage;
    int basebeamDamage;
     int basenormalDamage;
     int basefireballDamage;
    expManager expman;
    public particleSystemScript sp;

    // Start is called before the first frame update
    void Start()
    {
        text = Resources.Load("popUp/damageNumberIndicatorParent") as GameObject;


     basebeamDamage = beamDamage;
    basenormalDamage = normalDamage;
    basefireballDamage= fireballDamage;
}

    // Update is called once per frame
    void Update()
    {
        
    }


    public void damageNum(Vector3 worldPosition, int damage)
    {
        sp.emit(worldPosition);
       
       GameObject s=Instantiate(text, canvas.transform );
        s.transform.GetChild(0).GetComponent<Text>().text = "-" + damage;
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, worldPosition);
        Vector2 anchoredPosition = transform.InverseTransformPoint(screenPoint);
        s.transform.position = anchoredPosition;
        Destroy(s, 0.5f);

        }

    public void damMult(int lev)
    {
        beamDamage = basebeamDamage *(10 + lev )/10;
        normalDamage = basenormalDamage * (10 + lev)/10;
     fireballDamage= basefireballDamage *(10 + lev)/10;
}
}
