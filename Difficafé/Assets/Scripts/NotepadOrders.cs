using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
struct CupSpriteList
{
    public List<SpriteList> sprites;
}
[System.Serializable]
public struct SpriteList
{
	public List<Sprite> sprites;
}

public class NotepadOrders : MonoBehaviour
{
    [NonSerialized] public List<CustomerOrder> Orders;
	[NonSerialized] public int CurrentIndex;
    [SerializeField] List<Sprite> OrderCupSprites;
	[SerializeField] SpriteRenderer TableId;
	[SerializeField] List<Sprite> TableIdSprites;
	[SerializeField] SpriteRenderer OrderCup;
	[SerializeField] List<CupSpriteList> OrderCupLayerSprites;
	[SerializeField] List<SpriteRenderer> OrderCupLayers;
	[SerializeField] List<Sprite> OrderExtraItemSprites;
    [SerializeField] List<SpriteRenderer> OrderExtraItems;
	[SerializeField] List<SpriteList> OrderExtraCupItemSprites;
	[SerializeField] List<SpriteRenderer> OrderExtraCupItems;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		CurrentIndex = 0;
        Orders = new();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayOrder()
    {
        if (!Orders.Any())
        {
			DisplayEmpty();
            return;
		}

        if (CurrentIndex >= Orders.Count) CurrentIndex -= 1;
        else if (CurrentIndex < 0) CurrentIndex = 0;

        CustomerOrder currentOrder = Orders[CurrentIndex];

		TableId.sprite = TableIdSprites[currentOrder.OrderId / 100];

        OrderCup.sprite = OrderCupSprites[currentOrder.CupSize];

        for (int i = 0; i < OrderCupLayers.Count; ++i)
            OrderCupLayers[i].sprite = null;
        
		for (int i = 0; i < currentOrder.CupSize + 1; ++i)
        {
            if (currentOrder.Layers[i] == (CustomerOrder.CoffeeLayers)3) break;
			OrderCupLayers[i].sprite = OrderCupLayerSprites[currentOrder.CupSize].sprites[i].sprites[(int)currentOrder.Layers[i]];
		}

        for (int i = 0; i < OrderExtraItems.Count; ++i)
        {
			OrderExtraItems[i].sprite = null;
			OrderExtraCupItems[i].sprite = null;
		}

		for (int i = 0; i < OrderExtraItems.Count; ++i)
        {
            if (i < currentOrder.ExtraItems.Count)
            {
				OrderExtraItems[i].sprite = OrderExtraItemSprites[(int)currentOrder.ExtraItems[i]];
				OrderExtraCupItems[i].sprite = OrderExtraCupItemSprites[currentOrder.CupSize].sprites[(int)currentOrder.ExtraItems[i]];
			}
		}
	}
    void DisplayEmpty()
    {
		TableId.sprite = null;

		OrderCup.sprite = null;

		for (int i = 0; i < OrderCupLayers.Count; ++i)
			OrderCupLayers[i].sprite = null;

		for (int i = 0; i < OrderExtraItems.Count; ++i)
		{
			OrderExtraItems[i].sprite = null;
			OrderExtraCupItems[i].sprite = null;
		}
	}
}
