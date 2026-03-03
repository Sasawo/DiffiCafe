using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Endless : MonoBehaviour
{
    [SerializeField] int StartTimerSeconds;
	[SerializeField] int CustomerAddSeconds;
    float timer;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		if (PlayerPrefs.GetInt("Infinite") == 0)
        {
            GameObject.Find("TimerText").SetActive(false);
			GameObject.Find("Timer").SetActive(false);
			GetComponent<Endless>().enabled = false;

            return;
		}

		timer = StartTimerSeconds;
		UpdateTimer();
	}

    void LateUpdate()
    {
        timer -= Time.deltaTime;
        UpdateTimer();
    }

    public bool CheckTimer() => timer < 0;

    public void CustomerAdd()
    {
        timer += CustomerAddSeconds;
	}

    private void UpdateTimer()
    {
        if (timer < 0) return;

        int t = Mathf.FloorToInt(timer);
        GameObject.Find("TimerText").GetComponent<TMP_Text>().text = $"{t / 60:D2}:{t % 60:D2}";
    }
}
