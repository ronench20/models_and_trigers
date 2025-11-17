using TMPro;
using UnityEngine;
using UnityEngine.UI;

/**
 * This component should be attached to a TextMeshPro object.
 * It allows to feed an integer number to the text field.
 */
[RequireComponent(typeof(TextMeshPro))]
public class NumberField : MonoBehaviour {
    private int number;
    private TextMeshPro textField;
    [SerializeField] Text ststicScoreText;
    
    private void Awake() {
        textField = GetComponent<TextMeshPro>();
    }

    public int GetNumber() {
        return this.number;
    }

    public void SetNumber(int newNumber) {
        this.number = newNumber;
        GetComponent<TextMeshPro>().text = newNumber.ToString();
        textField.text = newNumber.ToString();
        GAME_STATUS.playerScore = newNumber;
        ststicScoreText.text = newNumber.ToString();
    }

    public void AddNumber(int toAdd) {
        SetNumber(this.number + toAdd);
    }
}
