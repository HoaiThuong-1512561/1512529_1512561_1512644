using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject  {
    Image item;
    int itemNumber;
	public ItemObject(Image game,int number)
    {
        item = game;
        itemNumber = number;
        item.GetComponentsInChildren<Text>()[1].text = "x" + itemNumber;
        
    }
    public void setItem(int number)
    {
        itemNumber = number;
        item.GetComponentsInChildren<Text>()[1].text = "x" + itemNumber;
    }
}
