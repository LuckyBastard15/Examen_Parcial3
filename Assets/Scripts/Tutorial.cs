using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject _tutorialScreen = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _tutorialScreen.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _tutorialScreen.SetActive(false);
    }
}
