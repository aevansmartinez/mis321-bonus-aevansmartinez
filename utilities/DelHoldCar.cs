using MySql.Data.MySqlClient;
using mis321_bonus_aevansmartinez.interfaces;
using mis321_bonus_aevansmartinez.models;
namespace mis321_bonus_aevansmartinez.utilities
{
    public class DelHoldCar : IDelHoldCar
    {
        void IDelHoldCar.DelHoldCar(Car myCar){
            ConnectionString myConnection = new ConnectionString();
            string connects = myConnection.cs;
            using var con = new MySqlConnection(connects);
            con.Open();
            
            string stm = @"UPDATE cars SET make = @make, model = @model, mileage = @mileage, hold = @hold, deleted = @deleted WHERE id = @id";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", myCar.id);
            cmd.Parameters.AddWithValue("@make", myCar.make);
            cmd.Parameters.AddWithValue("@model", myCar.model);
            cmd.Parameters.AddWithValue("@mileage", myCar.mileage);
            cmd.Parameters.AddWithValue("@hold", myCar.hold);
            cmd.Parameters.AddWithValue("@deleted", myCar.deleted);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}