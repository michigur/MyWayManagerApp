using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MyWayManagerApp.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;

namespace MyWayManagerApp.Services
{
    class MyWayManagerAPIProxy
    {

        private const string CLOUD_URL = "http://10.0.2.2:9380/mywayAPI"; //API url when going on the cloud
        private const string CLOUD_PHOTOS_URL = "http://10.0.2.2:9380/Images/";
        private const string DEV_ANDROID_EMULATOR_URL = "http://10.0.2.2:9380/mywayAPI"; //API url when using emulator on android
        private const string DEV_ANDROID_PHYSICAL_URL = "http://192.168.1.14:9380/mywayAPI"; //API url when using physucal device on android
        private const string DEV_WINDOWS_URL = "http://localhost:9380/mywayAPI"; //API url when using windoes on development
        private const string DEV_ANDROID_EMULATOR_PHOTOS_URL = "http://10.0.2.2:9380/Images/"; //API url when using emulator on android
        private const string DEV_ANDROID_PHYSICAL_PHOTOS_URL = "http://192.168.1.14:9380/Images/"; //API url when using physucal device on android
        private const string DEV_WINDOWS_PHOTOS_URL = "https://localhost:44312/Images/"; //API url when using windoes on development

        private HttpClient client;
        private string baseUri;
        private string basePhotosUri;
        private static MyWayManagerAPIProxy proxy = null;

        public static MyWayManagerAPIProxy CreateProxy()
        {
            string baseUri;
            string basePhotosUri;
            if (App.IsDevEnv)
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    if (DeviceInfo.DeviceType == DeviceType.Virtual)
                    {
                        baseUri = DEV_ANDROID_EMULATOR_URL;
                        basePhotosUri = DEV_ANDROID_EMULATOR_PHOTOS_URL;
                    }
                    else
                    {
                        baseUri = DEV_ANDROID_PHYSICAL_URL;
                        basePhotosUri = DEV_ANDROID_PHYSICAL_PHOTOS_URL;
                    }
                }
                else
                {
                    baseUri = DEV_WINDOWS_URL;
                    basePhotosUri = DEV_WINDOWS_PHOTOS_URL;
                }
            }
            else
            {
                baseUri = CLOUD_URL;
                basePhotosUri = CLOUD_PHOTOS_URL;
            }

            if (proxy == null)
                proxy = new MyWayManagerAPIProxy(baseUri, basePhotosUri);
            return proxy;
        }


        private MyWayManagerAPIProxy(string baseUri, string basePhotosUri)
        {
            //Set client handler to support cookies!!
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new System.Net.CookieContainer();

            //Create client with the handler!
            this.client = new HttpClient(handler, true);
            this.baseUri = baseUri;
            this.basePhotosUri = basePhotosUri;
        }


        public async Task<Manager> LoginAsync(string email, string pass)
        {

            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/LoginM?email={email}&pass={pass}");
               
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    Manager u = JsonSerializer.Deserialize<Manager>(content, options);
                    return u;
                }
                else
                {
                    return null;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
                
                return null;
            }
        }


        public async Task<List<Client>> GetUsersAsync()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetClients");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<Client> tbl = JsonSerializer.Deserialize<List<Client>>(content, options);


                    return tbl;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        public async Task<List<Car>> GetCarsAsync()
        {
            try
            {

                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetCars");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve,
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<Car> eList = JsonSerializer.Deserialize<List<Car>>(content, options);
                    return eList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }





        public async Task<Manager> SignUpAsync(Manager u)
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    PropertyNameCaseInsensitive = true
                };
                string jsonObject = JsonSerializer.Serialize<Manager>(u, options);
                StringContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/SignUp", content);
                if (response.IsSuccessStatusCode)
                {

                    jsonObject = await response.Content.ReadAsStringAsync();
                    Manager updatedUser = JsonSerializer.Deserialize<Manager>(jsonObject, options);
                    return updatedUser;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }






        public async Task<Car> AddCar(Car u)
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    PropertyNameCaseInsensitive = true
                };
                string json = JsonSerializer.Serialize<Car>(u, options);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/AddCar", content);
                if (response.IsSuccessStatusCode)
                {

                    string jsonContent = await response.Content.ReadAsStringAsync();
                    Car b = JsonSerializer.Deserialize<Car>(jsonContent, options);
                    return b;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
