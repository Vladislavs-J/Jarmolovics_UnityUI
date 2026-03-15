using UnityEngine;
using TMPro;
using System;

public class AgeCalculator : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField yearInput;
    public TMP_Text resultText;

    public void CalculateAge()
    {
        string name = nameInput.text;
        if (int.TryParse(yearInput.text, out int birthYear))
        {
            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;
            resultText.text = $"Supervaronis {name} ir {age} gadus vecs!";
        }
        else
        {
            resultText.text = "Lūdzu ievadiet derīgu dzimšanas gadu!";
        }
    }
}