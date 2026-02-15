using UnityEngine;
using static CustomerOrder;

public class OrderBuilder : MonoBehaviour
{
    [SerializeField] int CupSize;
    public Order order = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        order.CupSize = CupSize;
        order.Layers = new CoffeeLayers[CupSize + 1];
        order.ExtraItems = new();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
