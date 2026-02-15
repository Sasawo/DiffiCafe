using Unity.VectorGraphics;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class DayScreen : MonoBehaviour
{
    [SerializeField] int WaitTime;
    [SerializeField] string GoToScene;
    [SerializeField] int IncrementDays;
    float timer;
    void Start()
    {
        timer = 0;
        try { GameObject.Find("Daytext").GetComponent<TMP_Text>().text += "\n" + (PlayerPrefs.GetInt("Day") + 1); }
        catch { }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= WaitTime)
        {
            PlayerPrefs.SetInt("Day", PlayerPrefs.GetInt("Day") + 1);

            if (PlayerPrefs.GetInt("Day") >= 5)
				SceneManager.LoadScene("VictoryScene");

            SceneManager.LoadScene(GoToScene);
        }
    }
}
