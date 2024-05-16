using API.DBContext;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client;
using NuGet.Protocol;

namespace API.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private DBCon context;

        public HomeController(DBCon _context)
        {
            context = _context;
        }       

       

        #region Create
        [HttpPost("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion(Question question)
        {
            try
            {
                await context.Questions.AddAsync(question);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest("Couldn't add this question");
                }
            }
            catch
            {
                return BadRequest("Error CQuestion");
            }
            
            return Ok();
        }

        [HttpPost("CreateCountry")]
        public async Task<IActionResult> CreateCountry(Country country)
        {
            try
            {
                await context.Countrys.AddAsync(country);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest("Couldn't add this city");
                }
            }
            catch
            {
                return BadRequest("Error CCountry");
            }
            
            return Ok();
        }

        [HttpPost("CreateArea")]
        public async Task<IActionResult> CreateArea(Area area)
        {
            try
            {
                await context.Areas.AddAsync(area);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest("Couldn't add this area");
                }
            }
            catch
            {
                return BadRequest("Error CArea");
            }
           
            return Ok();
        }

        [HttpPost("CreateOption")]
        public async Task<IActionResult> CreateOption(Option option)
        {
            try
            {
                await context.Options.AddAsync(option);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest("Couldn't add this option");
                }
            }
            catch
            {
                return BadRequest("Error COption");
            }
            
            return Ok();
        }

        [HttpPost("CreateAnswer")]
        public async Task<IActionResult> CreateAnswer(Answer answer)
        {
            try
            {
                await context.Answers.AddAsync(answer);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest("Couldn't add this answer");
                }
            }
            catch
            {
                return BadRequest("Error CAnswer");
            }
            
            return Ok();
        }

        [HttpPost("CreateAnswerGroup")]
        public async Task<IActionResult> CreateAnswerGroup(AnswerGroup answerGroup)
        {
            try
            {
                await context.AnswerGroups.AddAsync(answerGroup);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest("Couldn't add this answergroup");
                }
            }
            catch
            {
                return BadRequest("Error CAnswerGroup");
            }
            
            return Ok();
        }

        [HttpPost("CreateQuestionGroup")]
        public async Task<IActionResult> CreateQuestionGroup(QuestionGroup questionGroup)
        {
            try
            {
                await context.QuestionGroups.AddAsync(questionGroup);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest("Couldn't add this questiongroup");
                }
            }
            catch
            {
                return BadRequest("Error CQuestionGroup");
            }
           
            return Ok();
        }
        #endregion

        #region Read

        #region Question
        [HttpGet("ReadAllQuestions")]
        public async Task<IActionResult> ReadAllQuestions()
        {
            try
            {
                return Ok(context.Questions.Include(x => x.Options));
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpGet("ReadQuestion")]
        public async Task<IActionResult> ReadQuestion(int id)
        {
            try
            {
                return Ok(context.Questions.Include(x => x.Options).FirstOrDefaultAsync(x => x.Id == id));
            }
            catch
            {
                return BadRequest();
            }
            
        }
        #endregion

        #region Country
        [HttpGet("ReadAllCountries")]
        public async Task<IActionResult> ReadAllCountries()
        {
            try
            {
                return Ok(context.Countrys);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpGet("ReadCountry")]
        public async Task<IActionResult> ReadCountry(int id)
        {
            try
            {
                return Ok(context.Countrys.FirstOrDefaultAsync(x => x.Id == id));
            }
            catch
            {
                return BadRequest();
            }
           
        }
        #endregion

        #region Area
        [HttpGet("ReadAllAreas")]
        public async Task<IActionResult> ReadAllAreas()
        {
            try
            {
                return Ok(context.Areas);
            }
            catch
            {
                return BadRequest();
            }
           
        }

        [HttpGet("ReadArea")]
        public async Task<IActionResult> ReadArea(int id)
        {
            try
            {
                return Ok(context.Areas.FirstOrDefaultAsync(x => x.Id == id));
            }
            catch
            {
                return BadRequest();
            }
            
        }
        #endregion

        #region Option
        [HttpGet("ReadAllOptions")]
        public async Task<IActionResult> ReadAllOptions()
        {
            try
            {
                return Ok(context.Options);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpGet("ReadOption")]
        public async Task<IActionResult> ReadOption(int id)
        {
            try
            {
                return Ok(context.Options.FirstOrDefaultAsync(x => x.Id == id));
            }
            catch
            {
                return BadRequest();
            }
            
        }
        #endregion

        #region Answer
        [HttpGet("ReadAllAnswers")]
        public async Task<IActionResult> ReadAllAnswers()
        {
            try
            {
                return Ok(context.Answers.Include(x => x.Question).ThenInclude(x => x.Options));
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpGet("ReadAnswer")]
        public async Task<IActionResult> ReadAnswer(int id)
        {
            try
            {
                return Ok(context.Answers.Include(x => x.Question).ThenInclude(x => x.Options).FirstOrDefaultAsync(x => x.Id == id));
            }
            catch
            {
                return BadRequest();    
            }
            
        }
        #endregion

        #region AnswerGroup
        [HttpGet("ReadAllAnswerGroups")]
        public async Task<IActionResult> ReadAllAnswerGroups()
        {
            try
            {
                return Ok(context.AnswerGroups
                    .Include(x => x.Country)
                    .Include(x => x.Area)
                    .Include(x => x.Answers)
                    .ThenInclude(x => x.Question)
                    .ThenInclude(x => x.Options)
                    );
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpGet("ReadAnswerGroup")]
        public async Task<IActionResult> ReadAnswerGroup(int id)
        {
            try
            {
                return Ok(context.AnswerGroups
                    .Include(x => x.Country)
                    .Include(x => x.Area)
                    .Include(x => x.Answers)
                    .ThenInclude(x => x.Question)
                    .ThenInclude(x => x.Options)
                    .FirstOrDefaultAsync(x => x.Id == id));
            }
            catch
            {
                return BadRequest();
            }
            
        }
        #endregion

        #region QuestionGroup
        [HttpGet("ReadAllQuestionGroups")]
        public async Task<IActionResult> ReadAllQuestionGroups()
        {
            try
            {
                return Ok(context.QuestionGroups
                    .Include(x => x.Area)
                    .Include(x => x.Country)
                    .Include(x => x.Questions)
                    .ThenInclude(x => x.Options)
                    );
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpGet("ReadQuestionGroup")]
        public async Task<IActionResult> ReadQuestionGroup(int id)
        {
            try
            {
                return Ok(context.QuestionGroups
                    .Include(x => x.Area)
                    .Include(x => x.Country)
                    .Include(x => x.Questions)
                    .ThenInclude(x => x.Options)
                    .FirstOrDefaultAsync(x => x.Id == id));
            }
            catch
            {
                return BadRequest();
            }
            
        }
        #endregion

        #endregion

        #region Update
        [HttpPut("UpdateQuestion")]
        public async Task<IActionResult> UpdateQuestion(Question question)
        {
            try
            {
                await Task.Run(() => {
                    context.Questions.Update(question);
                });


                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
            
            return Ok();
        }

        [HttpPut("UpdateCountry")]
        public async Task<IActionResult> UpdateCountry(Country country)
        {
            try
            {
                await Task.Run(() => {
                    context.Countrys.Update(country);
                });


                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
           
            return Ok();
        }

        [HttpPut("UpdateArea")]
        public async Task<IActionResult> UpdateArea(Area area)
        {
            try
            {
                await Task.Run(() => {
                    context.Areas.Update(area);
                });


                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
            
            return Ok();
        }

        [HttpPut("UpdateOption")]
        public async Task<IActionResult> UpdateOption(Option option)
        {
            try
            {
                await Task.Run(() => {
                    context.Options.Update(option);
                });


                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
           
            return Ok();
        }

        [HttpPut("UpdateAnswer")]
        public async Task<IActionResult> UpdateAnswer(Answer answer)
        {
            try
            {
                await Task.Run(() => {
                    context.Answers.Update(answer);
                });


                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
           
            return Ok();
        }

        [HttpPut("UpdateAnswerGroup")]
        public async Task<IActionResult> UpdateAnswerGroup(AnswerGroup answerGroup)
        {
            try
            {
                await Task.Run(() => {
                    context.AnswerGroups.Update(answerGroup);
                });


                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
            
            return Ok();
        }

        [HttpPut("UpdateQuestionGroup")]
        public async Task<IActionResult> UpdateQuestionGroup(QuestionGroup questionGroup)
        {
            try
            {
                await Task.Run(() => {
                    context.QuestionGroups.Update(questionGroup);
                });


                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
           
            return Ok();
        }
        #endregion

        #region Delete
        [HttpDelete("DeleteQuestion")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            try
            {
                Question question = new() { Id = id };
                context.Questions.Attach(question);
                context.Questions.Remove(question);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
            
            return Ok();
        }

        [HttpDelete("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            try
            {
                Country country = new() { Id = id };
                context.Countrys.Attach(country);
                context.Countrys.Remove(country);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
            
            return Ok();
        }

        [HttpDelete("DeleteArea")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            try
            {
                Area area = new() { Id = id };
                context.Areas.Attach(area);
                context.Areas.Remove(area);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
           
            return Ok();
        }

        [HttpDelete("DeleteOption")]
        public async Task<IActionResult> DeleteOption(int id)
        {
            try
            {
                Option option = new() { Id = id };
                context.Options.Attach(option);
                context.Options.Remove(option);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
            
            return Ok();
        }

        [HttpDelete("DeleteAnswer")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            try
            {
                Answer answer = new() { Id = id };
                context.Answers.Attach(answer);
                context.Answers.Remove(answer);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
            
            return Ok();
        }

        [HttpDelete("DeleteAnswerGroup")]
        public async Task<IActionResult> DeleteAnswerGroup(int id)
        {
            try
            {
                AnswerGroup answerGroup = new() { Id = id };
                context.AnswerGroups.Attach(answerGroup);
                context.AnswerGroups.Remove(answerGroup);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
            
            return Ok();
        }

        [HttpDelete("DeleteQuestionGroup")]
        public async Task<IActionResult> DeleteQuestionGroup(int id)
        {
            try
            {
                QuestionGroup questionGroup = new() { Id = id };
                context.QuestionGroups.Attach(questionGroup);
                context.QuestionGroups.Remove(questionGroup);

                if (await context.SaveChangesAsync() == 0)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
            
            return Ok();
        }
        #endregion

    }
}
