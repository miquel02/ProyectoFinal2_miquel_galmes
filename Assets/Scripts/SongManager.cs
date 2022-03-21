using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    //AQUEST SCRIPT S'ENCARREGA DE CONTROLAR L'AUDIO MANAGER

    [SerializeField] private AudioClip[] audios;
    private AudioSource controladorAudio;

    private void Awake()
    {
        controladorAudio = GetComponent<AudioSource>();
    }

    public void SelecionAudio(int indice, float volumen)
    {
        controladorAudio.PlayOneShot(audios[indice], volumen);
    }
}