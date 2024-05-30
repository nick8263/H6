using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;



namespace ApiAccess
{
    public class UserAccess
    {
        private HttpClient _httpClient;
        //string connectionString = "https://localhost:7089/api/User/";
        string connectionString = "https://localhost:7012/api/User/";

        public UserAccess()
        {
            _httpClient = new HttpClient();
            
        }

        public async Task<(TokenUser, string)> Login(LoginModel user)
        {            
            
            try
            {
                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(user);
                
                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PostAsync(connectionString + "Login", new StringContent(serializedId, Encoding.UTF8, "application/json"));

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response JSON to User object
                    TokenUser retrievedUser = JsonConvert.DeserializeObject<TokenUser>(responseContent);

                    // Return the retrieved user
                    return (retrievedUser, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get user. Status code: " + response.StatusCode);
                }
            }
            catch (Exception e)
            {
                return (null, "Something went wrong, contact customer support \n" + e.Message);
                
            }
        }

        
        public async Task<(bool, string)> CreateUser(User user, string token)
        {           
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(user);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PostAsync(connectionString + "CreateUser", new StringContent(serializedId, Encoding.UTF8, "application/json"));

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {

                    // Return the retrieved user
                    return (true, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (false, responseContent);
                }
                else
                {
                    return (false, "Failed to update user. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        public async Task<(List<User>, string)> ReadAllUser(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadAllUser");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    List<User> users = JsonConvert.DeserializeObject<List<User>>(responseContent);

                    return (users, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to update user. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }

        public async Task<(User, string)> ReadUser(int id, string token)
        {            
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadUser?id={id}");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    User user = JsonConvert.DeserializeObject<User>(responseContent);
                   
                    return (user, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to update user. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }

        public async Task<(bool, string)> UpdateUser(TokenUser tokenUser)
        {            
            try
            {
                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(tokenUser.User);

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenUser.Token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PutAsync(connectionString + "UpdateUser", new StringContent(serializedId, Encoding.UTF8, "application/json"));

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {

                    // Return the retrieved user
                    return (true, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (false, responseContent);
                }
                else
                {
                    return (false, "Failed to update user. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        public async Task<(bool, string)> DeleteUser(int id, string token)
        {          
            try
            {

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.DeleteAsync(connectionString + $"DeleteUser?id={id}");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {

                    // Return the retrieved user
                    return (true, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (false, responseContent);
                }
                else
                {
                    return (false, "Failed to update user. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }



        
    }
}
