using System;
using System.Collections.Generic;    
using ApplicationDatabase.ResultData;

namespace ApplicationDatabase.Interfaces
{
    public interface IDataService
    {
        /*
       *
       Sprawdzanie statusu konta użytkownika aplikacji, jeżeli konto jest nieaktywne, 
       a data początkowa jest przekroczona, natomiast data końcowa nie jest wówczas status zostaje
       zmieniony na aktywny.
       *
       */
        void ValidateOpUsers(string user);

        /*
        *
        Logowanie do aplikacji, sprawdzanie ważności konta.
        *
        */
        bool EnterApplication(string user, string password);

        /*
        *
        Sprawdzanie czy użytkownik ma zaznaczoną flage administratora,
        jeżeli nie wówczas nie widzi panelu administracyjnego.
        *
        */
        bool ValidateIfAdmin(string user);

        /*
        *
        Metoda pobierająca dane wszystkich użytkowników zarządzających do widoku aplikacji.
        *
        */
        List<OpUser_Result> LoadOpUsers();

        /*
        *
        Metoda pobierająca dane wszystkich użytkowników mających podobną nazwe użytkownika do podanej przez końcowego użytkownika.
        *
        */
        List<OpUser_Result> SearchOpUsers(string login);

        /*
        *
        Metoda pobierająca dane sprzedawcy, do wyświetlenia na fakturze/paragonie.
        */
        List<OpUser_Result> GetPokInformation(string user);

        /* 
        Metoda zatwierdzająca płatność.
        */
        void ConfirmPurchase(string product, string type, string quantity, string fullcost, string costwithoutvat, string vat, string customer, string paymentType, string confirmedBy, string transactionDate, string activationDate, string validationTime);

        /*        
        Pobieranie identyfikatora ostatniej transakcji.
        */
        string GetTransactionId();

        /* 
        Metoda pobierająca wszystkie produkty zapisane w bazie do listy.
        */
        List<System.Windows.Forms.ListViewItem> LoadProducts();

        /* 
        Metoda pobierająca wszystkich klientów zarejestrowanych w aplikacji do listy.
        */
        List<System.Windows.Forms.ListViewItem> LoadCustomers();

        /* 
        Metoda dodająca klienta do aplikacji.
        */
        void AddNewClient(string firstName, string surName, string password, string pesel, string email, string street, string zipcode, string city, bool ar, bool amr);
        
        /* 
        Metoda zmieniająca hasło pracownika POK.
        */
        void ChangePassword(string user, string password);

        /* 
        Metoda aktualizująca dane użytkownika.
        */
        void UpdatePokUserData(string user, string email, DateTime endDate, DateTime startDate, int pok, int admin, string phone);

        /* 
        Metoda aktualizująca dane użytkownika.
        */
        void DeleteAccount(string user);

        /* 
        Metoda tworząca użytkownika zarządzającego aplikacją.
        */
        void RegisterOpUser(string user, string name, string surname, string phone, string email, string password,
            int status, string startDate, string endDate, int adm, int pok);
        /* 
        Metoda pobierająca oraz aktualizująca aktualne bilety względem taryfy
        */
        List<TicketModel> GetTariffTickets(string type, int zone, bool student, bool resident, bool parking);

        /* 
        Metoda pobierająca oraz aktualizująca aktualne bilety parkingowe względem taryfy
        */
        List<TicketModel> GetParkingTickets(string type, bool resident);

        void Connection(bool state);
    }
}
