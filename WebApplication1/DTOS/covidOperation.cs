using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class covidOperation {
        private string jsonPath = @"C:\Users\Anirban Das\Desktop\Krishna\DatingApp\WebApplication1\assets\data.json";
        covidData covidData = null;
        
        private string getDataFromApi(){
            string urlText = String.Empty;
            try {
            WebRequest request = HttpWebRequest.Create("https://api.covid19india.org/data.json");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            urlText = reader.ReadToEnd();
            urlText = Regex.Replace(urlText, @"\t|\n|\r", "");
            }
            catch(Exception Ex){
                Console.WriteLine("Exception while fetching data cfrom api");
            }
            return urlText;
        }

        private covidData deserlizieObject(string jsonData){
           
            try {
                covidData = JsonConvert.DeserializeObject<covidData>(jsonData);
                List<statewise> ss = covidData.statewise;
            } catch(Exception ex){
                Console.WriteLine("Exception while fetching data cfrom api");
            }
           return covidData;
        }

        private string serilizeObject(covidData ob){
              string jsonString = String.Empty;
              try{
                    covidData = new covidData(){
                    statewise = new List<statewise>{
                    new statewise()
                    { active  = "12" , confirmed = "13" , deaths = "1" , recovered = "4" , state = "bih" , statecode="12"},
                    new statewise()
                    { active  = "11" , confirmed = "33" , deaths = "2" , recovered = "2" , state = "wb" , statecode="13"}
                }
                };
                jsonString = JsonConvert.SerializeObject(ob);
            }
            catch(Exception ex){
                Console.WriteLine("Exception while serilizing data");
            }
              
          return jsonString;
        }

        private void writeData(string jsonData) {
            File.WriteAllText(jsonPath, jsonData);
        }

        private string readData(string jsonData){
             string text = String.Empty;
             try {
                if (File.Exists(jsonPath)) {  
                // Read entire text file content in one string    
                text = File.ReadAllText(jsonPath);  
                 }  
             }
             catch(Exception ex){
                Console.WriteLine("Exception while reading data from file");
             }
             
            return text;
        }

        public string writeDataIntoFileFromApi(){
            string text = getDataFromApi();
            covidData = deserlizieObject(text);
            string json = serilizeObject(covidData);
            writeData(json);
            return json;
        }
     
    }
}