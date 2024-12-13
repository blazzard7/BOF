using UnityEngine;
using UnityEngine.UI;

public class BahilyText : MonoBehaviour
{
    Text BahilyTexts;
    public static int Bahila;
    void Start()
    {
        BahilyTexts = GetComponent<Text>();
        Bahila = PlayerPrefs.GetInt("Bahily", Bahila);
    }
   
    void Update()
    {
        BahilyTexts.text = Bahila.ToString();
    }
}