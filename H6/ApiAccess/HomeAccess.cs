using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiAccess
{
    public class HomeAccess
    {
        private HttpClient _httpClient;
        string connectionString = "https://localhost:7012/api/Home/";
        //string connectionString = "https://7595-212-98-98-74.ngrok-free.app/api/Home/";

        public HomeAccess()
        {
            _httpClient = new HttpClient();

        }

        #region Create
        
        public async Task<(bool, string)> CreateQuestion(Question question, string token)
        {            
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(question);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PostAsync(connectionString + "CreateQuestion", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to create question. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        public async Task<(bool, string)> CreateCountry(Country country, string token)
        {            
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(country);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PostAsync(connectionString + "CreateCountry", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to create country. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        public async Task<(bool, string)> CreateArea(Area area, string token)
        {            
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(area);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PostAsync(connectionString + "CreateArea", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to create area. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        public async Task<(bool, string)> CreateOption(Option option, string token)
        {           
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(option);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PostAsync(connectionString + "CreateOption", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to creaet option. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        public async Task<(bool, string)> CreateAnswer(Answer answer, string token)
        {            
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(answer);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PostAsync(connectionString + "CreateAnswer", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to create answer. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        public async Task<(bool, string)> CreateAnswerGroup(AnswerGroup answerGroup, string token)
        {            
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(answerGroup);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PostAsync(connectionString + "CreateAnswerGroup", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to create answer group. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        public async Task<(bool, string)> CreateQuestionGroup(QuestionGroup questionGroup, string token)
        {
            
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(questionGroup);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PostAsync(connectionString + "CreateQuestionGroup", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to create question group. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        public async Task<(bool, string)> CreateRole(RoleModel role, string token)
        {          
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(role);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PostAsync(connectionString + "CreateRole", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to create role. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }

        }
        #endregion

        #region Read

        #region Question
        
        public async Task<(List<Question>, string)> ReadAllQuestions(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadAllQuestions");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(responseContent);

                    return (questions, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get all questions. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }

        
        public async Task<(Question, string)> ReadQuestion(int id, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadQuestion?id={id}");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    Question question = JsonConvert.DeserializeObject<Question>(responseContent);

                    return (question, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get question. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }
        #endregion

        #region Country
       
        public async Task<(List<Country>, string)> ReadAllCountries(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadAllCountries");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(responseContent);

                    return (countries, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get all countries. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }

       
        public async Task<(Country, string)> ReadCountry(int id, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadCountry?id={id}");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    Country country = JsonConvert.DeserializeObject<Country>(responseContent);

                    return (country, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get country. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }
        #endregion

        #region Area
       
        public async Task<(List<Area>, string)> ReadAllAreas(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadAllAreas");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    List<Area> areas = JsonConvert.DeserializeObject<List<Area>>(responseContent);

                    return (areas, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get all areas. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }

       
        public async Task<(Area, string)> ReadArea(int id, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadArea?id={id}");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    Area area = JsonConvert.DeserializeObject<Area>(responseContent);

                    return (area, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get area. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }
        #endregion

        #region Option
        
        public async Task<(List<Option>, string)> ReadAllOptions(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadAllOptions");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    List<Option> options = JsonConvert.DeserializeObject<List<Option>>(responseContent);

                    return (options, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get all options. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }

       
        public async Task<(Option, string)> ReadOption(int id, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadOption?id={id}");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    Option option = JsonConvert.DeserializeObject<Option>(responseContent);

                    return (option, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get option. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }
        #endregion

        #region Answer
       
        public async Task<(List<Answer>, string)> ReadAllAnswers(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadAllAnswers");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    List<Answer> answers = JsonConvert.DeserializeObject<List<Answer>>(responseContent);

                    return (answers, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get all answers. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }

       
        public async Task<(Answer, string)> ReadAnswer(int id, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadAnswer?id={id}");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    Answer answer = JsonConvert.DeserializeObject<Answer>(responseContent);

                    return (answer, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get answer. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }
        #endregion

        #region AnswerGroup
        
        public async Task<(List<AnswerGroup>, string)> ReadAllAnswerGroups(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadAllAnswerGroups");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    List<AnswerGroup> answerGroups = JsonConvert.DeserializeObject<List<AnswerGroup>>(responseContent);

                    return (answerGroups, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get all answerGroups. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }

    
        public async Task<(List<AnswerGroup>, string)> ReadAnswerGroup(GroupAccessModel groupAccess, string token)
        {
            // Serialize the user object to JSON
            string serializedId = JsonConvert.SerializeObject(groupAccess);
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PostAsync(connectionString + "ReadAnswerGroup", new StringContent(serializedId, Encoding.UTF8, "application/json"));

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    List<AnswerGroup> answerGroups = JsonConvert.DeserializeObject<List<AnswerGroup>>(responseContent);

                    return (answerGroups, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get answerGroups. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }
        #endregion

        #region QuestionGroup
       
        public async Task<(List<QuestionGroup>, string)> ReadAllQuestionGroups(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadAllQuestionGroups");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    List<QuestionGroup> questionGroups = JsonConvert.DeserializeObject<List<QuestionGroup>>(responseContent);

                    return (questionGroups, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get all questionGroups. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }

        
        public async Task<(QuestionGroup, string)> ReadQuestionGroup(GroupAccessModel groupAccess, string token)
        {
            string serializedId = JsonConvert.SerializeObject(groupAccess);
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PostAsync(connectionString + "ReadQuestionGroup", new StringContent(serializedId, Encoding.UTF8, "application/json"));

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    QuestionGroup questionGroup = JsonConvert.DeserializeObject<QuestionGroup>(responseContent);

                    return (questionGroup, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get questionGroup. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }
        #endregion

        #region Role
        
        public async Task<(List<RoleModel>, string)> ReadAllRoles(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadAllRoles");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    List<RoleModel> roleModels = JsonConvert.DeserializeObject<List<RoleModel>>(responseContent);

                    return (roleModels, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get all roleModels. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }

       
        public async Task<(RoleModel, string)> ReadRole(int id, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(connectionString + $"ReadRole?id={id}");

                // Read the response content as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    RoleModel roleModel = JsonConvert.DeserializeObject<RoleModel>(responseContent);

                    return (roleModel, null);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return (null, responseContent);
                }
                else
                {
                    return (null, "Failed to get roleModel. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (null, "Something went wrong, contact customer support");
            }

        }
        #endregion

        #endregion

        #region Update
      
        public async Task<(bool, string)> UpdateQuestion(Question question, string token)
        {           
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(question);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PutAsync(connectionString + "UpdateQuestion", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to update question. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        
        public async Task<(bool, string)> UpdateCountry(Country country, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(country);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PutAsync(connectionString + "UpdateCountry", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to update country. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        public async Task<(bool, string)> UpdateArea(Area area, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(area);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PutAsync(connectionString + "UpdateArea", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to update area. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

       
        public async Task<(bool, string)> UpdateOption(Option option, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(option);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PutAsync(connectionString + "UpdateOption", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to update option. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

       
        public async Task<(bool, string)> UpdateAnswer(Answer answer, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(answer);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PutAsync(connectionString + "UpdateAnswer", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to update answer. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

      
        public async Task<(bool, string)> UpdateAnswerGroup(AnswerGroup answerGroup, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(answerGroup);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PutAsync(connectionString + "UpdateAnswerGroup", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to update answerGroup. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        
        public async Task<(bool, string)> UpdateQuestionGroup(QuestionGroup questionGroup, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(questionGroup);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PutAsync(connectionString + "UpdateQuestionGroup", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to update questionGroup. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        
        public async Task<(bool, string)> UpdateRole(RoleModel role, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Serialize the user object to JSON
                string serializedId = JsonConvert.SerializeObject(role);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.PutAsync(connectionString + "UpdateRole", new StringContent(serializedId, Encoding.UTF8, "application/json"));

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
                    return (false, "Failed to update role. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }
        #endregion

        #region Delete
        
        public async Task<(bool, string)> DeleteQuestion(int id, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.DeleteAsync(connectionString + $"DeleteQuestion?id={id}");

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
                    return (false, "Failed to delete question. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

       
        public async Task<(bool, string)> DeleteCountry(int id, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.DeleteAsync(connectionString + $"DeleteCountry?id={id}");

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
                    return (false, "Failed to delete country. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

       
        public async Task<(bool, string)> DeleteArea(int id, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.DeleteAsync(connectionString + $"DeleteArea?id={id}");

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
                    return (false, "Failed to delete area. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        
        public async Task<(bool, string)> DeleteOption(int id, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.DeleteAsync(connectionString + $"DeleteOption?id={id}");

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
                    return (false, "Failed to delete option. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        
        public async Task<(bool, string)> DeleteAnswer(int id, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.DeleteAsync(connectionString + $"DeleteAnswer?id={id}");

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
                    return (false, "Failed to delete answer. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

        
        public async Task<(bool, string)> DeleteAnswerGroup(int id, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.DeleteAsync(connectionString + $"DeleteAnswerGroup?id={id}");

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
                    return (false, "Failed to delete answer group. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

       
        public async Task<(bool, string)> DeleteQuestionGroup(int id, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.DeleteAsync(connectionString + $"DeleteQuestionGroup?id={id}");

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
                    return (false, "Failed to delete question group. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }

       
        public async Task<(bool, string)> DeleteRole(int id, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Make a POST request to the API endpoint
                HttpResponseMessage response = await _httpClient.DeleteAsync(connectionString + $"DeleteRole?id={id}");

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
                    return (false, "Failed to delete role. Status code: " + response.StatusCode);
                }
            }
            catch
            {
                return (false, "Something went wrong, contact customer support");
            }
        }
        #endregion

    }
}
