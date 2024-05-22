using UnityEngine;

public enum enColorchannels
{
    all = 0,
    red = 1,
    blue = 2,
    green = 3
}

public enum enWaveFunctions
{
    sinus = 0,
    triangle = 1,
    square = 2,
    sawtooth = 3,
    inverted_saw = 4,
    noise = 5
}

public class LightColorAnimation : MonoBehaviour
{
    public Light targetLight; // Add this line to allow light assignment via the inspector

    public enColorchannels colorChannel = enColorchannels.all;
    public enWaveFunctions waveFunction = enWaveFunctions.sinus;
    public float offset = 0.0f; // constant offset
    public float amplitude = 1.0f; // amplitude of the wave
    public float phase = 0.0f; // start point inside on wave cycle
    public float frequency = 0.5f; // cycle frequency per second
    public bool affectsIntensity = true;

    // Keep a copy of the original values
    private Color originalColor;
    private float originalIntensity;

    // Use this for initialization
    void Start()
    {
        if (targetLight == null)
        {
            targetLight = GetComponent<Light>();
        }
        
        originalColor = targetLight.color;
        originalIntensity = targetLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetLight == null)
        {
            Debug.LogWarning("Target Light is not assigned!");
            return;
        }

        if (affectsIntensity)
        {
            targetLight.intensity = originalIntensity * EvalWave();
        }

        Color o = originalColor;
        Color c = targetLight.color;

        if (colorChannel == enColorchannels.all)
        {
            targetLight.color = originalColor * EvalWave();
        }
        else if (colorChannel == enColorchannels.red)
        {
            targetLight.color = new Color(o.r * EvalWave(), c.g, c.b, c.a);
        }
        else if (colorChannel == enColorchannels.green)
        {
            targetLight.color = new Color(c.r, o.g * EvalWave(), c.b, c.a);
        }
        else // blue
        {
            targetLight.color = new Color(c.r, c.g, o.b * EvalWave(), c.a);
        }
    }

    private float EvalWave()
    {
        float x = (Time.time + phase) * frequency;
        float y;
        x = x - Mathf.Floor(x); // normalized value (0..1)
        switch (waveFunction)
        {
            case enWaveFunctions.sinus:
                y = Mathf.Sin(x * 2f * Mathf.PI);
                break;
            case enWaveFunctions.triangle:
                y = x < 0.5f ? 4.0f * x - 1.0f : -4.0f * x + 3.0f;
                break;
            case enWaveFunctions.square:
                y = x < 0.5f ? 1.0f : -1.0f;
                break;
            case enWaveFunctions.sawtooth:
                y = x;
                break;
            case enWaveFunctions.inverted_saw:
                y = 1.0f - x;
                break;
            case enWaveFunctions.noise:
                y = 1f - (Random.value * 2f);
                break;
            default:
                y = 1.0f;
                break;
        }
        return (y * amplitude) + offset;
    }
}
