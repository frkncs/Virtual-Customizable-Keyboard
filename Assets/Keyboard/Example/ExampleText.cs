using UnityEngine;
using UnityEngine.UI;

public class ExampleText : MonoBehaviour
{
    #region Variables

    // Public Variables

    // Private Variables
    private Text exampleText;

    #endregion Variables

    private void OnEnable()
    {
        exampleText = GetComponent<Text>();

        TextActions.OnTextChanged += TextChanged;
        TextActions.OnEnterClicked += EnterClicked;
    }

    private void OnDisable()
    {
        TextActions.OnTextChanged -= TextChanged;
        TextActions.OnEnterClicked -= EnterClicked;
    }

    private void TextChanged()
    {
        //Every time the text value changes,
        //I get the text information entered by the user by saying Letter.enteredText and display it in ExampleText

        exampleText.text = Letter.enteredText;
    }

    private void EnterClicked()
    {
        // this is what happend if user clicked enter
        Debug.Log("Enter Clicked!");
    }
}