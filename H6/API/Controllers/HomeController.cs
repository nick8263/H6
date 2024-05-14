using API.DBContext;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Controllers
{
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
            await context.Questions.AddAsync(question);

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("CreateCountry")]
        public async Task<IActionResult> CreateCountry(Country country)
        {
            await context.Countrys.AddAsync(country);

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("CreateArea")]
        public async Task<IActionResult> CreateArea(Area area)
        {
            await context.Areas.AddAsync(area);

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("CreateOption")]
        public async Task<IActionResult> CreateOption(Option option)
        {
            await context.Options.AddAsync(option);

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("CreateAnswer")]
        public async Task<IActionResult> CreateAnswer(Answer answer)
        {
            await context.Answers.AddAsync(answer);

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("CreateAnswerGroup")]
        public async Task<IActionResult> CreateAnswerGroup(AnswerGroup answerGroup)
        {
            await context.AnswerGroups.AddAsync(answerGroup);

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("CreateQuestionGroup")]
        public async Task<IActionResult> CreateQuestionGroup(QuestionGroup questionGroup)
        {
            await context.QuestionGroups.AddAsync(questionGroup);

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        #endregion

        #region Read

        #region Question
        [HttpGet("ReadAllQuestions")]
        public async Task<IActionResult> ReadAllQuestions()
        {
            return Ok(context.Questions);
        }

        [HttpGet("ReadQuestion")]
        public async Task<IActionResult> ReadQuestion(int id)
        {
            return Ok(context.Questions.FirstOrDefaultAsync(x => x.Id == id));
        }
        #endregion

        #region Country
        [HttpGet("ReadAllCountries")]
        public async Task<IActionResult> ReadAllCountries()
        {
            return Ok(context.Countrys);
        }

        [HttpGet("ReadCountry")]
        public async Task<IActionResult> ReadCountry(int id)
        {
            return Ok(context.Countrys.FirstOrDefaultAsync(x => x.Id == id));
        }
        #endregion

        #region Area
        [HttpGet("ReadAllAreas")]
        public async Task<IActionResult> ReadAllAreas()
        {
            return Ok(context.Areas);
        }

        [HttpGet("ReadArea")]
        public async Task<IActionResult> ReadArea(int id)
        {
            return Ok(context.Areas.FirstOrDefaultAsync(x => x.Id == id));
        }
        #endregion

        #region Option
        [HttpGet("ReadAllOptions")]
        public async Task<IActionResult> ReadAllOptions()
        {
            return Ok(context.Options);
        }

        [HttpGet("ReadOption")]
        public async Task<IActionResult> ReadOption(int id)
        {
            return Ok(context.Options.FirstOrDefaultAsync(x => x.Id == id));
        }
        #endregion

        #region Answer
        [HttpGet("ReadAllAnswers")]
        public async Task<IActionResult> ReadAllAnswers()
        {
            return Ok(context.Answers);
        }

        [HttpGet("ReadAnswer")]
        public async Task<IActionResult> ReadAnswer(int id)
        {
            return Ok(context.Answers.FirstOrDefaultAsync(x => x.Id == id));
        }
        #endregion

        #region AnswerGroup
        [HttpGet("ReadAllAnswerGroups")]
        public async Task<IActionResult> ReadAllAnswerGroups()
        {
            return Ok(context.AnswerGroups);
        }

        [HttpGet("ReadAnswerGroup")]
        public async Task<IActionResult> ReadAnswerGroup(int id)
        {
            return Ok(context.AnswerGroups.FirstOrDefaultAsync(x => x.Id == id));
        }
        #endregion

        #region QuestionGroup
        [HttpGet("ReadAllQuestionGroups")]
        public async Task<IActionResult> ReadAllQuestionGroups()
        {
            return Ok(context.QuestionGroups);
        }

        [HttpGet("ReadQuestionGroup")]
        public async Task<IActionResult> ReadQuestionGroup(int id)
        {
            return Ok(context.QuestionGroups.FirstOrDefaultAsync(x => x.Id == id));
        }
        #endregion

        #endregion

        #region Update
        [HttpPut("UpdateQuestion")]
        public async Task<IActionResult> UpdateQuestion(Question question)
        {
            await Task.Run(() => {
                context.Questions.Update(question);
            }); 

            
            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("UpdateCountry")]
        public async Task<IActionResult> UpdateCountry(Country country)
        {
            await Task.Run(() => {
                context.Countrys.Update(country);
            });
           

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("UpdateArea")]
        public async Task<IActionResult> UpdateArea(Area area)
        {
            await Task.Run(() => {
                context.Areas.Update(area);
            });
            

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("UpdateOption")]
        public async Task<IActionResult> UpdateOption(Option option)
        {
            await Task.Run(() => {
                context.Options.Update(option);
            });
           

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("UpdateAnswer")]
        public async Task<IActionResult> UpdateAnswer(Answer answer)
        {
            await Task.Run(() => {
                context.Answers.Update(answer);
            });
            

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("UpdateAnswerGroup")]
        public async Task<IActionResult> UpdateAnswerGroup(AnswerGroup answerGroup)
        {
            await Task.Run(() => {
                context.AnswerGroups.Update(answerGroup);
            });
            

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("UpdateQuestionGroup")]
        public async Task<IActionResult> UpdateQuestionGroup(QuestionGroup questionGroup)
        {
            await Task.Run(() => {
                context.QuestionGroups.Update(questionGroup);
            });
            

            if (await context.SaveChangesAsync() == 0)
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
            Question question = new() { Id = id };
            context.Questions.Attach(question);
            context.Questions.Remove(question);

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            Country country = new() { Id = id };
            context.Countrys.Attach(country);
            context.Countrys.Remove(country);

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("DeleteArea")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            Area area = new() { Id = id };
            context.Areas.Attach(area);
            context.Areas.Remove(area);

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("DeleteOption")]
        public async Task<IActionResult> DeleteOption(int id)
        {
            Option option = new() { Id = id };
            context.Options.Attach(option);
            context.Options.Remove(option);

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("DeleteAnswer")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            Answer answer = new() { Id = id };
            context.Answers.Attach(answer);
            context.Answers.Remove(answer);

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("DeleteAnswerGroup")]
        public async Task<IActionResult> DeleteAnswerGroup(int id)
        {
            AnswerGroup answerGroup = new() { Id = id };
            context.AnswerGroups.Attach(answerGroup);
            context.AnswerGroups.Remove(answerGroup);

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("DeleteQuestionGroup")]
        public async Task<IActionResult> DeleteQuestionGroup(int id)
        {
            QuestionGroup questionGroup = new() { Id = id };
            context.QuestionGroups.Attach(questionGroup);
            context.QuestionGroups.Remove(questionGroup);

            if (await context.SaveChangesAsync() == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        #endregion

    }
}
