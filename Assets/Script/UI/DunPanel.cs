using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DunPanel : MonoBehaviour
{
  
	const int DunNum = 3;
  private Dun[] _duns = new Dun[3];


  void initDuns()
  {
    var dunPrefab = (GameObject)Resources.Load ("Prefab/dun");
    for (int i = 0; i < DunNum; i++)
    {
      var obj = (GameObject)Instantiate (dunPrefab);
      obj.transform.parent = this.transform;
      obj.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

      float x = 5.675f + (i-4)* 0.5f  ; 
      obj.transform.position = new Vector3 (x,0.7f,-i* 0.5f);

      var card = obj.GetComponent<Card> ();
      card.SetCard (cards[i]);
      cardViews[i] = card;
    }
  }
  
  
	void Start () {
		
	}
	
	void Update () {
		
	}
  
}
