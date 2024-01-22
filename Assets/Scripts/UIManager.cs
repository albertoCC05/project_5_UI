using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //modificar texto

    [SerializeField] private TextMeshProUGUI pointsText;

    private void Start()
    {
        pointsText.text = "Points = 0";
    }
}
