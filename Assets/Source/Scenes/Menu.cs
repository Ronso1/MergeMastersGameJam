using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider slider;

    public void StartGame()
    {
        SceneManager.LoadScene("Jackal");
    }

    private void Start()
    {
        slider.onValueChanged.AddListener(VolumeChanged);
    }

    private void VolumeChanged(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
