using UnityEngine;
using System.Collections.Generic;

public struct DayData
{
    public int CupSizeCap;
	public int CustomerCount;
	public List<CustomerOrder.CoffeeLayers> AllowedLayers;
	public List<CustomerOrder.Extras> AllowedExtras;

    public DayData(int cap, int guys, List<CustomerOrder.CoffeeLayers> layers, List<CustomerOrder.Extras> extras)
    {
        CupSizeCap = cap;
		CustomerCount = guys;
        AllowedLayers = layers;
        AllowedExtras = extras;
    }
} 

[CreateAssetMenu(fileName = "GameData")]
public class GameData : ScriptableObject
{
    public readonly DayData[] DAY_DATA =
    {
        new DayData(2, 5,
            new List<CustomerOrder.CoffeeLayers>
            { 
                CustomerOrder.CoffeeLayers.COFFEE 
            }, 
            new List<CustomerOrder.Extras>
            { 
            }),
		new DayData(2, 6,
			new List<CustomerOrder.CoffeeLayers>
			{
				CustomerOrder.CoffeeLayers.COFFEE,
				CustomerOrder.CoffeeLayers.MILK
			},
			new List<CustomerOrder.Extras>
			{
			}),
		new DayData(2, 7,
			new List<CustomerOrder.CoffeeLayers>
			{
				CustomerOrder.CoffeeLayers.COFFEE,
				CustomerOrder.CoffeeLayers.MILK
			},
			new List<CustomerOrder.Extras>
			{
				CustomerOrder.Extras.SUGAR,
				CustomerOrder.Extras.CINNAMON
			}),
		new DayData(2, 8,
			new List<CustomerOrder.CoffeeLayers>
			{
				CustomerOrder.CoffeeLayers.COFFEE,
				CustomerOrder.CoffeeLayers.MILK,
				CustomerOrder.CoffeeLayers.W_MILK
			},
			new List<CustomerOrder.Extras>
			{
				CustomerOrder.Extras.SUGAR,
				CustomerOrder.Extras.CINNAMON
			}),
		new DayData(2, 10,
			new List<CustomerOrder.CoffeeLayers>
			{
				CustomerOrder.CoffeeLayers.COFFEE,
				CustomerOrder.CoffeeLayers.MILK,
				CustomerOrder.CoffeeLayers.W_MILK
			},
			new List<CustomerOrder.Extras>
			{
				CustomerOrder.Extras.SUGAR,
				CustomerOrder.Extras.CINNAMON,
				CustomerOrder.Extras.CREAM,
				CustomerOrder.Extras.STRAW
			})
	};
}
