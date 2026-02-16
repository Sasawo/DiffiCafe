using System;
using System.Collections.Generic;
using UnityEngine;
using static CustomerOrder;

public class OrderBuilder : MonoBehaviour
{
	[SerializeField] Sprite Cup;
	[SerializeField] List<SpriteList> Layers;
	[SerializeField] List<SpriteRenderer> LayerRenders;
	[SerializeField] List<Sprite> Extras;
	[SerializeField] List<SpriteRenderer> ExtrasRenders;
	[SerializeField] int CupSize;
    [NonSerialized] public Order order = new();
	[NonSerialized] public int layersCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        order.CupSize = CupSize;
        order.Layers = new CoffeeLayers[CupSize + 1];
		Array.Fill(order.Layers, (CoffeeLayers)3);
		order.ExtraItems = new();
        layersCount = 0;
    }

    public void AddLayer(int type)
    {
        if (layersCount == CupSize + 1) return;
        order.Layers[layersCount++] = (CoffeeLayers)type;
    }

    public void Render()
    {
		GetComponent<SpriteRenderer>().sprite = Cup;

		for (int i = 0; i < LayerRenders.Count; ++i)
			LayerRenders[i].sprite = null;

		for (int i = 0; i < order.CupSize + 1; ++i)
		{
			if (order.Layers[i] == (CoffeeLayers)3) break;
			LayerRenders[i].sprite = Layers[i].sprites[(int)order.Layers[i]];
		}

		for (int i = 0; i < ExtrasRenders.Count; ++i)
			ExtrasRenders[i].sprite = null;

		for (int i = 0; i < ExtrasRenders.Count; ++i)
		{
			if (i < order.ExtraItems.Count)
			{
				ExtrasRenders[i].sprite = Extras[(int)order.ExtraItems[i]];
			}
		}
	}
}
