using MySql.Data.MySqlClient;
using mis321_bonus_aevansmartinez.interfaces;
using mis321_bonus_aevansmartinez.models;

namespace mis321_bonus_aevansmartinez.utilities
{
    public class GetCar : IGetCar
    {
         Car IGetCar.GetCar(int id){
            ConnectionString connectionString = new ConnectionString();
            string cs = connectionString.cs;
            using MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * from cars where id = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Car(){
                id = rdr.GetInt32(0), 
                make = rdr.GetString(1), 
                model = rdr.GetString(2), 
                mileage = rdr.GetDouble(3),
                hold = rdr.GetBoolean(4), 
                deleted = rdr.GetBoolean(5)
            };
        }
    }
}