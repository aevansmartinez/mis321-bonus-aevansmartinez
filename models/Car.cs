namespace mis321_bonus_aevansmartinez.models
{
    public class Car
    {
        public int id {get; set;}
        public string make {get; set;}
        public string model {get; set;}
        public double mileage {get; set;}
        public bool hold {get; set;}
        public bool deleted {get; set;}
        
        public override string ToString()
        {
            return (id + " " + make + " " + model + " " + mileage + " " + hold + " " + deleted);
        }
    }
}