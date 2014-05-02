using UnityEngine;
using System.Collections;
using Ebbe.Cereal;

public class CameraShake : MonoBehaviour 
{
    public float shakeIntensity = 0.3f;
    public float shakeDecay = 0.04f; 

    private bool shaking = false;
    private Vector3 origPosition;
    private float currentShakeIntensity = 0.3f;

    private Cereal kelloggs = new Cereal();
    public float fadeOutTime = 1f;

    private void Start()
    {
        DoShake();
    }

    private void Update()
    {
        kelloggs.Update();

        if (currentShakeIntensity > 0)
        {
            transform.position = origPosition + Random.insideUnitSphere * shakeIntensity * Time.deltaTime;
            //currentShakeIntensity -= shakeDecay * Time.deltaTime;
        }
        else if (shaking)
        {
            shaking = false;
        }
    }

    public void DoShake()
    {
        origPosition = transform.position;
        currentShakeIntensity = shakeIntensity;
        shaking = true;

        kelloggs.Clear();
        kelloggs.Add(new CerealLerpEvent<float>(currentShakeIntensity, 0f, fadeOutTime, Mathf.Lerp)
        {
            OnChange = (pChange) => currentShakeIntensity = pChange
        });
    }
}
