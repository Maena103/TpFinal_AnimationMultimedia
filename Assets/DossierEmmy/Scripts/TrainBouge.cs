using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainBouge : MonoBehaviour
{
    // La position cible sur l'axe Z
    public float targetZ = 0.372f;
    // Vitesse de la translation
    public float speed = 1.0f;

    // Variable pour suivre si la translation est en cours
    private bool isTranslating = true;

    void Update()
    {
        if (isTranslating)
        {
            // Calculer la nouvelle position
            Vector3 newPosition = transform.position;
            newPosition.z = Mathf.MoveTowards(transform.position.z, targetZ, speed * Time.deltaTime);

            // Appliquer la nouvelle position
            transform.position = newPosition;

            // Vérifier si la translation est terminée
            if (Mathf.Approximately(transform.position.z, targetZ))
            {
                isTranslating = false;
            }
        }
    }
}
