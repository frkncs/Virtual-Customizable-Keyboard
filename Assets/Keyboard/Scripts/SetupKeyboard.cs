using UnityEngine;
using UnityEngine.UI;

public class SetupKeyboard : MonoBehaviour
{
    #region Variables

    // Public Variables

    // Private Variables
    [SerializeField] private GameObject letter;
    [SerializeField] private GameObject numberRow, firstRow, secondRow, thirdRow;

    #endregion Variables

    private void Start()
    {
        InitializeVariables();
    }

    public void OnClickEnter()
    {
        TextActions.OnEnterClicked?.Invoke();
    }
    public void OnClickSpace()
    {
        Letter.enteredText += " ";
        TextActions.OnTextChanged?.Invoke();
    }
    public void OnClickBackspace()
    {
        Letter.enteredText = Letter.enteredText.Substring(0, Letter.enteredText.Length - 1);
        TextActions.OnTextChanged?.Invoke();
    }

    private void InitializeVariables()
    {
        char[] firstRowCharacters = { 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P' };
        char[] secondRowCharacters = { 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L'};
        char[] thirdRowCharacters = { 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };

        for (int i = 0; i < 9; i++)
        {
            SetupKeyb(0, char.Parse((i + 1).ToString()));
        }
        
        for (int i = 0; i < firstRowCharacters.Length; i++)
        {
            SetupKeyb(1, firstRowCharacters[i]);
        }

        for (int i = 0; i < secondRowCharacters.Length; i++)
        {
            SetupKeyb(2, secondRowCharacters[i]);
        }
        
        for (int i = 0; i < thirdRowCharacters.Length; i++)
        {
            SetupKeyb(3, thirdRowCharacters[i]);
        }
    }

    private void SetupKeyb(int rowCount, char character)
    {
        GameObject createdLetter = null;

        switch (rowCount)
        {
            case 0:
                createdLetter = Instantiate(letter, numberRow.transform);
                break;
            case 1:
                createdLetter = Instantiate(letter, firstRow.transform);
                break;
            case 2:
                createdLetter = Instantiate(letter, secondRow.transform);
                break;
            case 3:
                createdLetter = Instantiate(letter, thirdRow.transform);
                break;
        }

        if (createdLetter != null)
        {
            createdLetter.transform.Find("txtLetter").GetComponent<Text>().text = character.ToString();
            createdLetter.GetComponent<Letter>().SetCharacter();
        }
    }
}