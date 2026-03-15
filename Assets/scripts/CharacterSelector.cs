using UnityEngine;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    [Header("Characters")]
    public GameObject wizard;
    public GameObject wizard_ice;

    [Header("UI")]
    public TMP_Dropdown dropdown;
    public TMP_Text description;

    void Start()
    {
        dropdown.onValueChanged.AddListener(ChangeCharacter);
        ChangeCharacter(dropdown.value);
    }

    void ChangeCharacter(int index)
    {
        if (index == 0)
        {
            wizard.SetActive(true);
            wizard_ice.SetActive(false);

            description.text =
                "Wizard is a master of arcane magic.\n" +
                "He can cast powerful spells and control mystical forces.";
        }
        else if (index == 1)
        {
            wizard.SetActive(false);
            wizard_ice.SetActive(true);

            description.text =
                "Wizard Ice is a powerful frost mage.\n" +
                "He controls ice and snow and can freeze enemies.";
        }
    }
}