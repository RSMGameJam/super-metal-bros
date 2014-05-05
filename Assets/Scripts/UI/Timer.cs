using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    public float playTime;
    private float elapsedTime;

    public float TimeLeft { get { return elapsedTime; } }

    private void Start()
    {
        elapsedTime = playTime;

    }

    private void Update()
    {
        elapsedTime -= Time.deltaTime;

        if (elapsedTime <= 0)
        {
            elapsedTime = 0;
            //end play session
        }
        string time = GetTimeLeft();
    }

    public void ResetTimer()
    {
        elapsedTime = playTime;
    }

    public string GetTimeLeft()
    {
        return string.Format("{0:00}:{1:00}", (int)(Mathf.Floor(elapsedTime / 60f)), (int)(elapsedTime  % 60f));
    }
}
