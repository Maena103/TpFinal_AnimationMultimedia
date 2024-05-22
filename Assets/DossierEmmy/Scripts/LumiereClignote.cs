using UnityEngine;

public enum enColorChannels
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
    public Light targetLight; // Permet d'assigner la lumière via l'inspecteur

    public enColorChannels colorChannel = enColorChannels.all;
    public enWaveFunctions waveFunction = enWaveFunctions.sinus;
    public float offset = 0.0f; // Offset constant
    public float amplitude = 1.0f; // Amplitude de l'onde
    public float phase = 0.0f; // Point de départ à l'intérieur du cycle de l'onde
    public float frequency = 0.5f; // Fréquence du cycle par seconde
    public float noiseFrequency = 0.5f; // Fréquence du bruit, valeur inférieure pour ralentir
    public bool affectsIntensity = true;

    // Garde une copie des valeurs originales
    private Color originalColor;
    private float originalIntensity;

    // Utilisé pour l'initialisation
    void Start()
    {
        if (targetLight == null)
        {
            targetLight = GetComponent<Light>();
        }

        originalColor = targetLight.color;
        originalIntensity = targetLight.intensity;
    }

    // Appelé une fois par frame
    void Update()
    {
        if (targetLight == null)
        {
            Debug.LogWarning("La lumière cible n'est pas assignée !");
            return;
        }

        if (affectsIntensity)
        {
            targetLight.intensity = originalIntensity * EvalWave();
        }

        Color o = originalColor;
        Color c = targetLight.color;

        if (colorChannel == enColorChannels.all)
        {
            targetLight.color = originalColor * EvalWave();
        }
        else if (colorChannel == enColorChannels.red)
        {
            targetLight.color = new Color(o.r * EvalWave(), c.g, c.b, c.a);
        }
        else if (colorChannel == enColorChannels.green)
        {
            targetLight.color = new Color(c.r, o.g * EvalWave(), c.b, c.a);
        }
        else // blue
        {
            targetLight.color = new Color(c.r, c.g, o.b * EvalWave(), c.a);
        }
    }

    // Évalue la forme d'onde
    private float EvalWave()
    {
        float x = (Time.time + phase) * frequency;
        float y;
        x = x - Mathf.Floor(x); // Valeur normalisée (0..1)
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
                y = EvalNoise();
                break;
            default:
                y = 1.0f;
                break;
        }
        return (y * amplitude) + offset;
    }

    // Évalue le bruit
    private float EvalNoise()
    {
        float x = (Time.time + phase) * noiseFrequency;
        float y = Mathf.PerlinNoise(x, 0f);
        return y * 2f - 1f; // Mise à l'échelle pour la plage [-1, 1]
    }
}
