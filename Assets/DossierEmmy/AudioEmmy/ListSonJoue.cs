using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSonJoue : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ListSonMonstre());
    }

 IEnumerator ListSonMonstre()
{
   while (true)
        {
            // Jouer le premier son et attendre qu'il se termine
            audioSource1.Play();
            yield return new WaitForSeconds(audioSource1.clip.length);

            // Jouer le deuxième son et attendre qu'il se termine
            audioSource2.Play();
            yield return new WaitForSeconds(audioSource2.clip.length);

            // Jouer le troisième son et attendre qu'il se termine
            audioSource3.Play();
            yield return new WaitForSeconds(audioSource3.clip.length);
        }
}
}
