using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using ApplicationDatabase.Interfaces;
using ApplicationDatabase.ResultData;

namespace ApplicationDatabase.DataServices
{
    public class DataService : IDataService
    {
        public SqlConnection connection;

        public void Connection(bool state)
        {
            if (this.connection != null && !state && (this.connection.State & ConnectionState.Open) != 0)
            {
                this.connection.Close();
            }
            else if ((this.connection == null || this.connection.State == ConnectionState.Closed) && state)
            {
                this.connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                this.connection.Open();
            }
        }

        public void ValidateOpUsers(string user)
        {
            this.Connection(true);
            using (SqlCommand command = new SqlCommand(@"SELECT UserName, Status, StartDate, EndDate FROM OpUser WHERE UserName = @UserName", this.connection))
            {
                DateTime now = DateTime.Now;
                command.Parameters.Add(new SqlParameter("UserName", user));
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    if (dataReader.GetString(0).ToLowerInvariant() == user)
                    {
                        if (dataReader.GetBoolean(1).Equals(false) && now >= Convert.ToDateTime(dataReader.GetDateTime(2)) && Convert.ToDateTime(dataReader.GetDateTime(3)) > now)
                        {
                            dataReader.Close();
                            string statusUPD = "UPDATE OpUser SET STATUS = 1 WHERE UserName = @User";
                            SqlCommand st2 = new SqlCommand(statusUPD, this.connection);
                            st2.Parameters.AddWithValue("@User", user);
                            st2.ExecuteNonQuery();
                        }
                    }

                    if (!dataReader.IsClosed)
                    {
                        dataReader.Close();
                    }
                }
            }

            this.Connection(false);
        }

        public bool EnterApplication(string user, string password)
        {
            user = user.ToLowerInvariant();
            DateTime now = DateTime.Now;
            this.ValidateOpUsers(user);
            this.Connection(true);
            using (SqlCommand command = new SqlCommand(@"SELECT UserName, Password, StartDate, EndDate, Status FROM OpUser WHERE UserName = @UserName AND Password = @Password", this.connection))
            {
                command.Parameters.Add(new SqlParameter("UserName", user));
                command.Parameters.Add(new SqlParameter("Password", password));
                SqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows && dataReader.GetString(0).ToLowerInvariant().Equals(user) && dataReader.GetString(1).Equals(password))
                {
                    DateTime startdate = Convert.ToDateTime(dataReader.GetDateTime(2).Date);
                    DateTime stopdate = Convert.ToDateTime(dataReader.GetDateTime(3).Date);
                    if (dataReader.GetBoolean(4) && now >= startdate && stopdate > now)
                    {
                        dataReader.Close();
                        return true;
                    }
                    else
                    {
                        if (dataReader.GetBoolean(4) == false)
                        {
                            MessageBox.Show(@"Konto nieaktywne, proszę o kontakt z administratorem systemu.", @"Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        if (now <= startdate)
                        {
                            MessageBox.Show(@"Konto nie jest jeszcze aktywne, data aktywacji konta : " + startdate, @"Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        if (now >= stopdate)
                        {
                            MessageBox.Show(@"Okres ważności konta minął.", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    dataReader.Close();
                    return false;
                }
                else
                {
                    dataReader.Close();
                    this.Connection(false);
                    MessageBox.Show(@"Proszę sprawdz swoj login lub haslo, a nastepnie sprobuj ponownie.", @"Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
        }

        public bool ValidateIfAdmin(string user)
        {
            this.Connection(true);
            using (SqlCommand command = new SqlCommand(@"SELECT isAdmin FROM OpUser WHERE UserName = @UserName", this.connection))
            {
                command.Parameters.Add(new SqlParameter("UserName", user));
                var returnedValue = command.ExecuteScalar();
                Thread.Sleep(500);
                this.Connection(false);
                return (bool)returnedValue;
            }
        }

        public List<OpUser_Result> LoadOpUsers()
        {
            var resultList = new List<OpUser_Result>();
            this.Connection(true);
            using (SqlCommand command = new SqlCommand(@"SELECT * FROM OpUser ORDER BY StartDate", this.connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultList.Add(
                            new OpUser_Result
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Surname = reader.GetString(2),
                                UserName = reader.GetString(3),
                                Phone = reader.GetString(4),
                                Email = reader.GetString(5),
                                Password = reader.GetString(6),
                                Status = reader.GetBoolean(7),
                                StartDate = reader.GetDateTime(8),
                                EndDate = reader.GetDateTime(9),
                                isAdmin = reader.GetBoolean(10),
                                POK = reader.GetInt32(11),
                            });
                    }
                }
            }

            this.Connection(false);
            return resultList;
        }

        public List<OpUser_Result> SearchOpUsers(string login)
        {
            var resultList = new List<OpUser_Result>();
            this.Connection(true);
            using (SqlCommand command = new SqlCommand(@"SELECT * FROM OpUser WHERE UserName LIKE '%' + @UserName + '%' ORDER BY StartDate", this.connection))
            {
                command.Parameters.Add(new SqlParameter("UserName", login));
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultList.Add(
                            new OpUser_Result
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Surname = reader.GetString(2),
                                UserName = reader.GetString(3),
                                Phone = reader.GetString(4),
                                Email = reader.GetString(5),
                                Password = reader.GetString(6),
                                Status = reader.GetBoolean(7),
                                StartDate = reader.GetDateTime(8),
                                EndDate = reader.GetDateTime(9),
                                isAdmin = reader.GetBoolean(10),
                                POK = reader.GetInt32(11),
                            });
                    }
                }
            }

            this.Connection(false);
            return resultList;
        }

        public List<OpUser_Result> GetPokInformation(string login)
        {
            var resultList = new List<OpUser_Result>();
            this.Connection(true);
            using (SqlCommand command = new SqlCommand(@"SELECT * FROM OpUser WHERE UserName = @UserName", this.connection))
            {
                command.Parameters.Add(new SqlParameter("UserName", login));
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultList.Add(
                            new OpUser_Result
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Surname = reader.GetString(2),
                                UserName = reader.GetString(3),
                                Phone = reader.GetString(4),
                                Email = reader.GetString(5),
                                Password = reader.GetString(6),
                                Status = reader.GetBoolean(7),
                                StartDate = reader.GetDateTime(8),
                                EndDate = reader.GetDateTime(9),
                                isAdmin = reader.GetBoolean(10),
                                POK = reader.GetInt32(11),
                            });
                    }
                }
            }

            this.Connection(false);
            return resultList;
        }

        public void ChangePassword(string user, string password)
        {
            this.Connection(true);
            using (SqlCommand command = new SqlCommand(@"UPDATE OpUser SET PASSWORD=@password WHERE UserName=@user",
                this.connection))
            {
                command.Parameters.Add(new SqlParameter("user", user));
                command.Parameters.Add(new SqlParameter("password", password));
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    MessageBox.Show(@"Hasło nie zostało zmienione.");
                }
                else
                {
                    MessageBox.Show(@"Hasło zostało zmienione pomyślnie.");
                }
            }

            this.Connection(false);
        }

        public void UpdatePokUserData(string user, string email, DateTime endDate, DateTime startDate, int pok, int admin, string phone)
        {                                                                                                                                                 
            this.Connection(true);
            using (SqlCommand command = new SqlCommand(@"UPDATE OpUser SET StartDate=@startDate, EndDate=@endDate, Email=@email, POK=@pok, isAdmin=@admin, Phone=@phone WHERE UserName=@user",
                this.connection))
            {
                command.Parameters.Add(new SqlParameter("email", email));
                command.Parameters.Add(new SqlParameter("endDate", endDate));
                command.Parameters.Add(new SqlParameter("startDate", startDate));
                command.Parameters.Add(new SqlParameter("pok", pok));
                command.Parameters.Add(new SqlParameter("admin", admin));
                command.Parameters.Add(new SqlParameter("phone", phone));
                command.Parameters.Add(new SqlParameter("user", user));          
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    MessageBox.Show(@"Dane nie zostały zaktualizowane.");
                }
                else
                {
                    MessageBox.Show(@"Dane zostały zaktualizowane.");
                }
            }

            this.Connection(false);
        }

        public void ConfirmPurchase(string product, string type, string quantity, string fullcost, string costwithoutvat, string vat, string customer, string paymentType, string confirmedBy, string transactionDate, string activationDate, string validationTime)
        {
            this.Connection(true);
            SqlTransaction sqlTran = this.connection.BeginTransaction();
            SqlCommand command = this.connection.CreateCommand();
            int transactionId = 0;
            try
            {
                command.CommandText = @"INSERT INTO Transactions(TicketType, Quantity, FullCost, CostWithoutVAT, VAT, Product_ID, Customer_ID, PaymentType, ConfirmedBy) VALUES(@type, @quantity, @fullcost, @costwithoutvat, @vat, @product, @customer, @paymentType, @confirmedBy)";
                command.Transaction = sqlTran;
                command.Parameters.Add(new SqlParameter(@"type", type));
                command.Parameters.Add(new SqlParameter(@"quantity", quantity));
                command.Parameters.Add(new SqlParameter(@"fullcost", fullcost));
                command.Parameters.Add(new SqlParameter(@"costwithoutvat", costwithoutvat));
                command.Parameters.Add(new SqlParameter(@"vat", vat));
                command.Parameters.Add(new SqlParameter(@"product", product));
                command.Parameters.Add(new SqlParameter(@"customer", customer));
                command.Parameters.Add(new SqlParameter(@"paymentType", paymentType));
                command.Parameters.Add(new SqlParameter(@"confirmedBy", confirmedBy));
                command.Parameters.Add(new SqlParameter(@"transactionDate", transactionDate));
                command.Parameters.Add(new SqlParameter(@"activationDate", activationDate));
                command.Parameters.Add(new SqlParameter(@"validationTime", validationTime));
                command.ExecuteNonQuery();
                command.CommandText = @"SELECT TOP 1* FROM Transactions ORDER BY ID DESC";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transactionId = reader.GetInt32(0);
                    }
                }

                command.Parameters.Add(new SqlParameter(@"transactionId", transactionId));
                command.CommandText = @"INSERT INTO TransactionDetails(TransactionDate, ActivationDate, ValidationTime, TransactionId) VALUES(@transactionDate, @activationDate, @validationTime, @transactionId)";
                command.ExecuteNonQuery();
                sqlTran.Commit();

            }
            catch (Exception)
            {
                sqlTran.Rollback();
            }

            this.Connection(false);
        }

        public void ConfirmPurchaseWithDetails(string transactionDate, string activationDate, string validationTime, string transactionId)
        {
            this.Connection(true);
            using (SqlCommand command = new SqlCommand(@"INSERT INTO TransactionDetails(TransactionDate, ActivationDate, ValidationTime, TransactionDetails) VALUES(@transactionDate, @activationDate, @validationTime, @transactionId)", this.connection))
            {
                command.Parameters.Add(new SqlParameter(@"transactionDate", transactionDate));
                command.Parameters.Add(new SqlParameter(@"activationDate", activationDate));
                command.Parameters.Add(new SqlParameter(@"validationTime", validationTime));
                command.Parameters.Add(new SqlParameter(@"transactionId", transactionId));
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    MessageBox.Show(@"Transakcja nie została pomyslnie obsłużona.");
                }
            }

            this.Connection(false);
        }

        public string GetTransactionId()
        {
            int id = 0;
            this.Connection(true);
            using (SqlCommand command = new SqlCommand(@"SELECT TOP 1* FROM Transactions ORDER BY ID DESC", this.connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
            }

            this.Connection(false);
            return id.ToString();
        }

        public List<OpUser_Result> GetProductsForuser(string login)
        {
            var resultList = new List<OpUser_Result>();
            this.Connection(true);
            using (SqlCommand command = new SqlCommand(@"SELECT * FROM OpUser WHERE UserName = @UserName", this.connection))
            {
                command.Parameters.Add(new SqlParameter("UserName", login));
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultList.Add(
                            new OpUser_Result
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Surname = reader.GetString(2),
                                UserName = reader.GetString(3),
                                Phone = reader.GetString(4),
                                Email = reader.GetString(5),
                                Password = reader.GetString(6),
                                Status = reader.GetBoolean(7),
                                StartDate = reader.GetDateTime(8),
                                EndDate = reader.GetDateTime(9),
                                isAdmin = reader.GetBoolean(10),
                                POK = reader.GetInt32(11),
                            });
                    }
                }
            }

            this.Connection(false);
            return resultList;
        }

        public List<System.Windows.Forms.ListViewItem> LoadCustomers()
        {
            var resultList = new List<System.Windows.Forms.ListViewItem>();
            this.Connection(true);
            using (SqlCommand command = new SqlCommand(@"SELECT * FROM Customer", this.connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader.GetInt32(0).ToString());
                        item.SubItems.Add(reader.GetString(1));
                        item.SubItems.Add(reader.GetString(2));
                        resultList.Add(item);
                    }
                }
            }

            this.Connection(false);
            return resultList;
        }

        public List<System.Windows.Forms.ListViewItem> LoadProducts()
        {
            var resultList = new List<System.Windows.Forms.ListViewItem>();
            this.Connection(true);
            using (SqlCommand command = new SqlCommand(@"SELECT * FROM Products Order by Type", this.connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader.GetInt32(0).ToString());
                        item.SubItems.Add(reader.GetString(1));
                        using (var cmd = this.connection.CreateCommand())
                        {
                            cmd.Parameters.AddWithValue("@id", reader.GetInt32(4));
                            cmd.CommandText = @"SELECT Name FROM Zone Where ID = @id";
                            using (var reader2 = cmd.ExecuteReader())
                            {
                                while (reader2.Read())
                                {
                                    item.SubItems.Add(reader2.GetString(0));
                                }
                            }
                        }

                        item.SubItems.Add(reader.GetString(2));
                        item.SubItems.Add(reader.GetSqlMoney(3).ToString());
                        resultList.Add(item);
                    }
                }
            }

            this.Connection(false);
            return resultList;
        }

        public void DeleteAccount(string user)
        {
            this.Connection(true);
            using (SqlCommand command = new SqlCommand(@"DELETE FROM OpUser where UserName=@user", this.connection))
            {
                command.Parameters.AddWithValue("@user", user);
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    MessageBox.Show(@"Użytkownik nie został usunięty.");
                }
                else
                {
                    MessageBox.Show(@"Użytkownik został usunięty.");
                }
            }

            this.Connection(false);
        }

        public void RegisterOpUser(string user, string name, string surname, string phone, string email, string password, int status, string startDate, string endDate, int adm, int pok)
        {
            this.Connection(true);
            bool noLoginFound = true;
            using (SqlCommand command = new SqlCommand(@"SELECT UserName FROM OpUser WHERE UserName=@user OR Email=@email", this.connection))
            {
                command.Parameters.AddWithValue("@user", user);
                command.Parameters.AddWithValue("@email", email);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        noLoginFound = string.IsNullOrWhiteSpace(reader.GetString(0));
                    }
                }      
            }
             
            if (noLoginFound)
            {
                using (SqlCommand command = new SqlCommand(
                    @"INSERT INTO OpUser (Name, Surname, Username, Phone, Email, Password, Status, StartDate, EndDate, isAdmin, POK) VALUES(@name, @surname, @user, @phone, @email, @password, @status, @startDate, @endDate, @adm, @pok)",
                    this.connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@surname", surname);
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);
                    command.Parameters.AddWithValue("@adm", adm);
                    command.Parameters.AddWithValue("@pok", pok);
                    int result = command.ExecuteNonQuery();
                    if (result < 0)
                    {
                        MessageBox.Show(@"Użytkownik nie został dodany.");
                    }
                    else
                    {
                        MessageBox.Show(@"Użytkownik został dodany.");
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Podany użytkownik istnieje już w systemie.");
            }

            this.Connection(false);
        }   

        public void AddNewClient(string firstName, string surName, string password, string pesel, string email, string street, string zipcode, string city, bool ar, bool amr)
        {
            int validateIfUserExists;
            this.Connection(true);                   
            using (SqlCommand command = new SqlCommand(@"Select * FROM Customer WHERE Email = @email and Surname = @surName", this.connection))
            {
                command.Parameters.Add(new SqlParameter("email", email));
                command.Parameters.Add(new SqlParameter("surName", surName));
                validateIfUserExists = Convert.ToInt32(command.ExecuteScalar());
                if (validateIfUserExists > 0)
                {
                    MessageBox.Show(@"Użytkownik z podanymi danymi już istnieje!", @"Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (validateIfUserExists < 1)
            {
                using (SqlCommand command = new SqlCommand(
                    @"INSERT INTO CUSTOMER (Name, Surname, Email, Address, ZipCode, City, Pesel, AR, AMR) VALUES(@firstName, @surName, @email, @street, @zipcode, @city, @pesel, @ar, @amr)",
                    this.connection))
                {
                    command.Parameters.Add(new SqlParameter("email", surName));
                    command.Parameters.Add(new SqlParameter("surName", email));
                    command.Parameters.Add(new SqlParameter(@"firstName", firstName));
                    command.Parameters.Add(new SqlParameter("password", password));
                    command.Parameters.Add(new SqlParameter("pesel", pesel));
                    command.Parameters.Add(new SqlParameter("street", street));
                    command.Parameters.Add(new SqlParameter("zipcode", zipcode));
                    command.Parameters.Add(new SqlParameter("city", city));
                    command.Parameters.Add(new SqlParameter("ar", Convert.ToInt16(ar)));
                    command.Parameters.Add(new SqlParameter("amr", Convert.ToInt16(amr)));
                    int result = command.ExecuteNonQuery();
                    if (result < 0)
                    {
                        MessageBox.Show(@"Użytkownik nie został dodany do systemu!");
                    }

                    if (result > 0)
                    {
                        MessageBox.Show(@"Użytkownik został pomyślnie dodany do systemu!");
                    }
                }

            }

            this.Connection(false);   
        }

        public List<TicketModel> GetTariffTickets(string type, int zone, bool student, bool resident, bool parking)
        {
            this.Connection(true);
            var messages = new List<ApplicationDatabase.ResultData.TicketModel>();
            using (var command = new SqlCommand(@"SELECT [Type], [Name], [Cost], [Zone], [StudentTicket], [ParkingTicket], [ResidentTicket] FROM [ProductionBase].[dbo].[Products] WHERE [ZONE]=@zone AND [StudentTicket]=@student AND [ResidentTicket]=@resident AND [ParkingTicket]=@parking AND [OnlyParking] = 0 AND Type = (CASE WHEN (@type <> 'Any') THEN @type Else [Type] END)", connection))
            {
                command.Notification = null;
                command.Parameters.Add(new SqlParameter("type", type));
                command.Parameters.Add(new SqlParameter("zone", zone));
                command.Parameters.Add(new SqlParameter("student", student));
                command.Parameters.Add(new SqlParameter("resident", resident));
                command.Parameters.Add(new SqlParameter("parking", parking));

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    messages.Add(item: new ApplicationDatabase.ResultData.TicketModel { Type = (string)reader["Type"], Name = (string)reader["Name"], Cost = (decimal)reader["Cost"], Zone = (int)reader["Zone"], Student = (bool)reader["StudentTicket"], Parking = (bool)reader["ParkingTicket"], Resident = (bool)reader["ResidentTicket"] });
                }
            }

            this.Connection(false);
            return messages;
        }

        public List<TicketModel> GetParkingTickets(string type, bool resident)
        {
            var messages = new List<ApplicationDatabase.ResultData.TicketModel>();
            this.Connection(true);
            using (var command = new SqlCommand(@"SELECT * FROM [ProductionBase].[dbo].[Products] WHERE [ResidentTicket]=@resident AND [OnlyParking] = 1 AND Type = (CASE WHEN (@type <> 'Any') THEN @type Else [Type] END)", connection))
            {
                command.Notification = null;
                command.Parameters.Add(new SqlParameter("type", type));
                command.Parameters.Add(new SqlParameter("resident", resident));

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    messages.Add(item: new ApplicationDatabase.ResultData.TicketModel { Type = (string)reader["Type"], Name = (string)reader["Name"], Cost = (decimal)reader["Cost"], Zone = (int)reader["Zone"], Resident = (bool)reader["ResidentTicket"] });
                }
            }

            this.Connection(false);
            return messages;
        }
    }
}
