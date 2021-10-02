using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    #region Variables

    // Public Variables
    [HideInInspector] public static string enteredText;

    // Private Variables
    private Text txtLetter;
    private char character;

    #endregion Variables

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
        enteredText += character;
        TextActions.OnTextChanged?.Invoke();
    }

    public void SetCharacter()
    {
        txtLetter = transform.Find("txtLetter").GetComponent<Text>();
        character = char.Parse(txtLetter.text);
    }
}