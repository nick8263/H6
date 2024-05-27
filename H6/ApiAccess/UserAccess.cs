using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace ApiAccess
{
    public class UserAccess
    {
        private HttpClient _httpClient;
        //string connectionString = "https://localhost:7089/api/User/";
        string connectionString = "https://localhost:7184/api/User/";

        public UserAccess()
        {
            _httpClient = new HttpClient();
            
        }

        public async Task<(User, string)> Login(LoginModel user)
        {
            user.Password = HashPassword(user.Password);
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
                    User retrievedUser = JsonConvert.DeserializeObject<User>(responseContent);

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
            catch
            {
                return (null, "Something went wrong, contact customer support");
                
            }
        }

        
        public async Task<(bool, string)> CreateUser(User user)
        {
            user.Password = HashPassword(user.Password);
            try
            {
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

        public async Task<(List<User>, string)> ReadAllUser()
        {
            try
            {
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

        public async Task<(User, string)> ReadUser(int id)
        {            
            try
            {
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

        public async Task<(bool, string)> UpdateUser(User user)
        {
            user.Password = HashPassword(user.Password);
            try
            {
                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(user);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PostAsync(connectionString + "UpdateUser", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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

        public async Task<(bool, string)> DeleteUser(int id)
        {          
            try
            {                

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"DeleteUser?id={id}");

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




        public string HashPassword(string password)
        {
            // Generate a random salt
            byte[] salt = GenerateSalt();

            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the password string to bytes
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Combine the password bytes with the salt
                byte[] combinedBytes = new byte[passwordBytes.Length + salt.Length];
                Array.Copy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
                Array.Copy(salt, 0, combinedBytes, passwordBytes.Length, salt.Length);

                // Compute the hash
                byte[] hash = sha256.ComputeHash(combinedBytes);

                // Convert the hash and salt to a string representation
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(Convert.ToBase64String(salt));
                stringBuilder.Append("|");
                stringBuilder.Append(Convert.ToBase64String(hash));

                return stringBuilder.ToString();
            }
        }

        private byte[] GenerateSalt()
        {
            // Generate a cryptographic random salt
            byte[] salt = new byte[16]; // 16 bytes = 128 bits
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
