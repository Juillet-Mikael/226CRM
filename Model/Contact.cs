﻿using System;

namespace CrmBusiness
{
    /// <summary>
    /// This class is designed to manage a Contact
    /// </summary>
    public class Contact
    {
        #region private attributes
        private string _name;
        private string _firstname;
        private DateTime _dateOfBirth;
        private string _nationality;
        private string _email;
        private string _pathToImg;
        private DateTime _creationDate;
        private DateTime _lastUpdate;
        #endregion private attributes

        /// <summary>
        /// This constructor allow to create a new contact object
        /// </summary>
        /// <param name="name">contact's name</param>
        /// <param name="firstname">contact's firtname</param>
        /// <param name="dateOfBirth">contact's date of birth</param>
        /// <param name="nationality">contact's nationality</param>
        /// <param name="email">contact's email</param>
        /// <param name="pathToImg">path to the contact's profil image</param>
        #region public methods
        public Contact(string name, string firstname, DateTime dateOfBirth, string nationality, string email, string pathToImg = "/")
        {
            if (!IsValidEmail(email))
            {
                throw new InvalideEmailValueException();
            }
            else
            {
                _email = email;
            }
            _name = name;
            _firstname = firstname;
            _dateOfBirth = dateOfBirth;
            _nationality = nationality;
            _pathToImg = pathToImg;
            _creationDate = DateTime.Now;
            _lastUpdate = _creationDate;
        }

        /// <summary>
        /// This property gets the contact's name
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// This property gets the contact's firstname
        /// </summary>
        public string Firstname
        {
            get
            {
                return _firstname;
            }
        }

        /// <summary>
        /// This property gets the contact's date of birth
        /// </summary>
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
        }

        /// <summary>
        /// This property gets the contact's nationality
        /// </summary>
        public string Nationality
        {
            get
            {
                return _nationality;
            }
        }

        /// <summary>
        /// This property gets the contact's email
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
        }

        /// <summary>
        /// This property gets the path to the contact' profil image and
        /// allow to update the value.
        /// It's impact the lastupdate value also.
        /// </summary>
        public string PathToImg
        {
            get
            {
                return _pathToImg;
            }
            set
            {
                _pathToImg = value;
                UpdateLastUpdate();
            }
        }

        /// <summary>
        /// This property gets the contact's creation date
        /// </summary>
        public DateTime CreationDate
        {
            get
            {
                return _creationDate;
            }
        }

        /// <summary>
        /// This property gets the contact's lastupdate
        /// This date is update as soon as a property is updated.
        /// </summary>
        public DateTime LastUpdate
        {
            get
            {
                return _lastUpdate;
            }
        }
        #endregion public methods

        #region private methods
        private void UpdateLastUpdate()
        {
            _lastUpdate = DateTime.Now;
        }
        private bool IsValidEmail(string email)
        {
            if (email.Contains("@"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion private methods
    }
}

public class ContactException : Exception { }

public class InvalideEmailValueException : ContactException { }
