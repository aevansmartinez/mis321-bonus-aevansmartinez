using MySql.Data.MySqlClient;
using mis321_bonus_aevansmartinez.models;
using mis321_bonus_aevansmartinez.interfaces;
namespace mis321_bonus_aevansmartinez.utilities
{
    public class CreateCar : ICreateCar
    {
        int ICreateCar.CreateCar(Car myCar){
            ConnectionString myConnection = new ConnectionString();
            string connects = myConnection.cs;
            using var con = new MySqlConnection(connects);
            con.Open();

            string stm = @"INSERT INTO cars(make, model, mileage) VALUES(@make, @model, @mileage)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@make", myCar.make);
            cmd.Parameters.AddWithValue("@model", myCar.model);
            cmd.Parameters.AddWithValue("@mileage", myCar.mileage);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            return (int)(long)cmd.LastInsertedId;
        }
    }
}