using MySql.Data.MySqlClient;
using mis321_bonus_aevansmartinez.interfaces;
using mis321_bonus_aevansmartinez.models;

namespace mis321_bonus_aevansmartinez.utilities
{
    public class GetAllCars : IGetAllCars
    {
        List<Car> IGetAllCars.GetAllCars(){
            List<Car> cars = new List<Car>();
            
            ConnectionString connect = new ConnectionString();
            string cs = connect.cs;
            using MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * from cars";
            using MySqlCommand cmd = new MySqlCommand(stm, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<Car> allCars = new List<Car>();
            while(rdr.Read())
            {
                allCars.Add(new Car(){
                    id = rdr.GetInt32(0), 
                    make = rdr.GetString(1), 
                    model = rdr.GetString(2),
                    mileage = rdr.GetDouble(3), 
                    hold = rdr.GetBoolean(4), 
                    deleted = rdr.GetBoolean(5)
                });
            } 
            return allCars;
        }
    }
}