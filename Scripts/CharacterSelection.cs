using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class CharacterSelection : MonoBehaviour
{
	private int totalScore, existingCharacter;
	[SerializeField]
	private TextMeshProUGUI scoreText;
	public Button changeCharacterButtonOne, changeCharacterButtonTwo, changeCharacterButtonThree, changeCharacterButtonFour, changeCharacterButtonFive;
	public Text buttonOneText, buttonTwoText, buttonThreeText, buttonFourText, buttonFiveText;

	void Start()
	{
		existingCharacter = PlayerPrefs.GetInt("CharacterSprite", 0);

		buttonOneText.text = "10000";
		buttonTwoText.text = "20000";
		buttonThreeText.text = "30000";
		buttonFourText.text = "40000";
		buttonFiveText.text = "25000";

		CheckTheCurrentCharacter(existingCharacter);

		totalScore = PlayerPrefs.GetInt("TotalScore", 0);

		Button btn1 = changeCharacterButtonOne.GetComponent<Button>();
		Button btn2 = changeCharacterButtonTwo.GetComponent<Button>();
		Button btn3 = changeCharacterButtonThree.GetComponent<Button>();
		Button btn4 = changeCharacterButtonFour.GetComponent<Button>();
		Button btn5 = changeCharacterButtonFive.GetComponent<Button>();

		btn1.onClick.AddListener(Task1OnClick);
		btn2.onClick.AddListener(Task2OnClick);
		btn3.onClick.AddListener(Task3OnClick);
		btn4.onClick.AddListener(Task4OnClick);
		btn5.onClick.AddListener(Task5OnClick);
	}

	void Task1OnClick()
	{
		existingCharacter = PlayerPrefs.GetInt("CharacterSprite", 0);
		if (totalScore >= 10000 && existingCharacter != 0)
		{
			totalScore = totalScore - 10000;
			PlayerPrefs.SetInt("TotalScore", totalScore);
			PlayerPrefs.SetInt("CharacterSprite", 0);
			scoreText.text = totalScore + " POINTS";
			buttonOneText.text = "EQUIPPED";
			buttonTwoText.text = "20000";
			buttonThreeText.text = "30000";
			buttonFourText.text = "40000";
			buttonFiveText.text = "25000";
		}
	}

	void Task2OnClick()
	{
		existingCharacter = PlayerPrefs.GetInt("CharacterSprite", 0);

		if (totalScore >= 20000 && existingCharacter != 1)
		{
			totalScore = totalScore - 20000;
			PlayerPrefs.SetInt("TotalScore", totalScore);
			PlayerPrefs.SetInt("CharacterSprite", 1);
			scoreText.text = totalScore + " POINTS";
			buttonOneText.text = "10000";
			buttonTwoText.text = "EQUIPPED";
			buttonThreeText.text = "30000";
			buttonFourText.text = "40000";
			buttonFiveText.text = "25000";
		}
	}

	void Task3OnClick()
	{
		existingCharacter = PlayerPrefs.GetInt("CharacterSprite", 0);

		if (totalScore >= 30000 && existingCharacter != 2)
		{
			totalScore = totalScore - 30000;
			PlayerPrefs.SetInt("TotalScore", totalScore);
			PlayerPrefs.SetInt("CharacterSprite", 2);
			scoreText.text = totalScore + " POINTS";
			buttonOneText.text = "10000";
			buttonTwoText.text = "20000";
			buttonThreeText.text = "EQUIPPED";
			buttonFourText.text = "40000";
			buttonFiveText.text = "25000";
		}
	}

	void Task4OnClick()
	{
		existingCharacter = PlayerPrefs.GetInt("CharacterSprite", 0);

		if (totalScore >= 40000 && existingCharacter != 3)
		{
			totalScore = totalScore - 40000;
			PlayerPrefs.SetInt("TotalScore", totalScore);
			PlayerPrefs.SetInt("CharacterSprite", 3);
			scoreText.text = totalScore + " POINTS";
			buttonOneText.text = "10000";
			buttonTwoText.text = "20000";
			buttonThreeText.text = "30000";
			buttonFourText.text = "EQUIPPED";
			buttonFiveText.text = "25000";
		}
	}

	void Task5OnClick()
	{
		existingCharacter = PlayerPrefs.GetInt("CharacterSprite", 0);

		if (totalScore >= 25000 && existingCharacter != 4)
		{
			totalScore = totalScore - 25000;
			PlayerPrefs.SetInt("TotalScore", totalScore);
			PlayerPrefs.SetInt("CharacterSprite", 4);
			scoreText.text = totalScore + " POINTS";
			buttonOneText.text = "10000";
			buttonTwoText.text = "20000";
			buttonThreeText.text = "30000";
			buttonFourText.text = "40000";
			buttonFiveText.text = "EQUIPPED";
		}
	}

	void CheckTheCurrentCharacter(int existingCharacter)
    {
		if(existingCharacter == 0)
        {
			buttonOneText.text = "EQUIPPED";
			buttonTwoText.text = "20000";
			buttonThreeText.text = "30000";
			buttonFourText.text = "40000";
			buttonFiveText.text = "25000";
		}
		else if (existingCharacter == 1)
        {
			buttonOneText.text = "10000";
			buttonTwoText.text = "EQUIPPED";
			buttonThreeText.text = "30000";
			buttonFourText.text = "40000";
			buttonFiveText.text = "25000";
		}
		else if (existingCharacter == 2)
		{
			buttonOneText.text = "10000";
			buttonTwoText.text = "20000";
			buttonThreeText.text = "EQUIPPED";
			buttonFourText.text = "40000";
			buttonFiveText.text = "25000";
		}
		else if (existingCharacter == 3)
		{
			buttonOneText.text = "10000";
			buttonTwoText.text = "20000";
			buttonThreeText.text = "30000";
			buttonFourText.text = "EQUIPPED";
			buttonFiveText.text = "25000";
		}
		else if (existingCharacter == 4)
		{
			buttonOneText.text = "10000";
			buttonTwoText.text = "20000";
			buttonThreeText.text = "30000";
			buttonFourText.text = "40000";
			buttonFiveText.text = "EQUIPPED";
		}
	}
}