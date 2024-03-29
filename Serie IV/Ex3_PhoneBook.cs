﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Serie_IV
{
    public class PhoneBook
    {

        private Dictionary<string, string> _contacts = new Dictionary<string, string>();

        public PhoneBook()
        {
            _contacts = new Dictionary<string, string>();
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {

            int i;
            if (phoneNumber.Length == 10
                && phoneNumber[0] == '0'
                && phoneNumber[1] != '0'
                && int.TryParse(phoneNumber, out i))
            {
                return true;
            }
            return false;
        }

        public bool ContainsPhoneContact(string phoneNumber)
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts.ContainsKey(phoneNumber))
                {
                    return true;
                }
            }
            return false;
        }

        public void PhoneContact(string phoneNumber)
        {
            if (_contacts.ContainsKey(phoneNumber))
            {
                Console.WriteLine($"{phoneNumber} : {_contacts[phoneNumber]}");
            }
            throw new ArgumentException("Le numéro n'est pas valide"); 

        }

        public bool AddPhoneNumber(string phoneNumber, string name)
        {
            if (IsValidPhoneNumber(phoneNumber) && !ContainsPhoneContact(phoneNumber))
            {
                _contacts.Add(phoneNumber, name);
                return true;
            }
            return false;
        }

        public bool DeletePhoneNumber(string phoneNumber)
        {
            if (ContainsPhoneContact(phoneNumber))
            {
                _contacts.Remove(phoneNumber);
                return true;
            }
            
            return false;
        }

        public void DisplayPhoneBook()
        {
            foreach (KeyValuePair <string, string> item in _contacts){
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
            
        }
    }
}
