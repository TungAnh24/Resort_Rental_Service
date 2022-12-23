using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Service.RoomService;
using Resort_Rental.Domain.Entities;

namespace Resort_Rental.Controllers
{
    /*[Authorize]*/
    [Route("resort-manager/room")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public RoomController(IRoomService roomService, IMapper mapper, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _roomService = roomService;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _roomService.GetRooms();
            return rooms == null ? BadRequest() : Ok(rooms);
        }

        [HttpGet]
        [Route("get-room/{roomId}")]
        public async Task<IActionResult> GetRooms(long roomId)
        {
            var room = await _roomService.GetRoom(roomId);
            return room == null ? NoContent() : Ok(room);
        }

        [HttpPost]
        [Route("add-new")]
        public async Task<IActionResult> CreateRoom([FromForm] RoomDto roomDto, IFormFile file)
        {
            /*var special = Guid.NewGuid().ToString();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Images\room", special + "-" + file.FileName);
            using (FileStream ms = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(ms);
            }
            *//*var fileName = special + "-" + file.FileName;*//*
            roomDto.AcctualFileUrl = filePath;*/
            await _roomService.Create(roomDto, file);
            return Ok();
        }

        /*[HttpPost]
        *//*[Route("upload")]*//*
        public async Task<string> UploadImage([FromForm] RoomDto roomDto)
        {
            *//*try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        FileInfo fileInfo = new FileInfo(file.FileName);
                        var newFileName = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fileInfo.Extension;
                        var path = Path.Combine("", _environment.ContentRootPath + "\\Images\\" + newFileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        RoomDto roomDto = new RoomDto();
                        roomDto.AcctualFileUrl = path;
                        await _roomService.Create(roomDto);
                    }
                    return "Upload Oke";
                }
                else
                    return "Select File";
            }
            catch (Exception)
            {

                throw;
            }*/


            /* var special = Guid.NewGuid().ToString();
             var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Images\room", special + "-" + file.FileName);
             using (FileStream ms = new FileStream(filePath, FileMode.Create))
             {
                 await file.CopyToAsync(ms);
             }
             var fileName = special + "-" + file.FileName;
             return Path.Combine("@Images\room", fileName);
             return filePath;*//*

            if (roomDto.FileUri.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Images\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Images\\" + roomDto.FileUri.FileName))
                    {
                        await fileStream.CopyToAsync(fileStream);
                        fileStream.Flush();
                        return "\\Images\\" + roomDto.FileUri.FileName;
                    }
                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }
            else
                return "Faile";
        }*/

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateRoom(RoomDto roomDto)
        {
            await _roomService.Update(roomDto);
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteRoom(long id)
        {
            var existRoom = await _roomService.GetRoom(id);
            if (existRoom != null)
            {
                await _roomService.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound($"Room number: {existRoom?.RoomNumber} not found!");
            }
        }
    }
}
