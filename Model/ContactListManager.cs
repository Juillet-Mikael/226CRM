using System;
using System.Collections.Generic;

namespace CrmBusiness
{
    /// <summary>
    /// This class is designed to be Contact list manager
    /// </summary>
    public class ContactListManager
    {
        #region private attributes
        private List<Contact> _contacts;
        private DateTime _creationDate;
        private DateTime _lastUpdate;
        #endregion private attributes

        #region public methods
        /// <summary>
        /// This constructor allows to create a new contact object
        /// </summary>
        /// <param name="contacts">A list of contacts to insert in the manager</param>
        public ContactListManager(List<Contact> contacts = null)
        {
            _contacts = contacts;
        }

        /// <summary>
        /// This property gets the list of contacts present in the manager
        /// </summary>
        public List<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
        }

        /// <summary>
        /// This method adds a list of contacts
        /// </summary>
        /// <remarks>A duplicate will be identified with is emailaddress</remarks>
        /// <param name="contacts">A list of contact</param>
        /// <param name="allowDuplicate">Flase = duplicate is not allowed (will be removed), True = duplicate is possible</param>
        public void Add(List<Contact> contactsToAdd, Boolean allowDuplicate=false)
        {
            if (_contacts == null)
            {
                _contacts = new List<Contact>();
            }
            if (allowDuplicate == true)
            {
                _contacts.AddRange(contactsToAdd);
            }
            else
            {
                foreach (Contact contactToAdd in contactsToAdd)
                {
                    if (Exist(contactToAdd))
                    {
                        _contacts.Add(contactToAdd);
                    }
                }
            }
        }

        /// <summary>
        /// This method remove the contacts passed as argument from the manager's contacts list
        /// </summary>
        /// <param name="contacts"></param>
        public void Remove(List<Contact> contactsToRemove)
        {
            if (_contacts != null)
            {
                if (_contacts.Count != 0)
                {
                    foreach (Contact contactToRemove in contactsToRemove)
                    {
                        _contacts.Remove(contactToRemove);
                    }
                }
            }
            else
            {
                throw new RemoveContactException();
            }
        }
        #endregion public methods

        #region private methods
        private bool Exist(Contact contactToFind)
        {
            if (!_contacts.Contains(contactToFind))
            {
                return true;
            }
            return false;
        }
        #endregion private methods

    }
}

public class ContactListManager : Exception { }

public class RemoveContactException : ContactListManager { }
