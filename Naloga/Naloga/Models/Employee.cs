using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naloga.Models
{
    public class Employee
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int ID { get; set; }
        [JsonProperty("employee_name")]
        public string Name { get; set; }
        [JsonProperty("employee_salary")]
        public int Salary{ get; set; }
        [JsonProperty("employee_age")]
        public int Age{ get; set; }
        [JsonProperty("profile_image")]
        public string ProfileImage{ get; set; }

    }
}
