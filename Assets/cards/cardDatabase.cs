using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardDatabase : MonoBehaviour
{
    public static List<card> cardList = new List<card> ();
    

    void Awake()
    {
        cardList.Add(new card (0,"molt", 2,0,"Leave a decoy to confuse enemy" , "skillImages/jokerImage"));
        cardList.Add(new card(1, "fireball", 4, 1, "Cast a fireball to damage enemies", "skillImages/fireballImage"));
        cardList.Add(new card(2, "Shrink", 3, 1, "Shrink to make life harder for enemies", "skillImages/shrinkImage"));
            cardList.Add(new card(3, "Beam", 2, 1, "beam enemies", "skillImages/beamImage"));
        cardList.Add(new card(3, "Collect", 2, 1, "Collect expstones", "skillImages/magnetImage"));
        cardList.Add(new card(3, "Tornado", 4, 1, "tornado", "skillImages/tornadoImage"));



    }
}
