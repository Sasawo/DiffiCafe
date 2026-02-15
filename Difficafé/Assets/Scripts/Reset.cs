using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] Sprite resetTo;
    [SerializeField] string AllowedTag;
    bool contained;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        contained = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
