using UnityEngine;
using UnityEngine.UI;

public class ToggleGroupManager : MonoBehaviour
{
    public Toggle toggleHats;
    public Toggle toggleStaff;
    public GameObject hatsPanel;
    public GameObject staffPanel;

    private void Start()
    {
        toggleHats.onValueChanged.AddListener(OnHatsToggled);
        toggleStaff.onValueChanged.AddListener(OnStaffToggled);

        hatsPanel.SetActive(false);
        staffPanel.SetActive(false);
    }

    private void OnHatsToggled(bool isOn)
    {
        if (isOn)
        {
            hatsPanel.SetActive(true);
            staffPanel.SetActive(false);
            toggleStaff.isOn = false; 
        }
        else
        {
            hatsPanel.SetActive(false);
        }
    }

    private void OnStaffToggled(bool isOn)
    {
        if (isOn)
        {
            staffPanel.SetActive(true);
            hatsPanel.SetActive(false);
            toggleHats.isOn = false;
        }
        else
        {
            staffPanel.SetActive(false);
        }
    }
}