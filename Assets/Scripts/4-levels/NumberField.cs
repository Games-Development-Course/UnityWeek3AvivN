using TMPro;
using UnityEngine;

public class NumberField : MonoBehaviour
{
    private int number;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        if (text == null)
        {
            Debug.LogError("NumberField ERROR: No TextMeshProUGUI found on this object!");
        }
    }

    public int GetNumber()
    {
        return this.number;
    }

    public void SetNumber(int newNumber)
    {
        this.number = newNumber;
        text.text = newNumber.ToString();
    }

    public void AddNumber(int toAdd)
    {
        SetNumber(this.number + toAdd);
    }
}
