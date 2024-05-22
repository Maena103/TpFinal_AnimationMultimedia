using UnityEngine;

public enum enColorMatChannels
{
    all = 0,
    red = 1,
    blue = 2,
    green = 3
}

public enum enWaveFunctionsMat
{
    sinus = 0,
    triangle = 1,
    square = 2,
    sawtooth = 3,
    inverted_saw = 4,
    noise = 5
}

public class MaterialColorAnimation : MonoBehaviour
{
    public Material materialTarget;
    public enColorMatChannels colorChannel = enColorMatChannels.all;
    public enWaveFunctionsMat waveFunction = enWaveFunctionsMat.sinus;
    public float offset = 0.0f; // constant offset
    public float amplitude = 1.0f; // amplitude of the wave
    public float phase = 0.0f; // start point inside on wave cycle
    public float frequency = 0.5f; // cycle frequency per second
    public float noiseFrequency = 0.5f; // frequency of the noise, lower value to slow down
    public bool affectsEmission = true;

    // Keep a copy of the original values
    
    private Color originalColor;
    private Color originalEmissionColor;

    // Use this for initialization
    void Start()
    {
       

        if (materialTarget == null)
        {
             materialTarget = GetComponent<Renderer>().material;
        }

        originalColor = materialTarget.color;
        originalEmissionColor = materialTarget.GetColor("_EmissionColor");
    }

    // Update is called once per frame
    void Update()
    {
        if (materialTarget == null)
        {
            Debug.LogWarning("Target Material is not assigned!");
            return;
        }

        Color o = originalColor;
        Color c = materialTarget.color;

        if (colorChannel == enColorMatChannels.all)
        {
            materialTarget.color = originalColor * EvalWave();
        }
        else if (colorChannel == enColorMatChannels.red)
        {
            materialTarget.color = new Color(o.r * EvalWave(), c.g, c.b, c.a);
        }
        else if (colorChannel == enColorMatChannels.green)
        {
            materialTarget.color = new Color(c.r, o.g * EvalWave(), c.b, c.a);
        }
        else // blue
        {
            materialTarget.color = new Color(c.r, c.g, o.b * EvalWave(), c.a);
        }

        if (affectsEmission)
        {
            Color e = originalEmissionColor;
            Color ec = materialTarget.GetColor("_EmissionColor");

            if (colorChannel == enColorMatChannels.all)
            {
                materialTarget.SetColor("_EmissionColor", originalEmissionColor * EvalWave());
            }
            else if (colorChannel == enColorMatChannels.red)
            {
                materialTarget.SetColor("_EmissionColor", new Color(e.r * EvalWave(), ec.g, ec.b, ec.a));
            }
            else if (colorChannel == enColorMatChannels.green)
            {
                materialTarget.SetColor("_EmissionColor", new Color(ec.r, e.g * EvalWave(), ec.b, ec.a));
            }
            else // blue
            {
                materialTarget.SetColor("_EmissionColor", new Color(ec.r, ec.g, e.b * EvalWave(), ec.a));
            }
        }
    }

    private float EvalWave()
    {
        float x = (Time.time + phase) * frequency;
        float y;
        x = x - Mathf.Floor(x); // normalized value (0..1)
        switch (waveFunction)
        {
            case enWaveFunctionsMat.sinus:
                y = Mathf.Sin(x * 2f * Mathf.PI);
                break;
            case enWaveFunctionsMat.triangle:
                y = x < 0.5f ? 4.0f * x - 1.0f : -4.0f * x + 3.0f;
                break;
            case enWaveFunctionsMat.square:
                y = x < 0.5f ? 1.0f : -1.0f;
                break;
            case enWaveFunctionsMat.sawtooth:
                y = x;
                break;
            case enWaveFunctionsMat.inverted_saw:
                y = 1.0f - x;
                break;
            case enWaveFunctionsMat.noise:
                y = EvalNoise();
                break;
            default:
                y = 1.0f;
                break;
        }
        return (y * amplitude) + offset;
    }

   private float EvalNoise()
{
    float x = (Time.time + phase) * noiseFrequency;
    float y = Mathf.PerlinNoise(x, 0f);
    return y * 2f - 1f; // Mise à l'échelle pour la plage [-1, 1]
}

}