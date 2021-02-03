using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
   
    PlayerMovement player;

    private void Start()
    {
        player = PlayerMovement.Instance;
    } 

    void Update()
    {
        slider.value = player.GetForcePercentage();
    }
}
