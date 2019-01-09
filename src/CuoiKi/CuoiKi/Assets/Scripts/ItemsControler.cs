using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsControler : MonoBehaviour {
    public static List<ItemObject> items;
	// Use this for initialization
	void Start () {
        items = new List<ItemObject>();
        ItemObject item = new ItemObject(this.GetComponentsInChildren<Image>()[0], PlayerInfo.numberBomb);
        items.Add(item);
        item = new ItemObject(this.GetComponentsInChildren<Image>()[1], PlayerInfo.numberTrap);
        items.Add(item);
        item = new ItemObject(this.GetComponentsInChildren<Image>()[2], PlayerInfo.numberHealth);
        items.Add(item);
        item = new ItemObject(this.GetComponentsInChildren<Image>()[3], PlayerInfo.numberFire);
        items.Add(item);
        item = new ItemObject(this.GetComponentsInChildren<Image>()[4], PlayerInfo.numberIce);
        items.Add(item);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
