using TMPro;
using UnityEngine;
public class PowerManager :MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _powerText;

    private int _totalPower = 0;

    private void Start()
    {
        _powerText.text = $"Power: {_totalPower}";
    }

    public void PlusPower(int power)
    {
        _totalPower += power;
        _powerText.text = $"Power: {_totalPower}";
    }
}