using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAssistbyTowsif.Entity.Models;
using TravelAssistbyTowsif.Models.VM;

namespace TravelAssistbyTowsif.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly AuthenticationContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PlaceController(AuthenticationContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
    }

        // GET: api/Place
        [HttpGet]
        [Route("GetPlaces")]
        public async Task<ActionResult<IEnumerable<PlaceModel>>> GetPlaces()
        {
            return await _context.Places.ToListAsync();
        }

        // GET: api/Place/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaceModel>> GetPlaceModel(int id)
        {
            var placeModel = await _context.Places.FindAsync(id);

            if (placeModel == null)
            {
                return NotFound();
            }

            return placeModel;
        }

        // PUT: api/Place/5
        [HttpPut("{id}")]
        [Route("PutPlaceModel")]
        public async Task<IActionResult> PutPlaceModel(int id, PlaceModel placeModel)
        {
            if (id != placeModel.PlaceId)
            {
                return BadRequest();
            }

            _context.Entry(placeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Place
        [HttpPost]
        [Route("PostPlaceModel")]
        public async Task<ActionResult<PlaceModel>> PostPlaceModel([FromForm] PlaceVm placeVModel)
        {
            var filePath= "";
            try
            {
                if (placeVModel.image.Length > 0)
                {
                    //string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    //if (!Directory.Exists(path))
                    //{
                    //    Directory.CreateDirectory(path);
                    //}
                    //using (FileStream fileStream = System.IO.File.Create(path + placeVModel.image.FileName))
                    //{
                    //    var filePath = Path.Combine(fileStream, file.FileName);
                    //    placeVModel.image.CopyTo(fileStream);
                    //    fileStream.Flush();
                    //}


                    var file = placeVModel.image; 
                    var upload = Path.Combine(_webHostEnvironment.WebRootPath, "\\uploads\\");

                    if (!Directory.Exists(upload))
                        Directory.CreateDirectory(upload);

                    filePath = Path.Combine(upload, file.FileName);


                    if (file.Length > 0)
                    {
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                    }
                }
            }
            catch (Exception e) { }

            PlaceModel placeModel = new PlaceModel();
            placeModel.PlaceId = placeVModel.PlaceId;
            placeModel.Description = placeVModel.Description;
            placeModel.Title = placeVModel.Title;
            placeModel.image = filePath;
            placeModel.PlaceId = placeVModel.PlaceId;
            placeModel.UserId = placeVModel.UserId;

            _context.Places.Add(placeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaceModel", new { id = placeModel.PlaceId }, placeModel);
        }

        // DELETE: api/Place/5
        [HttpDelete("{id}")]
        [Route("DeletePlaceModel")]
        public async Task<ActionResult<PlaceModel>> DeletePlaceModel(int id)
        {
            var placeModel = await _context.Places.FindAsync(id);
            if (placeModel == null)
            {
                return NotFound();
            }

            _context.Places.Remove(placeModel);
            await _context.SaveChangesAsync();

            return placeModel;
        }


              /**  Create Procedure spGetPlacesByUserId
        @Id int
        as
        Begin
         Select * from Places
         Where Preferences Like '%'(Select Preference from [TravelAssistDB].[dbo].[AspNetUsers] Where Id = 1)'%'
        End


        Create Procedure spGetCommentsByPlaceId
        @Id int
        as
        Begin
         Select * from [TravelAssistDB].[dbo].[Comments]
         Where PlaceId = @Id
        End
              */


        // GET: api/Place/5
        [HttpGet("{id}")]
        [Route("GetPlaceComments")]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetPlaceComments(int placeId)
        {
            return await _context.Comments
                .FromSqlRaw("spGetCommentsByPlaceId {0}", placeId)
                .ToListAsync();
            //return await _context.Places.ToListAsync();
        }

        //// GET: api/Place/5
        //[HttpGet("{id}")]
        //[Route("GetPlacesByUserPreference")]
        //public async Task<ActionResult<IEnumerable<PlaceModel>>> GetPlacesByUserPreference(int userId)
        //{
        //    var prefer =  (await _context.ApplicationUsers
        //        .FromSqlRaw("spGetPreferenceByUserId {0}", userId)
        //        .ToListAsync()).FirstOrDefault();

        //    return _context.Places.Where(x => x.Preferences.Contains(prefer.ToString()));
        //}


        /*
         * SELECT Preferences FROM [TravelAssistDB].[dbo].[Places] WHERE Preferences LIKE '%HILL%'


Create Procedure spGetPreferenceByUserId
@Id int
as
Begin
 Select Preference from [TravelAssistDB].[dbo].[AspNetUsers] Where Id = @Id
End


Create Procedure spGetPlacesByUserPreference
@Preference varchar
as
Begin
	declare @pr2 varchar(100)
	set @pr2 =  '%' + @Preference + '%'
 Select * from [TravelAssistDB].[dbo].[Places] Where Preferences Like @pr2
End





Create Procedure spGetPlacesByNotUserPreference
@Preference varchar
as
Begin
	declare @pr2 varchar(100)
	set @pr2 =  '%' + @Preference + '%'
 Select * from [TravelAssistDB].[dbo].[Places] Where Preferences NOT LIKE @pr2
End






Create Procedure spGetPlacesByUserPreference
@Preference varchar
as
Begin
 Select * from [TravelAssistDB].[dbo].[Places] Where Preferences Like '%' + @Preference + '%'
End


Create Procedure spGetPlacesByNotUserPreference
@Preference varchar
as
Begin
 Select * from [TravelAssistDB].[dbo].[Places] Where Preferences NOT LIKE '%' + @Preference + '%'
End


EXEC [dbo].[spGetCommentsByPlaceId] @Id = 1
EXEC [dbo].[spGetPlacesByNotUserPreference] @Preference = 'Hill'
EXEC [dbo].[spGetPlacesByUserPreference] @Preference = 'Hill'
EXEC [dbo].[spGetPreferenceByUserId]  @Id = 1
         * 
         */





        private bool PlaceModelExists(int id)
        {
            return _context.Places.Any(e => e.PlaceId == id);
        }
    }
}
