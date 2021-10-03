using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;


public class JSonReadWriteBillingSystem : MonoBehaviour
{
    [SerializeField] InputField idInputField;
    [SerializeField] InputField firstNameInputField;
    [SerializeField] InputField lastNameInputField;
    [SerializeField] InputField streetInputField;
    [SerializeField] InputField cityInputField;
    [SerializeField] InputField stateInputField;
    [SerializeField] InputField zipCodeInputField;
    [SerializeField] InputField cardNumberInputField;
    [SerializeField] InputField monthExpireInputField;
    [SerializeField] InputField yearExpireInputField;
    [SerializeField] InputField securityNumberInputField;
    [SerializeField] string filename = "UsersInformation.json";
    public Text errorMessage;
    public Text savedSuccessfully;


    private List<UserData> saveListUser = new List<UserData>();


    private void Start()
    {
        errorMessage.enabled = false;
        savedSuccessfully.enabled = false;
    }

    public void AddInformationtoDatabase()
    {
        if (!checkValidInformation())
        {
            errorMessage.enabled = true;
            return;
        }
        errorMessage.enabled = false;
        UserData newUser = new UserData();
        newUser.studentID = idInputField.text;
        newUser.firstName = firstNameInputField.text;
        newUser.lastName = lastNameInputField.text;
        newUser.streetName = streetInputField.text;
        newUser.cityName = cityInputField.text;
        newUser.stateName = stateInputField.text;
        newUser.zipCode = int.Parse(zipCodeInputField.text);
        newUser.cardNumber = cardNumberInputField.text;
        newUser.monthExpire = int.Parse(monthExpireInputField.text);
        newUser.yearExpire = int.Parse(yearExpireInputField.text);
        newUser.securityNumber = int.Parse(securityNumberInputField.text);

        saveListUser.Add(newUser);
        idInputField.text = "";
        firstNameInputField.text = "";
        lastNameInputField.text = "";
        streetInputField.text = "";
        cityInputField.text = "";
        stateInputField.text = "";
        zipCodeInputField.text = "";
        cardNumberInputField.text = "";
        monthExpireInputField.text = "";
        yearExpireInputField.text = "";
        securityNumberInputField.text = "";

        FileHandler.SaveItemtoJSON<UserData>(newUser, filename);
        savedSuccessfully.enabled = true;

    }

    public void loadFromJSon()
    {
        UserData returnUser = FileHandler.ReadFromJSON<UserData>(filename);
        idInputField.text = returnUser.studentID;
        firstNameInputField.text = returnUser.firstName;
        lastNameInputField.text = returnUser.lastName;
        streetInputField.text = returnUser.streetName;
        cityInputField.text = returnUser.cityName;
        stateInputField.text = returnUser.stateName;
        zipCodeInputField.text = returnUser.zipCode.ToString();
        cardNumberInputField.text = returnUser.cardNumber;
        monthExpireInputField.text = returnUser.monthExpire.ToString();
        yearExpireInputField.text = returnUser.yearExpire.ToString();
        securityNumberInputField.text = returnUser.securityNumber.ToString();
        Debug.Log(idInputField.text);


    }

    private bool checkValidInformation()
    {
        string inputID = idInputField.text;
        string zipcode = zipCodeInputField.text;
        if (!checkIDNumber(inputID) || !checkZipCode(zipcode) || !checkEmptyField())
        {
            return false;
        }

        return true;
    }

    private bool checkIDNumber(string idNumber)
    {
        if (idNumber.Length != 10)
        {
            Debug.Log("Nonvalid ID Number");
            return false;
        }

        return true;
    }

    private bool checkZipCode(string zipCode)
    {
        var _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";

        if (!Regex.Match(zipCode, _usZipRegEx).Success)
        {
            return false;
        }
        return true;
    }

    private bool checkEmptyField()
    {
        if ((String.Compare("", idInputField.text) == 0) || (String.Compare("", firstNameInputField.text) == 0) || (String.Compare("", lastNameInputField.text) == 0)
            || (String.Compare("", streetInputField.text) == 0) || (String.Compare("", cityInputField.text) == 0) || (String.Compare("", stateInputField.text) == 0)
            || (String.Compare("", zipCodeInputField.text) == 0) || (String.Compare("", cardNumberInputField.text) == 0) || (String.Compare("", cardNumberInputField.text) == 0)
            || (String.Compare("", monthExpireInputField.text) == 0) || (String.Compare("", yearExpireInputField.text) == 0) || (String.Compare("", securityNumberInputField.text) == 0))
        {
            return false;
        }
        return true;
    }

    

    


}
